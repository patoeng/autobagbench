using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBagBench
{
    public partial class BarcodeReader : Form
    {
        public event BarcodeOrderNumberDelegate DataBarcodeReadOk;
       

        private StringFunctionDelegate _serialDataRecievedDelegate;
        public BarcodeReader()
        {
            InitializeComponent();
            Init();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_Read.Clear();
        }

        private void Init()
        {
            SerialPortBarcode.DataReceived += new SerialDataReceivedEventHandler(EventHandlerSerialPort);
            _serialDataRecievedDelegate = new StringFunctionDelegate(BarcodeRead);
            try
            {
                SerialPortBarcode.PortName = SettingHelper.BarcodeReaderComName();
                SerialPortBarcode.BaudRate = SettingHelper.BarcodeReaderBaudRate();
            }
            catch (Exception ex)
            {

            }
        }

        private void BarcodeRead(string data)
        {
            if (Visible)
            {
                tb_Read.Text = data;
            }
            DataReadOk = data;
            string reference="";
            string ordernumber="";
            if (ParseBarcode(data,ref reference, ref ordernumber))
            if (DataBarcodeReadOk != null) DataBarcodeReadOk(reference,ordernumber);
        }

        private bool ParseBarcode(string data, ref string reference, ref string ordernumber)
        {
            data = data.Trim('\r', '\n');
            if (data.Length==23)
            {
                reference = data.Substring(0, 15).Trim().ToUpper();
                ordernumber = data.Substring(15, 8).Trim();
                return true;
            }

            if (data.Length == 13)
            {
                reference = data;
                ordernumber = "";
                return true;
            }
            return false;
        }
        private string _temp;
        public string DataReadOk;

        private void EventHandlerSerialPort(object sender, SerialDataReceivedEventArgs e)
        {
            _temp += SerialPortBarcode.ReadExisting();
            if (_temp.Contains("\r"))
            {
                if (InvokeRequired)
                {
                    Invoke(new StringFunctionDelegate(_serialDataRecievedDelegate), new object[] {_temp});
                }
                else
                {
                    BarcodeRead(_temp);
                }
                _temp = "";
            }
        }

        private void btn_OpenClosePort_Click(object sender, EventArgs e)
        {
            if (SerialPortBarcode.IsOpen)
            {
                SerialPortBarcode.Close();
            }
            else
            {
                SerialPortBarcode.Open();
            }
            btn_OpenClosePort.Text = SerialPortBarcode.IsOpen ? "Close Port" : "Open Port";
        }

        private void BarcodeReader_Load(object sender, EventArgs e)
        {
            btn_OpenClosePort.Text = SerialPortBarcode.IsOpen ? "Close Port" : "Open Port";
            lbl_BaudRate.Text = SettingHelper.BarcodeReaderBaudRate().ToString();
            lbl_ComName.Text = SettingHelper.BarcodeReaderComName();
        }

        public bool IsOpen()
        {
            return SerialPortBarcode.IsOpen;
        }

        public void OpenPort()
        {
            if (!SerialPortBarcode.IsOpen)
            {
                try
                {
                    SerialPortBarcode.Open();
                }
                catch (Exception exception)
                {
                    if (Visible)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }
        public void ClosePort()
        {
            if (SerialPortBarcode.IsOpen) 
            {
                try
                {
                    SerialPortBarcode.Close();
                }
                catch (Exception exception)
                {
                    if (Visible)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void BarcodeReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
