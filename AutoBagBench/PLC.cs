using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusTCP;
using Xs156AutoBagPLC.Helper;

namespace AutoBagBench
{
    public partial class Plc : Form
    {
        private readonly Master _master;
        public event ErrorEvent PlcErrorEvent;
        public event IntParamEvent PlcOutputChanged;
        public event IntParamEvent PlcRejectChanged;
        public event IntParamEvent HmiStateChanged;
        public event NoParamDelegate DataUpdated;

        public Plc()
        {
           
            InitializeComponent();
            try
            {
                _master = new Master();
                tm_Updater.Interval = SettingHelper.PlcReadInterval();
                ConnectToPlc();
            }
            catch (Exception ex)
            {
                
            }

        }
        
        private void PLC_Load(object sender, EventArgs e)
        {
            lbl_PlcAddress.Text = SettingHelper.PlcIpAddress();
            lbl_Port.Text = ": " + SettingHelper.PlcPort();
        }
        public bool EmergencySwitch { get; protected set; } //MW20:X0
        public bool AccessoriesSensorM8 { get; protected set; }//MW20:X1
        public bool AccessoriesSensorM12 { get; protected set; }//MW20:X2
        public bool AccessoriesSensorM18 { get; protected set; }//MW20:X3
        public bool AccessoriesSensorM30 { get; protected set; }//MW20:X4

        public bool RejectBinSensor { get; protected set; }//MW20:X5
        public bool BagThroughBoxSensor { get; protected set; }//MW20:X6
        public bool ProductThroughBagSensor { get; protected set; }//MW20:X7

        public bool AccessoriesM8DoorOpenSensor { get; protected set; }//MW20:X8
        public bool AccessoriesM8DoorCloseSensor { get; protected set; }//MW20:X9
        public bool AccessoriesM12DoorOpenSensor { get; protected set; }//MW20:X10
        public bool AccessoriesM12DoorCloseSensor { get; protected set; }//MW20:X11
        public bool AccessoriesM18DoorOpenSensor { get; protected set; }//MW20:X12
        public bool AccessoriesM18DoorCloseSensor { get; protected set; }//MW20:X13
        public bool AccessoriesM30DoorOpenSensor { get; protected set; }//MW20:X14
        public bool AccessoriesM30DoorCloseSensor { get; protected set; }//MW20:X15

        public bool FingerSwitchLeft { get; protected set; }//MW21:X0
        public bool FingerSwitchRight { get; protected set; }//MW21:X1

        public bool AccessoriesBoxM8Selected { get; protected set; }//MW22:X0
        public bool AccessoriesBoxM12Selected { get; protected set; }//MW22:X1
        public bool AccessoriesBoxM18Selected { get; protected set; }//MW22:X2
        public bool AccessoriesBoxM30Selected { get; protected set; }//MW22:X3
        public bool SealerTrigerrer { get; protected set; }//MW22:X4
        public bool Buzzer { get; protected set; }//MW22:X5
        public bool AccessoriesBoxM8GateOpen { get; protected set; }//MW22:X6
        public bool AccessoriesBoxM12GateOpen { get; protected set; }//MW22:X7
        public bool AccessoriesBoxM18GateOpen { get; protected set; }//MW22:X8
        public bool AccessoriesBoxM30GateOpen { get; protected set; }//MW22:X9

        public HmiState HmiState { get; protected set; }
        public PlcMode PlcMode { get; protected set; }
        public int ErrorCode { get; protected set; }
        public int OutputQuantity { get; protected set; }
        public int RejectQuantity { get; protected set; }
        public int TargetQuantity { get; protected set; }
        private int[] _data;
        private void tm_Updater_Tick(object sender, EventArgs e)
        {
            try
            {
                byte[] temp = new byte[] {};
                tm_Updater.Stop();
                PlcCommandHelper.GetPlcRawData(_master, 25,ref temp);
                _data = ModbusTcpHelper.ByteArrayToWordArray(temp);
                MemoryMapping(_data);
                if (DataUpdated != null) DataUpdated();
            }
            finally 
            {
                tm_Updater.Start();
            }
        }

