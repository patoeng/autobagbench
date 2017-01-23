using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using XS156Client35;
using XS156Client35.Models;
using DateTime = System.DateTime;


namespace AutoBagBench
{
    public partial class Form1 : Form
    {
        public Plc M221Plc;
        public BarcodeReader BarcodeReader;
        public IXs156Client Xs156Client;
        public XS156Client35.Xs156Setting Xs156Setting;

        private IndividualLabel _individualPrint;
        private GroupLabel _groupLabelPrint;
        private GroupingBox _groupingBox;
        private Image _individualRealSize;
        private Image _groupRealSize;

        private Process _thisMechineProcess;
      

        public StringDelegate delegateFunction;
        public BarcodeOrderNumberDelegate delegateFunction2;
        public StringDelegate lblRemaining;
        public StringDelegate targetReachedGroup;
        public StringDelegate NewReferenceFromTracking;
        public TrackingBagDelegate TrackingLoaded;
        public StringDelegate TrackingExceptionEvent;
        public StringDelegate M221ExceptionEvent;
        public IntDelegate M221HmiStateHandler;

        public TrackingBagDelegate trackingBagHandler;
        private Xs156Setting _xs156Setting;

        private Equipment _equipment;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void LoadAndInitialize()
        {
            try
            {
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

                _groupingBox = new GroupingBox(0);
                ReAssignGroupingEvents();
                lblRemaining = new StringDelegate(LblRemainingUpdate);
                targetReachedGroup = new StringDelegate(GroupBoxCompleted);

                _individualPrint = new IndividualLabel() { LabelPath = "" };
                _groupLabelPrint = new GroupLabel();

                _equipment = new Equipment()
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

                delegateFunction += PlcDataUpdated;
                delegateFunction2 += BarcodeScanned;
                M221Plc.SetOutputQuantity(0);
                M221Plc.SetRejectQuantity(0);
                M221Plc.SetHmiState(HmiState.NoState);
                M221Plc.SetPlcMode(PlcMode.Auto);

                M221Plc.StartUpdater();

                checkBox1.Checked = _thisMechineProcess.Traceability;

                if (!checkBox1.Checked)
                {
                    var lastRunning = new Guid(SettingHelper.LastRunningProccessId());
                    if (lastRunning != Guid.Empty){
                        _thisMechineProcess.ProcessGuid = lastRunning;
                        _thisMechineProcess.ReloadLastRunning(lastRunning.ToString());
                        if (!String.IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
                        {
                            M221Plc.SetOutputQuantity(_thisMechineProcess.OutputQuantity);
                            ReloadReference(_thisMechineProcess.ReferenceName, _thisMechineProcess.Target);
                            M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                           
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
            if (_individualPrint != null)
            {
                _individualPrint.CloseApp();
            }
            if (_groupLabelPrint != null)
            {
                _groupLabelPrint.CloseApp();
                
            }
            _individualPrint = new IndividualLabel() { LabelPath = "" };
            _groupLabelPrint = new GroupLabel();

            _groupingBox = new GroupingBox(0);
            ReAssignGroupingEvents();
            lblRemaining = new StringDelegate(LblRemainingUpdate);
            targetReachedGroup = new StringDelegate(GroupBoxCompleted);

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

            M221ExceptionEvent = new StringDelegate(M221_ErrorHandler);
            M221HmiStateHandler = M221_HmiStateHandler;


            delegateFunction = PlcDataUpdated;
            delegateFunction2 = BarcodeScanned;

           
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
                    if (!String.IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
                    {
                        M221Plc.SetOutputQuantity(_thisMechineProcess.OutputQuantity);
                        ReloadReference(_thisMechineProcess.ReferenceName, _thisMechineProcess.Target);
                        M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                    }

                }
           }

            M221Plc.StartUpdater();
            timerClock.Start();
        }
        private void M221_ErrorMessage(Error data)
        {
            var j = "Error:" + data.Code+ ": " + data.Message;
            Invoke(new StringDelegate(M221ExceptionEvent), new object[] { j });
        }

        private void M221_ErrorHandler(string data)
        {
            UpdatePlcMessage(data);
            tb_ErrorAlarm.Visible = true;
            tb_ErrorAlarm.Text = data;
            if (!data.Contains("Error:1000"))
            {
                MessageBox.Show(data, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void GroupRemainingChanged(int data)
        {
            Invoke(new StringDelegate(lblRemaining), new object[] {data.ToString()});
        }

        public void LblRemainingUpdate(string data)
        {
            lbl_RemainingOfGroup.Text = data;
        }
        private void GroupTargetIsReached(int data)
        {
            Invoke(new StringDelegate(targetReachedGroup), new object[] { data.ToString() });
        }
        public void GroupBoxCompleted(string data)
        {
            PrintGroup();
        }

        private void ReAssignGroupingEvents()
        {
            _groupingBox.GroupingTargetReachedEvent +=  GroupTargetIsReached;
            _groupingBox.GroupingRemainingChangedEvent += GroupRemainingChanged;
        }

        private void NewTrackingLoaded(TrackingDataBag track)
        {
            M221Plc.SetHmiState(HmiState.NoState);
            Xs156Client.StopUpdater();
            if (!Xs156Client.IsBufferedMode())
            {
                Xs156Client.Reload();
                btn_ChangeReference.Visible = false;
                btn_CloseReference.Visible = false;
            }
            else
            {
                btn_ChangeReference.Visible = true;
                //btn_CloseReference.Visible = true;
            }
            M221Plc.SetOutputQuantity(0);
            M221Plc.SetRejectQuantity(0);
            docPreview.Image = new Bitmap(1, 1);
            docPreviewGroup.Image = new Bitmap(1, 1);

            _thisMechineProcess = new Process
            {
                EquipmentId = new Guid(Xs156Client.ThisEquipment().Id.ToString()),
                ProcessGuid = new Guid(Xs156Client.ThisEquipmentReferenceProcess().ReferenceProcess.ToString()),
                Traceability = SettingHelper.Traceability(),
                StartDateTime =DateTime.Parse(track.StartDateTime),
                OrderNumber = track.OrderNumber
            };
            if (VerifyReferenceBarcode(track.CurrentReferenceName))
            {
                _groupingBox = new GroupingBox(_thisMechineProcess.Product.GroupingSize)
                {
                    ProcessGuid = new Guid(track.TrackingIdentity)
                };
                _thisMechineProcess.ReferenceName = track.CurrentReferenceName;
                ReAssignGroupingEvents();
            }
            else
            {
                M221Plc.SetHmiState(HmiState.WaitingNewReferenceFromServer);
                UpdatePlcMessage("Reference verification failed");
                return;
            }
          

            M221Plc.SetOutputQuantity(track.OutputQuantity);
            M221Plc.SetRejectQuantity(track.RejectedQuantity);
            M221Plc.SetTargetTarget(track.TargetQuantity);
            M221Plc.SetAccessories(_thisMechineProcess.Product.AccessoriesType);
            Xs156Client.StartUpdater();
            M221Plc.SetHmiState(HmiState.WaitingForProcessable);
           

        }

        private void TrackingNewlyLoaded(TrackingDataBag data)
        {
            Invoke(new TrackingBagDelegate(TrackingLoaded), new object[] { data });
        }

        private void Xs156Exception(string info)
        {
         //   Invoke(new StringDelegate(TrackingExceptionEvent), new object[] { info });
            MessageBox.Show(info, "Traceability",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

       

        private void TrackingBagHandler(TrackingDataBag track)
        {
            lbl_ProcessId.Text = track.TrackingIdentity;
            lbl_EquipmentId.Text = track.EquipmentIdentity;
            lbl_LineGroup.Text = track.LineGroupName;
            lbl_ReferenceTraceability.Text = track.CurrentReferenceName;
            lmpTraceability.BackColor = lmpTraceability.BackColor == Color.Yellow ? Color.YellowGreen : Color.Yellow;

            _thisMechineProcess.ProcessableQuantity = track.ProcessableQuantity;
            if (M221Plc.HmiState == HmiState.WaitingForProcessable)
            {
                if (_thisMechineProcess.ProcessableQuantity > _thisMechineProcess.OutputQuantity)
                {
                    M221Plc.SetHmiState(HmiState.WaitingForAccessories);
                }
            }
            /*_thisMechineProcess.Product.Id = new  Guid(track.CurrentReference);
            _thisMechineProcess.ProductId = new Guid(track.CurrentReference);
            _thisMechineProcess.Product.ReferenceName = track.CurrentReferenceName;
            _thisMechineProcess.ProcessGuid =  new Guid(track.TrackingIdentity);*/
        }

        private void TrackingDataUpdated(TrackingDataBag track)
        {
            Invoke(new TrackingBagDelegate(trackingBagHandler), new object[] {track});
        }

      
        private void BarcodeRead(string data,string ordernumber)
        {
            Invoke(new BarcodeOrderNumberDelegate(delegateFunction2), new object[] {data, ordernumber});
        }

        private void M221Plc_PlcUpdated()
        {
            try
            {
                Invoke(new StringDelegate(delegateFunction), new object[] {M221Plc.HmiState.ToString()});
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void M221_OutputChanged(int data)
        {if (!String.IsNullOrWhiteSpace(_thisMechineProcess.Product.ReferenceName))
            _thisMechineProcess.SetOutputQuantity(data);
            _groupingBox.ParseFromTotalOutput(data);
           if(checkBox1.Checked)  Xs156Client.SetOutputQuantity(data);
        }

        private void PrintIndividual()
        {
            try

            {
                _individualPrint.ActiveReference=_thisMechineProcess.Product.ReferenceName;
                _individualPrint.LabelPath = "XS156.lab";
                _individualPrint.LoadCurrentLabel();
                _individualRealSize =(Image) _individualPrint.RealSizeImage.Clone();
                docPreview.Image = _individualRealSize;
                   docPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                _individualPrint.Print();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Ind Label:  "+ ex.Message);
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
                    if (_thisMechineProcess.Traceability)
                    {
                        if (Xs156Client.GetProcessableQuantity() > _thisMechineProcess.OutputQuantity)
                        {
                            PrintIndividual();
                            UpdatePcMessage("Masukkan Sensor & Accessories ke plastic Bag");
                        }
                        else
                        {
                            M221Plc.SetHmiState(HmiState.WaitingForProcessable);
                        }
                    }
                    else
                    {
                        PrintIndividual();
                        UpdatePcMessage("Masukkan Sensor & Accessories ke plastic Bag");
                    }
                    break;
                case HmiState.WaitingForSealer:
                    UpdatePcMessage("Activekan Sealer!");
                    break;
                case HmiState.WaitForRejectBinEntry:
                    UpdatePcMessage("Masukkan Plastic Bag ke Reject Bin");
                    break;
                case HmiState.WaitingForBigBoxEntry:
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
            _thisMechineProcess.SetRejectQuantity(data);
            if (checkBox1.Checked) Xs156Client.SetRejectQuantity(data);
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

        private void ReloadReference(string reference, int target)
        {
            if (VerifyReferenceBarcode(reference))
            {
                
                _groupingBox = new GroupingBox(_thisMechineProcess.Product.GroupingSize)
                {
                    ProcessGuid = _thisMechineProcess.ProcessGuid
                };
                ReAssignGroupingEvents();
                M221Plc.SetAccessories(_thisMechineProcess.Product.AccessoriesType);
                M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
            }
            else
            {
                UpdatePlcMessage("Reference verification failed");
               
                return;
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
                            _groupingBox = new GroupingBox(_thisMechineProcess.Product.GroupingSize)
                            {
                                ProcessGuid = _thisMechineProcess.ProcessGuid
                            };
                            ReAssignGroupingEvents();
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
                                MessageBox.Show(exception.Message, "Traceability");
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
                        M221Plc.SetRejectQuantity(0);
                        M221Plc.SetOutputQuantity(0);
                        _thisMechineProcess.ProcessGuid = Guid.NewGuid();
                    }
                    else
                    {
                        UpdatePlcMessage("Target Entry verification failed.");
                    }
                    break;
                case HmiState.WaitingPackingBarcodeVerify:
                    if (VerifyArticleBarcode(data))
                    {
                        M221Plc.SetHmiState(HmiState.WaitingForBigBoxEntry);
                    }
                    else
                    {
                        var k = MessageBox.Show("Barcode un-match with current reference! Do you want to retry?", "Verify Barcode",MessageBoxButtons.YesNo);
                        if (k == DialogResult.No)
                        {
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
                    if (String.IsNullOrWhiteSpace(product.ReferenceName)) return false;
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
                if (M221Plc != null)
                {
                    M221Plc.ResetAll();
                }
                if (Xs156Client != null)
                {
                    Xs156Client.StopUpdater();
                }
                if (_individualPrint != null)
                {
                    _individualPrint.CloseApp();
                }
                if (_groupLabelPrint != null)
                {
                    _groupLabelPrint.CloseApp();
                }
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
            label2.Text = DateTime.Now.ToString("F");
            RefreshDisplay();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                var result = MessageBox.Show("Apakah anda ingin Mengakhiri Packing untuk Reference?", "Close Reference",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);

             

                if (result == DialogResult.Yes)
                {
                    _groupingBox = new GroupingBox(0);
                    ReAssignGroupingEvents();
                    _thisMechineProcess.CompleteProcess();
                    M221Plc.ResetAll();
                    M221Plc.SetOutputQuantity(0);
                    M221Plc.SetRejectQuantity(0);
                    M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
                    ResetAllLabel();
                    _thisMechineProcess =  null;
                    _thisMechineProcess = new Process() { EquipmentId = _equipment.Id };
                    docPreview.Image = new Bitmap(1,1);
                    docPreviewGroup.Image = new Bitmap(1, 1);

                    if (_thisMechineProcess.Traceability) Xs156Client.CompleteCurrentEquipmentProcess();
                }
        }

        public void ResetAllLabel()
        {
            labelReject.Text = "000";
            label1Reference.Text = "";
            lbl_Accessories.Text = AccessoriesType.UnKnown.ToString();
            lbl_GroupSize.Text = "000";
            lbl_RemainingOfGroup.Text = "000";
            labelFinishDateTime.Text = "";
            labelPass.Text = "000";
            labelStartDateTime4.Text = "";
            labelProcessable.Text = "000";
            lbl_Plasticbag.Text = BagType.UnKnown.ToString();
            labelProcessable.Text = "000";
            tb_ErrorAlarm.Visible = false;
        }

        public void RefreshDisplay()
        {
            label1Reference.Text = _thisMechineProcess.ReferenceName;
            lbl_Accessories.Text = _thisMechineProcess.Product.AccessoriesType.ToString();
            lbl_GroupSize.Text = _groupingBox.GroupingSize.ToString("000");
            lbl_RemainingOfGroup.Text = _groupingBox.GroupRemainingQuantity.ToString("000");
            labelFinishDateTime.Text = "";
            labelPass.Text = _thisMechineProcess.OutputQuantity.ToString("000");
            labelStartDateTime4.Text = _thisMechineProcess.StartDateTime.ToString("s");
            labelProcessable.Text = _thisMechineProcess.ProcessableQuantity.ToString("000");
            lbl_Plasticbag.Text = _thisMechineProcess.Product.BagType.ToString();
            labelReject.Text = _thisMechineProcess.RejectQuantity.ToString("000");
            labelProcessable.Text = _thisMechineProcess.ProcessableQuantity.ToString("000");
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
                checkBox1.Text = "Traceability Active";
                checkBox1.BackColor = Color.Yellow;
                if (Xs156Client != null)
                {
                    Xs156Client.StopUpdater();
                    Xs156Client.TrackingReferenceNewlyLoaded -= new TrackingDataBagUpdated(TrackingNewlyLoaded);
                    Xs156Client.TrackingDataBagUpdatedEvent -= new TrackingDataBagUpdated(TrackingDataUpdated);
                    Xs156Client.ExceptionEvent -= new MyEventHandlerWithInfo(Xs156Exception);
                }
                Xs156Client = new Xs156Client();
                Xs156Client.TrackingDataBagUpdatedEvent += new TrackingDataBagUpdated(TrackingDataUpdated);
                trackingBagHandler = new TrackingBagDelegate(TrackingBagHandler);
                Xs156Client.TrackingReferenceNewlyLoaded += new TrackingDataBagUpdated(TrackingNewlyLoaded);
                TrackingLoaded = new TrackingBagDelegate(NewTrackingLoaded);
                Xs156Client.ExceptionEvent += new MyEventHandlerWithInfo(Xs156Exception);
                TrackingExceptionEvent = new StringDelegate(UpdatePcMessage);
                Xs156Client.StartUpdater();

            }
            else
            {
                checkBox1.Text = "Traceability Off";
                checkBox1.BackColor = Color.ForestGreen;

                if (Xs156Client == null) return;
                M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
                Xs156Client.StopUpdater();
            }
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
            if (M221Plc != null)
            {
                M221Plc.Show();
            }
        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            if (BarcodeReader != null)
            {
                BarcodeReader.Show();
            }
        }

        private void btn_GroupPrint_Click(object sender, EventArgs e)
        {
            if (_groupLabelPrint != null && !String.IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
            {
                _groupLabelPrint.ActiveReference = _thisMechineProcess.Product.ReferenceName;
                _groupLabelPrint.LoadCurrentLabel();
                _groupLabelPrint.ShowDialog();
            }
        }

        private void btn_IndividualPrint_Click(object sender, EventArgs e)
        {
            if (_individualPrint != null && !String.IsNullOrWhiteSpace(_thisMechineProcess.ReferenceName))
            {
                _individualPrint.ActiveReference = _thisMechineProcess.Product.ReferenceName;
                _individualPrint.LabelPath = "XS156.lab";
                _individualPrint.LoadCurrentLabel();
                _individualPrint.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Setting ss = new Setting())
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
                    M221Plc.ResetAll();
                }
                UpdatePcMessage("Reset Done");
                if (M221Plc != null)
                {
                    if (_thisMechineProcess.Traceability&& !Xs156Client.IsBufferedMode())
                    {
                        M221Plc.SetHmiState(HmiState.WaitingNewReferenceFromServer);
                        btn_ChangeReference.Visible = false;
                        btn_CloseReference.Visible = false;
                    }
                    else
                    {
                        M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
                        btn_ChangeReference.Visible = true;
                        //btn_CloseReference.Visible = true;
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
            try
            {
                timerClock.Stop();
                LoadTraceAbility(checkBox1.Checked);
            }
            finally
            {
                timerClock.Start();
            }
        }
        private void btn_Reference_Click(object sender, EventArgs e)
        {
            using (ProductReferenceList prod = new ProductReferenceList())
            {
                prod.ShowDialog();
            }
        }

        private void btn_MuteAlarm_Click(object sender, EventArgs e)
        {
            M221Plc.MuteAlarm(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _individualPrint.LabelPath = "BagType6X8";
            _individualPrint.ActiveReference = "XS608B1NAL5";
        }

        private void btn_ChangeReference_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Apakah anda ingin Mengganti Reference?", "Change Reference",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            _groupingBox = new GroupingBox(0);
            ReAssignGroupingEvents();

            if (result == DialogResult.Yes)
            {
               
                M221Plc.ResetAll();
                M221Plc.SetOutputQuantity(0);
                M221Plc.SetRejectQuantity(0);
                M221Plc.SetHmiState(HmiState.ReadyAndWaitForNewReference);
                ResetAllLabel();
                _thisMechineProcess = null;
                _thisMechineProcess = new Process() { EquipmentId = _equipment.Id };
                docPreview.Image = new Bitmap(1, 1);
                docPreviewGroup.Image = new Bitmap(1, 1);

                
            }
        }

    }
}
