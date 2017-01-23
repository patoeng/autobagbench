using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AutoBagBench
{
    public partial class Setting : Form
    {
        private SettingClass _setting;
        public Setting()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_GenerateNewID_Click(object sender, EventArgs e)
        {
            var newId = Guid.NewGuid();
            tb_Identity.Text = newId.ToString();
        }

        private void btn_OpenLabelPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tb_LabelGroupPath.Text = fbd.SelectedPath;
            }
        }

        private void btn_OpenLabelImagePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tb_LabelGroupImagePath.Text = fbd.SelectedPath;
            }
        }

     

        private void Setting_Load(object sender, EventArgs e)
        {
            _setting = new SettingClass();
            ListAllSerialPort();
            ListAllbaudRate();
            ListIndividualPrinter();
            ListGroupPrinter();
            LoadSetting();
        }

        private  void LoadSetting()
        {
            if (_setting != null)
            {
               tb_Identity.Text = _setting.EquipmentIdentity(Guid.NewGuid().ToString());
               tb_EquipmentName .Text =   _setting.EquipmentName("AutoBag");
               chb_Traceability.Checked =  _setting.TraceAbility(true);

               tb_DataBaseServer.Text = _setting.DataBaseServer("127.0.0.1");
               tb_DataBaseCatalogue.Text = _setting.DataBaseCatalogue("XS156AutoBag");

               tb_PLCAddress.Text = _setting.PlcIpAddress("127.0.0.1");
               tb_PLCPort.Text = _setting.PlcPort(502).ToString();
               tb_ReadInterval.Text = _setting.PlcReadInterval(500).ToString();

               tb_LabelGroupPath.Text = _setting.LabelGroupPath(_setting.AppPath() + "\\GroupLabel");
               tb_LabelGroupImagePath.Text = _setting.LabelGroupImagePath(_setting.AppPath() + "\\GroupLabelImage");
               cbb_GroupingPrinter.Text = _setting.LabelGroupPrinter("");

               tb_LabelIndividualPath.Text = _setting.LabelIndividualPath(_setting.AppPath() + "\\IndividualLabel");
               tb_IndividualImagePath.Text =  _setting.LabelIndividualImagePath(_setting.AppPath() + "\\IndividualLabelImage");
               cbb_IndividualPrinter.Text = _setting.LabelIndividualPrinter("");

                cbb_ComName.Text = _setting.BarcodeReaderComName("COM1");
                cbb_BaudRate.Text = _setting.BarcodeReaderBaudRate(115200).ToString();
            }
        }

        private void Save()
        {
            _setting.SetEquipmentIdentity(tb_Identity.Text);
            _setting.SetEquipmentName(tb_EquipmentName.Text);
            _setting.SetTraceAbility(chb_Traceability.Checked);

            _setting.SetDataBaseServer(tb_DataBaseServer.Text);
            _setting.SetDataBaseCatalogue(tb_DataBaseCatalogue.Text);

            _setting.SetPlcIpAddress(tb_PLCAddress.Text);
            _setting.SetPlcPort(Convert.ToInt32(tb_PLCPort.Text));
            _setting.SetPlcReadInterval(Convert.ToInt32(tb_ReadInterval.Text));

            _setting.SetLabelIndividualPath(tb_LabelIndividualPath.Text);
            _setting.SetLabelIndividualImagePath(tb_IndividualImagePath.Text);
            _setting.SetLabelIndividualPrinter(cbb_IndividualPrinter.Text);

            _setting.SetLabelGroupPath(tb_LabelGroupPath.Text);
            _setting.SetLabelGroupImagePath(tb_LabelGroupImagePath.Text);
            _setting.SetLabelGroupPrinter(cbb_GroupingPrinter.Text);

            _setting.SetBarcodeReaderComName(cbb_ComName.Text);
            _setting.SetBarcodeReaderBaudRatee(Convert.ToInt32(cbb_BaudRate.Text));

            _setting.Save();
        }

        private void ListAllSerialPort()
        {
            System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
            {
                cbb_ComName.Items.Add(port);
            }
        }

        private void ListAllbaudRate()
        {
            int[] baudRate = new[] {9600, 19200, 38400, 115200};
            foreach (int baud in baudRate)
            {
                cbb_BaudRate.Items.Add(baud);
            }
        }

        private void ListIndividualPrinter()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbb_IndividualPrinter.Items.Add(printer);
            }
        }
        private void ListGroupPrinter()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbb_GroupingPrinter.Items.Add(printer);
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            LoadSetting();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btn_IndividualLabelpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tb_LabelIndividualPath.Text = fbd.SelectedPath;
            }
        }

        private void btn_LabelIndividualImagePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tb_IndividualImagePath.Text = fbd.SelectedPath;
            }
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