        private int _output;
        private int _reject;
        private int _error;
        private void LoadOutput(int data)
        {
            OutputQuantity = data;
            if (_output != data)
            {
                if (PlcOutputChanged != null) PlcOutputChanged(data);
                _output = data;
            }
        }

        private void LoadReject(int data)
        {
            RejectQuantity = data;
            if (_reject != data)
            {
                if (PlcRejectChanged != null) PlcRejectChanged(data);
                _reject = data;
            }
        }

        private void LoadError(int data)
        {
            ErrorCode = data;
            if (_error != data)
            {
                var j = new Error()
                {
                    Code = data + 1000,
                    Message = PlcErrorMessage.Message(data)
                };
                if (PlcErrorEvent != null) PlcErrorEvent(j);
                _error = data;
            }

        }
        private void LoadHmiState(HmiState data)
        {
            if (HmiState != data)
            {
                if (HmiStateChanged != null) HmiStateChanged((int)data);
            }
            HmiState = data;
        }
        private void MemoryMapping(int[] data)
        {
            LoadOutput(data[9]);
            LoadReject(data[7]);
            TargetQuantity = data[11];
            LoadError(data[4]);
            LoadHmiState((HmiState) data[0]);
            PlcMode = (PlcMode) data[2];
            InputMapping(data[20], data[21]);
            OutputMapping(data[23]);
        }

        private void InputMapping(int data,int data2)
        {
            EmergencySwitch = (data & 0x01) == 0x01;
            AccessoriesSensorM8 =  (data>>1 & 0x01) == 0x01;
            AccessoriesSensorM12 = (data >> 2 & 0x01) == 0x01;
            AccessoriesSensorM18 = (data >> 3 & 0x01) == 0x01;
            AccessoriesSensorM30 = (data >> 4 & 0x01) == 0x01;

            RejectBinSensor = (data >> 5 & 0x01) == 0x01;
            BagThroughBoxSensor = (data >> 6 & 0x01) == 0x01;
            ProductThroughBagSensor = (data >> 7 & 0x01) == 0x01;

            AccessoriesM8DoorOpenSensor = (data >> 8 & 0x01) == 0x01;
            AccessoriesM8DoorCloseSensor = (data >> 9 & 0x01) == 0x01;
            AccessoriesM12DoorOpenSensor= (data >> 10 & 0x01) == 0x01;
            AccessoriesM12DoorCloseSensor= (data >> 11 & 0x01) == 0x01;
            AccessoriesM18DoorOpenSensor= (data >> 12 & 0x01) == 0x01;
            AccessoriesM18DoorCloseSensor= (data >> 13 & 0x01) == 0x01;
            AccessoriesM30DoorOpenSensor= (data >> 14 & 0x01) == 0x01;
            AccessoriesM30DoorCloseSensor = (data >> 15 & 0x01) == 0x01;

            FingerSwitchLeft = (data2 & 0x01) == 0x01;
            FingerSwitchRight= (data2>>1 & 0x01) == 0x01;
         
        }

        private void OutputMapping(int data)
        {
            AccessoriesBoxM8Selected = (data & 0x01) == 0x01;
            AccessoriesBoxM12Selected = (data>>1 & 0x01) == 0x01;
            AccessoriesBoxM18Selected= (data>>2 & 0x01) == 0x01;
            AccessoriesBoxM30Selected= (data>>3 & 0x01) == 0x01;
            SealerTrigerrer = (data >> 4 & 0x01) == 0x01;
            Buzzer = (data >> 5 & 0x01) == 0x01;
            AccessoriesBoxM8GateOpen = (data >> 6 & 0x01) == 0x01;
            AccessoriesBoxM12GateOpen = (data >> 7 & 0x01) == 0x01;
            AccessoriesBoxM18GateOpen = (data >> 8 & 0x01) == 0x01;
            AccessoriesBoxM30GateOpen = (data >> 9 & 0x01) == 0x01;
        }

