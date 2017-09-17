using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using XS156Client35;
using XS156Client35.Models;
using static System.String;
using DateTime = System.DateTime;


namespace AutoBagBench
{
    public partial class Form1 : Form
    {
        public User AutoBagUser;
        public Plc M221Plc;
        public BarcodeReader BarcodeReader;
       
        public IXs156Client Xs156Client;
        public Xs156Setting Xs156Setting;

        private IndividualLabel _individualPrint;
        private GroupLabel _groupLabelPrint;
        private GroupingBox _groupingBox;
        private Image _individualRealSize;
        private Image _groupRealSize;

        private Process _thisMechineProcess;
      

        public StringDelegate DelegateFunction;
        public BarcodeOrderNumberDelegate DelegateFunction2;
        public StringDelegate LblRemaining;
        public StringDelegate TargetReachedGroup;
        public StringDelegate NewReferenceFromTracking;
        public TrackingBagDelegate TrackingLoaded;
        public StringDelegate TrackingExceptionEvent;
        public StringDelegate M221ExceptionEvent;
        public IntDelegate M221HmiStateHandler;

        private TrackingBagDelegate _trackingBagHandler;

        private Equipment _equipment;

        private bool _manual;
        public Form1()
        {
            
            InitializeComponent();
        }

        private bool _reloading;

        private void LoadAndInitialize()
        {
            try
            {
                _reloading = true;
                
                BarcodeReader = new BarcodeReader();
                BarcodeReader.DataBarcodeReadOk += BarcodeRead;
                try
                {
                    BarcodeReader.OpenPort();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                UnAssignGroupEvent();

                _groupingBox = new GroupingBox();
                ReAssignGroupingEvents();
                LblRemaining = new StringDelegate(LblRemainingUpdate);
                TargetReachedGroup = new StringDelegate(GroupBoxCompleted);

                _individualPrint = new IndividualLabel { LabelPath = "" };
                _groupLabelPrint = new GroupLabel();

                _equipment = new Equipment
                {
                    Id = new Guid(SettingHelper.EquipmentIdentity()),
                    EquipmentName = SettingHelper.EquipmentName()
                };
                _thisMechineProcess = new Process { EquipmentId = _equipment.Id, Traceability = SettingHelper.Traceability() };

                M221Plc = new Plc();
                M221Plc.DataUpdated += M221Plc_PlcUpdated;
                M221Plc.PlcOutputChanged += M221_OutputChanged;
                M221Plc.PlcRejectChanged += (M221_RejectChanged);
                M221Plc.HmiStateChanged += M221_HMIStateChanged;
                M221HmiStateHandler = M221_HmiStateHandler;
                M221Plc.PlcErrorEvent += M221_ErrorMessage;
                M221ExceptionEvent = new StringDelegate(M221_ErrorHandler);

                DelegateFunction += PlcDataUpdated;
                DelegateFunction2 += BarcodeScanned;
               
                M221Plc.SetHmiState(HmiState.NoState);
                M221Plc.SetPlcMode(PlcMode.Auto);

                M221Plc.StartUpdater();

                checkBox1.Checked = _thisMechineProcess.Traceability; // this will load traceability when the value is different than default.

                if (!checkBox1.Checked)
                {
                    var lastRunning = new Guid(SettingHelper.LastRunningProccessId());
                    if (lastRunning != Guid.Empty){
                        _thisMechineProcess.ProcessGuid = lastRunning;
                        _thisMechineProcess.ReloadLastRunning(lastRunning.ToString());
                        if (!IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
                        {
                            M221Plc.SetOutputQuantity(_thisMechineProcess.OutputQuantity);
                            ReloadReference(_thisMechineProcess.ReferenceName);
                            M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                            _groupingBox.ParseFromTotalOutput(_thisMechineProcess.OutputQuantity);
                        }
                    }
                }



                timerClock.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reload()
        {
           
           
            if (BarcodeReader != null)
            {
                BarcodeReader.DataBarcodeReadOk -= BarcodeRead;
                
            }
            BarcodeReader = new BarcodeReader();
            BarcodeReader.DataBarcodeReadOk += BarcodeRead;
            BarcodeReader.OpenPort();
            _individualPrint?.CloseApp();
            _groupLabelPrint?.CloseApp();
            _individualPrint = new IndividualLabel() { LabelPath = "" };
            UnAssignGroupEvent();
            _groupLabelPrint = new GroupLabel();           
            ReAssignGroupingEvents();
            LblRemaining = LblRemainingUpdate;
            TargetReachedGroup = GroupBoxCompleted;

            _equipment = new Equipment()
            {
                Id = new Guid(SettingHelper.EquipmentIdentity()),
                EquipmentName = SettingHelper.EquipmentName()
            };
            _thisMechineProcess = new Process { EquipmentId = _equipment.Id ,Traceability = SettingHelper.Traceability()};
            if (M221Plc != null)
            {
                M221Plc.DataUpdated -= M221Plc_PlcUpdated;
                M221Plc.PlcOutputChanged -= M221_OutputChanged;
                M221Plc.PlcRejectChanged -= (M221_RejectChanged);
                M221Plc.HmiStateChanged -= M221_HMIStateChanged;
                M221Plc.PlcErrorEvent -= M221_ErrorMessage;
            }
            M221Plc = new Plc();
            M221Plc.DataUpdated += M221Plc_PlcUpdated;
            M221Plc.PlcOutputChanged += M221_OutputChanged;
            M221Plc.PlcRejectChanged += (M221_RejectChanged);
            M221Plc.HmiStateChanged += M221_HMIStateChanged;
            M221Plc.PlcErrorEvent += M221_ErrorMessage;

            M221ExceptionEvent = M221_ErrorHandler;
            M221HmiStateHandler = M221_HmiStateHandler;


            DelegateFunction = PlcDataUpdated;
            DelegateFunction2 = BarcodeScanned;

           
            M221Plc.SetHmiState(HmiState.NoState);
            M221Plc.SetPlcMode(PlcMode.Auto);

           
           
            checkBox1.Checked = _thisMechineProcess.Traceability;
            if (!_thisMechineProcess.Traceability)
            {
                var lastRunning = new Guid(SettingHelper.LastRunningProccessId());
                if (lastRunning != Guid.Empty)
                {
                    _thisMechineProcess.ProcessGuid = lastRunning;
                    _thisMechineProcess.ReloadLastRunning(lastRunning.ToString());
                    if (!IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
                    {
                        M221Plc.SetOutputQuantity(_thisMechineProcess.OutputQuantity);
                        ReloadReference(_thisMechineProcess.ReferenceName);
                        M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                        _groupingBox.ParseFromTotalOutput(_thisMechineProcess.OutputQuantity);
                    }

                }
           }
            chb_AutoManual.CheckState = CheckState.Unchecked;
            M221Plc.StartUpdater();
            timerClock.Start();
        }
        private void M221_ErrorMessage(Error data)
        {
            var j = "Error:" + data.Code+ ": " + data.Message;
            Invoke(new StringDelegate(M221ExceptionEvent), j);
        }

        private void M221_ErrorHandler(string data)
        {
            UpdatePlcMessage(data);
            tb_ErrorAlarm.Visible = true;
            tb_ErrorAlarm.Text = data;
            if (!data.Contains("Error:1000"))
            {
                MessageBox.Show(data, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void GroupRemainingChanged(int data)
        {
            Invoke(new StringDelegate(LblRemaining), data.ToString());
        }

        public void LblRemainingUpdate(string data)
        {
            lbl_RemainingOfGroup.Text = data;
            //lblPacked.Text = _groupingBox?.ToString();
        }
        private void GroupTargetIsReached(int data)
        {
            Invoke(new StringDelegate(TargetReachedGroup), data.ToString());
        }
        public void GroupBoxCompleted(string data)
        {
            PrintGroup();
            M221Plc.SetHmiState(HmiState.ChangeBigBox);
            //MessageBox.Show(@"Big Box Quantity sudah terpenuhi! Segera ganti Big Box", @"Big Box Penuh",
            //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            M221Plc.SetHmiState(HmiState.WaitingForAccessories);
        }

        private void ReAssignGroupingEvents()
        {
            _groupingBox.GroupingTargetReachedEvent +=  GroupTargetIsReached;
            _groupingBox.GroupingRemainingChangedEvent += GroupRemainingChanged;
        }

        private void UnAssignGroupEvent()
        {
            if (_groupingBox == null) return;
            _groupingBox.GroupingTargetReachedEvent -= GroupTargetIsReached;
            _groupingBox.GroupingRemainingChangedEvent -= GroupRemainingChanged;
        }

        private void NewTrackingLoaded(TrackingDataBag track)
        {
            M221Plc.SetHmiState(HmiState.LoadingWorkOrder);
            Xs156Client.StopUpdater();
            _reloading = true;
            if (track.TrackingIdentity != lbl_ProcessId.Text)
            {
                chb_AutoManual.CheckState = CheckState.Unchecked;
                Xs156Client.Reload();
            }
            
            
                //Xs156Client.Reload();
                btn_ChangeReference.Visible = false;
                btn_CloseReference.Visible = true;
                     
            docPreview.Image = new Bitmap(1, 1);
            docPreviewGroup.Image = new Bitmap(1, 1);

            BagType oldBagType = _thisMechineProcess.Product.BagType;
            _thisMechineProcess = new Process
            {
                EquipmentId = new Guid(Xs156Client.ThisEquipment().Id),
                ProcessGuid = new Guid(Xs156Client.ThisEquipmentReferenceProcess().ReferenceProcess.ToString()),
                Traceability = SettingHelper.Traceability(),
                StartDateTime =DateTime.Parse(track.StartDateTime),
                OrderNumber = track.OrderNumber
            };
            if (VerifyReferenceBarcode(track.CurrentReferenceName))
            {
                if (_groupingBox.Reference != track.CurrentReferenceName)
                {
                    UnAssignGroupEvent();
                    _groupingBox = new GroupingBox(_thisMechineProcess.Product.GroupingSize, track.CurrentReferenceName)
                    {
                        ProcessGuid = new Guid(track.TrackingIdentity)
                    };
                    _thisMechineProcess.ReferenceName = track.CurrentReferenceName;
                    ReAssignGroupingEvents();
                }
                else
                {
                    if (_groupingBox.ArticleNumber != track.OrderNumber)
                    {
                        _groupingBox.SavePrevious();
                        _groupingBox.SetArticle(track.OrderNumber);
                       
                    }
                    _groupingBox.Load(_thisMechineProcess.Product.GroupingSize, track.CurrentReferenceName);
                }
            }
            else
            {
                M221Plc.SetHmiState(HmiState.WaitingNewReferenceFromServer);
                UpdatePlcMessage("Reference verification failed");
                Xs156Client.StartUpdater();
                return;
            }

            if (oldBagType != _thisMechineProcess.Product.BagType)
            {
                MessageBox.Show(@"Ganti Ukuran Plastic Bag menjadi : " + _thisMechineProcess.Product.BagType +"\r\n"+@"Click OK jika sudah sesuai!",
                    @"Change Plastic Bag", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            M221Plc.SetAccessories(_thisMechineProcess.Product.AccessoriesType);
            Xs156Client.StartUpdater();

        }

        private void TrackingNewlyLoaded(TrackingDataBag data)
        {
            Invoke(new TrackingBagDelegate(TrackingLoaded), new object[] { data });
        }

        private void Xs156Exception(string info)
        {
         //   Invoke(new StringDelegate(TrackingExceptionEvent), new object[] { info });
            MessageBox.Show(info, @"Traceability",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

       

        private void TrackingBagHandler(TrackingDataBag track)
        {
            lbl_ProcessId.Text = track.TrackingIdentity;
            lbl_EquipmentId.Text = track.EquipmentIdentity;
            lbl_LineGroup.Text = track.LineGroupName;
            lbl_ReferenceTraceability.Text = track.CurrentReferenceName;
            lmpTraceability.BackColor = lmpTraceability.BackColor == Color.Yellow ? Color.YellowGreen : Color.Yellow;

            _thisMechineProcess.ProcessableQuantity = track.ProcessableQuantity;
            if (_reloading && M221Plc!=null && M221Plc.HmiState == HmiState.LoadingWorkOrder )
            {
                M221Plc.SetOutputQuantity(track.OutputQuantity);
                M221Plc.SetRejectQuantity(track.RejectedQuantity);
                M221Plc.SetTargetTarget(track.TargetQuantity);
                _groupingBox.ParseFromTotalOutput(track.OutputQuantity);
                if (!_manual) M221Plc.SetHmiState(HmiState.WaitingForProcessable);
                _reloading = false;
            }
            if (M221Plc?.HmiState == HmiState.WaitingForProcessable)
            {
                if (_thisMechineProcess.ProcessableQuantity > _thisMechineProcess.OutputQuantity)
                {
                    M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                }
            }           
        }

        private void TrackingDataUpdated(TrackingDataBag track)
        {
            Invoke(new TrackingBagDelegate(_trackingBagHandler), new object[] {track});
        }

      
        private void BarcodeRead(string data,string ordernumber)
        {
            Invoke(new BarcodeOrderNumberDelegate(DelegateFunction2), new object[] {data, ordernumber});
        }

        private void M221Plc_PlcUpdated()
        {
            try
            {
                Invoke(new StringDelegate(DelegateFunction), new object[] {M221Plc.HmiState.ToString()});
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void M221_OutputChanged(int data)
        {
            if (!_reloading && M221Plc.HmiState!=HmiState.LoadingWorkOrder)
            {
                if (!IsNullOrWhiteSpace(_thisMechineProcess.Product.ReferenceName))
                    _thisMechineProcess.SetOutputQuantity(data);
                    _groupingBox.ParseFromTotalOutput(data);
                if (checkBox1.Checked) Xs156Client.SetOutputQuantity(data);
            }
          
        }

        private void PrintIndividual()
        {
            if (M221Plc != null)
            {
                if (M221Plc.IndividualBagLabelPrint == false)
                {
                    try
                    {
                        _individualPrint.ActiveReference = _thisMechineProcess.Product.ReferenceName;
                        _individualPrint.LabelPath = _thisMechineProcess.Product.LabelFile+".lab";
                        _individualPrint.LoadCurrentLabel();
                        _individualRealSize = (Image) _individualPrint.RealSizeImage.Clone();
                        docPreview.Image = _individualRealSize;
                        docPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                        _individualPrint.Print();

                        M221Plc.SetIndividualBagPrinted(true);

                        Refresh();
                        UpdatePlcMessage("");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Print Ind Label:  " + ex.Message);
                    }
                }
                else
                {
                    UpdatePlcMessage("Plastic bag sudah di print!");
                }
            }
        }

        public void PrintGroup()
        {
            try
            {
                _groupLabelPrint.ActiveReference = _thisMechineProcess.Product.ReferenceName;
                docPreviewGroup.Image = _groupLabelPrint.LoadCurrentLabel();
                _groupLabelPrint.Print();
                _groupRealSize = (Image)_groupLabelPrint.RealSizeImage.Clone();
                docPreviewGroup.Image = _groupRealSize;
                docPreviewGroup.SizeMode = PictureBoxSizeMode.StretchImage;
                Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void M221_HmiStateHandler(int data)
        {
            var j = (HmiState)data;
            switch (j)
            {
                case HmiState.NoState: UpdatePcMessage("PC is Idle.");
                    break;
                case HmiState.NewReferenceReadyForProduction:
                    UpdatePcMessage("Masukkan Sensor ke plastic Bag.");
                    break;
                case HmiState.WaitingForAccessories:
                    //if (_thisMechineProcess.Traceability)
                    //{
                    //    if (Xs156Client.GetProcessableQuantity() > _thisMechineProcess.OutputQuantity || _manual || M221Plc.MaintenanceMode)
                    //    {
                    //        PrintIndividual();
                    //        UpdatePcMessage("Masukkan Sensor & Accessories ke plastic Bag");
                    //    }
                    //    else
                    //    {
                    //        M221Plc.SetHmiState(HmiState.WaitingForProcessable);
                    //    }
                    //}
                    //else
                    //{
                    //    PrintIndividual();
                    //    UpdatePcMessage("Masukkan Sensor & Accessories ke plastic Bag");
                    //}
                    PrintIndividual();
                    UpdatePcMessage("Masukkan Sensor & Accessories ke plastic Bag");
                    break;
                case HmiState.WaitingForSealer:
                    UpdatePcMessage("Activekan Sealer!");
                    break;
                case HmiState.WaitForRejectBinEntry:
                    M221Plc.SetIndividualBagPrinted(false);
                    UpdatePcMessage("Masukkan Plastic Bag ke Reject Bin");
                    break;
                case HmiState.WaitingForBigBoxEntry:
                    M221Plc.SetIndividualBagPrinted(false);
                    UpdatePcMessage("Masukkan Plastic Bag ke Big Carton Box");
                    break;
                case HmiState.ReadyAndWaitForNewReference:
                    UpdatePcMessage("Menunggu Reference Entry...");
                    break;
                case HmiState.ReadyWithReferenceWaitForTarget:
                    UpdatePcMessage("Menunggu Target Quantity entry...");
                    break;
                case HmiState.WaitingPackingBarcodeVerify:
                    UpdatePcMessage("Scan plastic Bag dengan Barcode scanner...");
                    break;
                case HmiState.WaitingNewReferenceFromServer:
                    UpdatePcMessage("Menunggu reference dari Server...");
                    break;
                case HmiState.WaitingForProcessable:
                    UpdatePcMessage("Menunggu Processable output from previous machine ...");
                    break;
                case HmiState.LoadingWorkOrder:
                    UpdatePcMessage("Memuat Work Order Number baru ...");
                    break;
                default:
                    UpdatePcMessage("Status PC unknown!");
                    break;
            }
        }
        private void M221_HMIStateChanged(int data)
        {
            Invoke(new IntParamEvent(M221HmiStateHandler), new object[] {data});
        }
        private void M221_RejectChanged(int data)
        {
            if (!_reloading && M221Plc.HmiState != HmiState.LoadingWorkOrder)
            {              
                _thisMechineProcess.SetRejectQuantity(data);
                if (checkBox1.Checked) Xs156Client.SetRejectQuantity(data);
            }
        }
        private void PlcDataUpdated(string data)
        {
            Blink();
        }

        private void Blink()
        {
            lmpPLCCom.BackColor = lmpPLCCom.BackColor == Color.Yellow ? Color.YellowGreen : Color.Yellow;
        }
        public void UpdatePlcMessage(string message)
        {
            textBoxPLCmessage.Text = message;
        }
        public void UpdatePcMessage(string message)
        {
            textBoxPCMessage.Text = message;
        }

        private void ReloadReference(string reference)
        {
            if (VerifyReferenceBarcode(reference))
            {
                if (_groupingBox.Reference != reference)
                {
                    UnAssignGroupEvent();
                    _groupingBox = new GroupingBox(_thisMechineProcess.Product.GroupingSize, reference)
                    {
                        ProcessGuid = _thisMechineProcess.ProcessGuid
                    };
                    ReAssignGroupingEvents();
                }
                else
                {
                    if (_groupingBox.ArticleNumber != _thisMechineProcess.OrderNumber)
                    {
                        _groupingBox.SavePrevious();
                        _groupingBox.SetArticle(_thisMechineProcess.OrderNumber);
                        
                    }
                    _groupingBox.Load(_thisMechineProcess.Product.GroupingSize, reference);
                }
                M221Plc.SetAccessories(_thisMechineProcess.Product.AccessoriesType);
                M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
            }
            else
            {
                UpdatePlcMessage("Reference verification failed");
            }
           
        }
        private void BarcodeScanned(string data, string ordernumber)
        {
            data = data.Trim('\r', '\n');
            switch (M221Plc.HmiState)
            {
                case HmiState.ReadyAndWaitForNewReference:
                case HmiState.WaitingNewReferenceFromServer:
                    if (!_thisMechineProcess.Traceability)
                    {
                        if (VerifyReferenceBarcode(data))
                        {
                            if (_groupingBox.Reference != data)
                            {
                                UnAssignGroupEvent();
                                _groupingBox = new GroupingBox(_thisMechineProcess.Product.GroupingSize, data)
                                {
                                    ProcessGuid = _thisMechineProcess.ProcessGuid
                                };
                                ReAssignGroupingEvents();
                            }
                            else
                            {
                                if (_groupingBox.ArticleNumber != _thisMechineProcess.OrderNumber) { 
                                    _groupingBox.SavePrevious();
                                    _groupingBox.SetArticle(_thisMechineProcess.OrderNumber);                              
                                    }
                                _groupingBox.Load(_thisMechineProcess.Product.GroupingSize, data);
                            }
                            _thisMechineProcess.StartDateTime = DateTime.Now;
                            M221Plc.SetAccessories(_thisMechineProcess.Product.AccessoriesType);
                            M221Plc.SetHmiState(HmiState.NewReferenceReadyForProduction);
                        }
                        else
                        {
                            UpdatePlcMessage("Reference verification failed");
                        }
                    }
                    else
                    {
                        if (VerifyReferenceBarcode(data))
                        {
                            try
                            {
                                Xs156Client.LoadByOrderNumber(ordernumber);
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, @"Traceability");
                                UpdatePlcMessage("Failed To load Process!");
                            }
                        }
                        else
                        {
                            UpdatePlcMessage("Reference verification failed");
                        }
                    }
                    break;
                case HmiState.ReadyWithReferenceWaitForTarget:
                    var j = VerifyTarget(data);
                    if (j > 0)
                    {
                        _thisMechineProcess.Target = j;
                        _thisMechineProcess.StartDateTime = DateTime.Now;
                        M221Plc.SetHmiState(HmiState.NewReferenceReadyForProduction);
                       
                        _thisMechineProcess.ProcessGuid = Guid.NewGuid();
                    }
                    else
                    {
                        UpdatePlcMessage("Target Entry verification failed.");
                    }
                    break;
                case HmiState.WaitingPackingBarcodeVerify:
                    if (M221Plc.ErrorCode == 0)
                    {
                        if (VerifyArticleBarcode(data))
                        {
                            M221Plc.SetHmiState(HmiState.WaitingForBigBoxEntry);
                        }
                        else
                        {
                            // var k = MessageBox.Show("Barcode un-match with current reference! Do you want to retry?", "Verify Barcode",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                            M221Plc.SetPlcUnMatchBarcodeAlarm();
                            M221Plc.SetHmiState(HmiState.WaitForRejectBinEntry);

                        }
                    }
                    break;
                    
            }
        }
        
        public bool VerifyArticleBarcode(string data)
        {
         
                return (data != "" && _thisMechineProcess.Product.ArticleNumber!= "") &&
                       data == _thisMechineProcess.Product.ArticleNumber;
        }

        public bool VerifyReferenceBarcode(string data )
        {
            if (data!="")
            {
                
                    var product = Process.GetProductReferenceByName(data);
                    if (IsNullOrWhiteSpace(product.ReferenceName)) return false;
                    _thisMechineProcess.ReferenceName = data;
                    _thisMechineProcess.ProductId = product.Id;
                    _thisMechineProcess.Product = product;
                    _thisMechineProcess.SaveOrUpdate();
                    SettingHelper.SetLastRunningProccessId(_thisMechineProcess.ProcessGuid.ToString());
                    return true;
               
            }
            return false;
        }

        public int VerifyTarget(string data)
        {
            try
            {
                return  Convert.ToInt32(data);
            }
            catch
            {
                return 0;
            }
        }
      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                M221Plc?.ResetSequenceStart();
                Xs156Client?.StopUpdater();
                _individualPrint?.CloseApp();
                _groupLabelPrint?.CloseApp();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AutoBagUser = new User();
                Text = SettingHelper.EquipmentName();
                label1.Text = Text;
            }
            finally
            {
                LoadAndInitialize();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            timerClock.Stop();
            label2.Text = DateTime.Now.ToString("F");
            RefreshDisplay();
            timerClock.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                var result = MessageBox.Show(@"Apakah anda ingin Mengakhiri Packing untuk Reference?", @"Close Reference",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);


            if (result != DialogResult.Yes) return;
            _thisMechineProcess.CompleteProcess();
            M221Plc.ResetSequenceStart();
          
            M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
            ResetAllLabel();
            _thisMechineProcess =  null;
            _thisMechineProcess = new Process() { EquipmentId = _equipment.Id };
            docPreview.Image = new Bitmap(1,1);
            docPreviewGroup.Image = new Bitmap(1, 1);
            if (_thisMechineProcess.Traceability) Xs156Client.CloseTrackingProcess();
            if (_thisMechineProcess.Traceability) Xs156Client.CompleteCurrentEquipmentProcess();
        }

        public void ResetAllLabel()
        {
            labelReject.Text = @"000";
            label1Reference.Text = "";
            lbl_Accessories.Text = AccessoriesType.UnKnown.ToString();
            lbl_GroupSize.Text = @"000";
            lbl_RemainingOfGroup.Text = @"000";
            labelFinishDateTime.Text = "";
            labelPass.Text = @"000";
            labelStartDateTime4.Text = "";
            labelProcessable.Text = @"000";
            lbl_Plasticbag.Text = BagType.UnKnown.ToString();
            labelProcessable.Text = @"000";
            tb_ErrorAlarm.Visible = false;
        }

        public void RefreshDisplay()
        {
            label1Reference.Text = _thisMechineProcess.ReferenceName;
            lbl_Accessories.Text = _thisMechineProcess.Product.AccessoriesType.ToString();
            lbl_GroupSize.Text = _groupingBox.GroupingSize.ToString("000");
            lbl_RemainingOfGroup.Text = _groupingBox.GroupRemainingQuantity.ToString("000");
            //lblPacked.Text = _groupingBox.ToString();
            labelFinishDateTime.Text = "";
          
            labelPass.Text = _groupingBox.GroupingSize >0 ? (M221Plc.OutputQuantity % _groupingBox.GroupingSize).ToString("000"): "000";//_thisMechineProcess.OutputQuantity.ToString("000");
            labelStartDateTime4.Text = _thisMechineProcess.StartDateTime.ToString("s");
            labelProcessable.Text = label1Reference.Text== Empty ? "000" : _thisMechineProcess.ProcessableQuantity.ToString("000");
            lbl_Plasticbag.Text = _thisMechineProcess.Product.BagType.ToString();// _thisMechineProcess.Product.BagType.ToString();
            labelReject.Text = M221Plc.RejectQuantity.ToString("000");//_thisMechineProcess.RejectQuantity.ToString("000");
            lbl_ArticleNumber.Text = _thisMechineProcess.Product.ArticleNumber;
            tb_ErrorAlarm.Visible = M221Plc.ErrorCode > 0;
            //btn_CloseReference.Visible = !string.IsNullOrWhiteSpace(_thisMechineProcess.Product.ReferenceName)&& !_thisMechineProcess.IsCompleted;
            lbl_orderNumber.Text = _thisMechineProcess.OrderNumber;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            M221Plc.StopUpdater();
            M221Plc.Dispose();
            BarcodeReader.Close();
        }

        private void LoadTraceAbility(bool state)
        {
            
            if (state)
            {
                checkBox1.Text = @"Traceability Active";
                checkBox1.BackColor = Color.Yellow;
                if (Xs156Client != null)
                {
                    Xs156Client.StopUpdater();
                    Xs156Client.TrackingReferenceNewlyLoaded -= TrackingNewlyLoaded;
                    Xs156Client.TrackingDataBagUpdatedEvent -= TrackingDataUpdated;
                    Xs156Client.ExceptionEvent -= Xs156Exception;
                    Xs156Client.NewReferenceTrackingEvent -= TrackingNewStartedByTester;
                }
                _reloading = true;
                M221Plc.SetHmiState(HmiState.LoadingWorkOrder);
                Xs156Client = new Xs156Client();
                Xs156Client.TrackingDataBagUpdatedEvent += TrackingDataUpdated;
                _trackingBagHandler = TrackingBagHandler;
                Xs156Client.TrackingReferenceNewlyLoaded += TrackingNewlyLoaded;
                TrackingLoaded = NewTrackingLoaded;
                Xs156Client.ExceptionEvent += Xs156Exception;
                TrackingExceptionEvent = UpdatePcMessage;
                Xs156Client.NewReferenceTrackingEvent += TrackingNewStartedByTester;
                Xs156Client.StartUpdater();
            }
            else
            {
                checkBox1.Text = @"Traceability Off";
                checkBox1.BackColor = Color.ForestGreen;

                Xs156Client?.StopUpdater();
            }
        }

        private void TrackingNewStartedByTester(string info)
        {
            MessageBox.Show(@"Tester Memulai Work Order Number Baru: " + info+@" !", @"Tester Load", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            var j = (CheckBox)sender;
            LoadTraceAbility(j.Checked);
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            M221Plc.ClearAlarm();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_PLC_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;
            M221Plc?.Show();
           
        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;
            BarcodeReader?.Show();
        }

        private void btn_GroupPrint_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
               btn_Login_Click(btn_Login,null);
            }
            if (AutoBagUser.LoggedIn)
            {
                if (_groupLabelPrint != null && !IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
                {
                    _groupLabelPrint.ActiveReference = _thisMechineProcess.Product.ReferenceName;
                    _groupLabelPrint.LoadCurrentLabel();
                    _groupLabelPrint.ShowDialog();
                }
            }
        }

        private void btn_IndividualPrint_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;
            if (M221Plc.IndividualBagLabelPrint == false)
            {
                if (_individualPrint != null && !IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
                {
                    _individualPrint.ActiveReference = _thisMechineProcess.Product.ReferenceName;
                    _individualPrint.LabelPath = _thisMechineProcess.Product.LabelFile.Trim()+".lab";
                    _individualPrint.LoadCurrentLabel();
                    _individualPrint.ShowDialog();
                    if (_individualPrint.Printed)
                    {
                        M221Plc.SetIndividualBagPrinted(true);
                    }
                }
            }
            else
            {
                UpdatePlcMessage("Plastic bag sudah di print!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;
            using (var ss = new Setting())
            {
                ss.ShowDialog();
            }          
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                timerClock.Stop();
                
                if (BarcodeReader != null)
                {
                    BarcodeReader.ClosePort();
                    BarcodeReader.Dispose();
                    BarcodeReader = null;
                    M221Plc.Disconnect();
                    M221Plc.Dispose();
                    M221Plc = null;
                }

                Reload();
                LoadTraceAbility(checkBox1.Checked);
                if (M221Plc != null)
                {
                    M221Plc.StartUpdater();
                    M221Plc.ResetSequenceStart();
                }
                UpdatePcMessage("Reset Done");
                if (M221Plc != null)
                {
                    if (_thisMechineProcess.Traceability)
                    {
                        M221Plc.SetHmiState(HmiState.WaitingNewReferenceFromServer);
                        btn_ChangeReference.Visible = false;
                        btn_CloseReference.Visible = false;
                    }
                    else
                    {
                        M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
                        btn_ChangeReference.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                timerClock.Start();
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;

            var j = MessageBox.Show(@"Apakah anda benar-benar ingin menutup semua order number?", @"Close Order Number",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (j == DialogResult.No) return;
            try
            {
                var con = $"Data Source={SettingHelper.DataBaseServer()};Initial Catalog=XS156TRAC;Persist Security Info=True;User ID=sa;Password=passwordsa;MultipleActiveResultSets=True;Max Pool Size=500";
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure,
                    "usp_CloseAllOrderNumber");
                MessageBox.Show(@"Successful");
            }
            catch
            {
                MessageBox.Show(@"Failed");
                // ignored
            }
        }
        private void btn_Reference_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;
            using (ProductReferenceList prod = new ProductReferenceList())
            {
                        prod.ShowDialog();
            }
        }

        private void btn_MuteAlarm_Click(object sender, EventArgs e)
        {
            M221Plc.MuteAlarm(true);
        }

     

        private void btn_ChangeReference_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Apakah anda ingin Mengganti Reference?", @"Change Reference",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

           
            if (result == DialogResult.Yes)
            {
               
                M221Plc.ResetSequenceStart();
                M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
                ResetAllLabel();
                _thisMechineProcess = null;
                _thisMechineProcess = new Process() { EquipmentId = _equipment.Id };
                docPreview.Image = new Bitmap(1, 1);
                docPreviewGroup.Image = new Bitmap(1, 1);                
            }
        }

        private void ShowButtons(bool show)
        {
            btn_Barcode.Visible = show;
            btn_Setting.Visible = show;
            btn_GroupPrint.Visible = show;
            btn_IndividualPrint.Visible = show;
            btn_PLC.Visible = show;
            btn_Reference.Visible = show;
            btn_Setting.Visible = show;
            btnAdjust.Visible = show;
            btnProcessableAdjust.Visible = show;
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (btn_Login.Text == @"LOG IN")
            {
                using (var form = new LoginForm())
                {
                    form.ShowDialog();
                    if (form.Result == DialogResult.OK)
                    {
                        if (AutoBagUser!=null)
                        {
                            if (AutoBagUser.Login(form.Password))
                            {
                                btn_Login.Text = @"LOG OFF";
                                btn_ChangePassword.Visible = true;
                                M221Plc?.SetMaintenanceMode();
                                ShowButtons(true);
                            }
                            else
                            {
                                MessageBox.Show( @"Password Salah!", @"Log in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }          
            }
            else
            {
                if (AutoBagUser != null)
                {
                    AutoBagUser.LogOff();
                    btn_ChangePassword.Visible = false;
                    ShowButtons(false);
                    if (M221Plc.MaintenanceMode)
                    {
                        M221Plc?.ResetMaintenanceMode();
                        btnMaintenance.Text = @"PROD MODE";
                    }
                }
                btn_Login.Text = @"LOG IN";
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            if (AutoBagUser.LoggedIn)
            {
                using (var form = new ChangePassword())
                {
                    form.ShowDialog();
                    if (form.Result == DialogResult.OK)
                    {
                        try
                        {
                            AutoBagUser.ChangePassword(form.NewPassword);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(@"Change Password", @"Gagal Mengganti Password", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        MessageBox.Show(@"Change Password", @"Password Diganti", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnLoadOrderNumber_Click(object sender, EventArgs e)
        {
            using (var frm = new OpenProcessList())
            {
                if (Xs156Client == null)
                {
                    MessageBox.Show("Error Loading Open Order Number.\r\nTraceability Inactive atau Silahkan tekan Reset");
                    return;
                }
                Xs156Client?.GetOpenProcess();
                int i;
                try
                {
                    
                    for (i = 0; i < Xs156Client?.GetOpenProcessCount(); i++)
                    {
                        Xs156Client.CurrentOpenProcess();
                        frm.dgvList.Rows.Add(Xs156Client.CurrentOpenProcessOrderNumber(),
                            Xs156Client.CurrentOpenProcessReference(), Xs156Client.CurrentOpenProcessStartDate());
                        Xs156Client.OpenProcessNext();
                    }
                    frm.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Error Loading Open Order Number.\r\nTraceability Inactive atau Silahkan tekan Reset");
                }

            }
        }

        private void chb_AutoManual_Click(object sender, EventArgs e)
        {
            
        }

        private void chb_AutoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_AutoManual.CheckState == CheckState.Unchecked)
            {
                chb_AutoManual.Text = @"AUTO";
                _manual = false;
            }
            else
            {
                if (!AutoBagUser.LoggedIn)
                {
                    btn_Login_Click(btn_Login, null);
                }
                if (!AutoBagUser.LoggedIn)
                {
                    chb_AutoManual.Checked = false;
                    return;
                }
                chb_AutoManual.Text = @"MANUAL";
                _manual = true;
                if (M221Plc.HmiState == HmiState.WaitingForProcessable)
                {
                    M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                }
            }
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            if (!AutoBagUser.LoggedIn)
            {
                btn_Login_Click(btn_Login, null);
            }
            if (!AutoBagUser.LoggedIn) return;
            if (M221Plc.MaintenanceMode)
            {
                M221Plc.ResetMaintenanceMode();
                btnMaintenance.Text = @"PROD MODE";
            }
            else
            {
                M221Plc.SetMaintenanceMode();
                btnMaintenance.Text = @"MAINT MODE";
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            using (var adj = new Adjust())
            {
                adj.ShowDialog();
                var j = adj.AdjustmentQty;
                int k;
                if (adj.ActionToTake == AdjusmentMode.Kurangi)
                {
                    k = M221Plc.OutputQuantity - j;
                    if (k < 0) k = 0;
                    M221Plc.SetOutputQuantity(k);
                }
                if (adj.ActionToTake == AdjusmentMode.Tambah)
                {
                    k = M221Plc.OutputQuantity + j;
                    //if (k > _thisMechineProcess.ProcessableQuantity) k = _thisMechineProcess.ProcessableQuantity;
                    M221Plc.SetOutputQuantity(k);
                }
            }
        }

        private void AdjustProcessable(int qty)
        {
            Xs156Setting = new Xs156Setting();
            var param = new[]
            {
                new SqlParameter("@Reference", SqlDbType.NVarChar,255) {Value = Xs156Client.GetProcessIdentity()},
                new SqlParameter("@EquipmentId", SqlDbType.NVarChar,255){Value = Xs156Setting.EquipmentIdentity()},
                new SqlParameter("@Adjustment", SqlDbType.BigInt){Value = qty},
            };
           

            try
            {
                SqlHelper.ExecuteNonQuery(SettingHelper.GetDatabaseConnection(), CommandType.StoredProcedure, "usp_UpdateProcessableQuantity", param);
                MessageBox.Show(@"Successful!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"Failed!");
            }
           
        }

        private void btnProcessableAdjust_Click(object sender, EventArgs e)
        {
            using (var dlg = new Adjust())
            {
                dlg.ShowDialog();
                switch (dlg.ActionToTake)
                {
                    case AdjusmentMode.None:
                        break;
                    case AdjusmentMode.Kurangi:
                        AdjustProcessable(-dlg.AdjustmentQty);
                        break;
                    case AdjusmentMode.Tambah:
                        AdjustProcessable(dlg.AdjustmentQty);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}