        private void chb_C_M8_Selected_Lamp_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriesM8Lamp(_master, ! AccessoriesBoxM8Selected);
        }

        private void chb_C_M12_Selected_Lamp_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriesM12Lamp(_master, ! AccessoriesBoxM12Selected);
        }

        private void chb_C_M18_Selected_Lamp_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriesM18Lamp(_master, ! AccessoriesBoxM18Selected);

        }

        private void chb_C_M30_Selected_Lamp_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriesM30Lamp(_master, !AccessoriesBoxM30Selected);
        }

        private void chb_C_Sealer_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetTriggerSealer(_master, !SealerTrigerrer);
        }

        private void chb_C_Buzzer_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetBuzzer(_master, !Buzzer);
        }

        private void chb_C_M8_Gate_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriessM8GateOpen(_master, !AccessoriesBoxM8GateOpen);
        }

        private void chb_C_M12_Gate_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriessM12GateOpen(_master, !AccessoriesBoxM12GateOpen);
        }

        private void chb_C_M18_Gate_CheckedChanged(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriessM18GateOpen(_master, !AccessoriesBoxM18GateOpen);
        }
     
        private void chb_C_M30_Gate_CheckedChanged_1(object sender, EventArgs e)
        {
            PlcCommandHelper.SetAccessoriessM30GateOpen(_master, !AccessoriesBoxM30GateOpen);
        }

        private void tm_DisplayUpdater_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                UpdateDisplay();
            }
        }

        private Color OnColor = Color.Yellow;
        private Color OffColor = Color.YellowGreen;
        private void UpdateDisplay()
        {
            chb_EmergencySwitch.BackColor = EmergencySwitch ? OnColor : OffColor;
            chb_M8Sensor.BackColor = AccessoriesSensorM8 ? OnColor : OffColor;
            chb_M12Sensor.BackColor = AccessoriesSensorM12 ? OnColor : OffColor;
            chb_M18Sensor.BackColor = AccessoriesSensorM18 ? OnColor : OffColor;
            chb_M30Sensor.BackColor = AccessoriesSensorM30 ? OnColor : OffColor;

            chb_RejectBin.BackColor = RejectBinSensor? OnColor : OffColor;
            chb_ThroughBox.BackColor = BagThroughBoxSensor ? OnColor : OffColor;
            chb_ThroughBag.BackColor = ProductThroughBagSensor ? OnColor : OffColor;
            chb_M8OpenSens.BackColor = AccessoriesM8DoorOpenSensor ? OnColor : OffColor;
            chb_M8CloseSens.BackColor = AccessoriesM8DoorCloseSensor ? OnColor : OffColor;
            chb_M12OpenSens.BackColor = AccessoriesM12DoorOpenSensor ? OnColor : OffColor;
            chb_M12CloseSens.BackColor = AccessoriesM12DoorCloseSensor ? OnColor : OffColor;
            chb_M18OpenSens.BackColor = AccessoriesM18DoorOpenSensor ? OnColor : OffColor;
            chb_M18CloseSens.BackColor = AccessoriesM18DoorCloseSensor ? OnColor : OffColor;
            chb_M30OpenSens.BackColor = AccessoriesM30DoorOpenSensor ? OnColor : OffColor;
            chb_M30CloseSens.BackColor = AccessoriesM30DoorCloseSensor ? OnColor : OffColor;

            chb_FingerLeft.BackColor = FingerSwitchLeft ? OnColor : OffColor;
            chb_FingerRight.BackColor = FingerSwitchRight ? OnColor : OffColor;

            //output
            chb_M8Selected.BackColor = AccessoriesBoxM8Selected ? OnColor : OffColor;
            chb_M12Selected.BackColor = AccessoriesBoxM12Selected ? OnColor : OffColor;
            chb_M18Selected.BackColor = AccessoriesBoxM18Selected ? OnColor : OffColor;
            chb_M30Selected.BackColor = AccessoriesBoxM30Selected ? OnColor : OffColor;
            chb_Sealer.BackColor = SealerTrigerrer ? OnColor : OffColor;
            chb_Buzzer.BackColor = Buzzer ? OnColor : OffColor;
            chb_M8Gate.BackColor = AccessoriesBoxM8GateOpen ? OnColor : OffColor;
            chb_M12Gate.BackColor = AccessoriesBoxM12GateOpen ? OnColor : OffColor;
            chb_M18Gate.BackColor = AccessoriesBoxM18GateOpen ? OnColor : OffColor;
            chb_M30Gate.BackColor = AccessoriesBoxM30GateOpen ? OnColor : OffColor;

           // tambah lai
            btn_AutoManual.Text = PlcMode.ToString();
        }

        public bool ConnectToPlc()
        {

            try
            {
                _master.connect(SettingHelper.PlcIpAddress(),
                    (ushort) SettingHelper.PlcPort());
                tm_Updater.Start();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public bool Connected()
        {
            return _master.connected;
        }

        public void StartUpdater()
        {if (Connected())
            tm_Updater.Start();
        }

        public void StopUpdater()
        {
            tm_Updater.Stop();
        }
        public void SetHmiState(HmiState hmiState)
        {
            PlcCommandHelper.TellPlcHmiState(_master, hmiState);
        }

        public void SetOutputQuantity(int data)
        {
            PlcCommandHelper.SetOutputQty(_master, data);
        }
        public void SetRejectQuantity(int data)
        {
            PlcCommandHelper.SetRejectQty(_master, data);
        }
        public void SetTargetTarget(int data)
        {
            PlcCommandHelper.SetTargetQty(_master, data);
        }
        public void SetAccessories(AccessoriesType data)
        {
            PlcCommandHelper.SetAccessories(_master, data);
        }

        public void SetBagType(BagType data)
        {
            PlcCommandHelper.SetBagType(_master, data);
        }

        public void IncreaseOutputQty(int deltaQty)
        {
            PlcCommandHelper.IncreaseOutputQty(_master, deltaQty);
        }
        public void DecreaseOutputQty(int deltaQty)
        {
            PlcCommandHelper.DecreaseOutputQty(_master, deltaQty);
        }

        public void SetEnableTraceability(bool data)
        {
            PlcCommandHelper.EnableTraceabilityMode(_master, data);
        }
        public void SetPlcMode(PlcMode data)
        {
            PlcCommandHelper.SetPlcMode(_master, data);
        }

        public void ClearAlarm()
        {
            PlcCommandHelper.ResetError(_master);
        }
        public void MuteAlarm(bool data)
        {
            PlcCommandHelper.MuteAlarm(_master,data);
        }

        private void Plc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void ResetAll()
        {
            PlcCommandHelper.ResetSequence(_master);
        }

        public void Disconnect()
        {
            _master.disconnect();
            tm_Updater.Stop();
        }
        public void Connect()
        {
          
            tm_Updater.Start();
        }

        private void btn_AutoManual_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;
            switch (b.Text)
            {
                case "None": PlcCommandHelper.SetPlcMode(_master,PlcMode.Auto);
                    break;
                case "Auto": PlcCommandHelper.SetPlcMode(_master, PlcMode.Debug);
                    break;
                case "Debug": PlcCommandHelper.SetPlcMode(_master, PlcMode.Auto);
                    break;
            }
        }

        public void SetPlcUnMatchBarcodeAlarm()
        {
            PlcCommandHelper.SetPlcUnMatchBarcodeAlarm(_master);
        }
    }
}
