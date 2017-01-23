using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBagBench
{
    public partial class GroupLabel : Form
    {
        public Lppx2Manager MLppx2Manager = null;
        public LabelManager2.Application CsApp = null;
        public bool NoDocOpened = true;
        private System.String _csPath;
        private System.Int32 _picDefW;
        private System.Int32 _picDefH;
        private System.Drawing.Image _currentImage;
        public System.Drawing.Image RealSizeImage;
        private Image.GetThumbnailImageAbort _myCallback;
        private const  string LabelPath = "XS15602.lab";
        public String ActiveReference;
         public void Init()
        {
             try
             {
                 MLppx2Manager = new Lppx2Manager();
                 CsApp = MLppx2Manager.GetApplication();
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             _myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
        public GroupLabel()
        {
            InitializeComponent();
            Init();
        }

        public Image LoadLabel(string path)
        {
            try
            {
                if (CsApp.Documents.Count > 0)
                {
                    CsApp.Documents.CloseAll(false);
                }


                CsApp.Documents.Open(path, false);
                CsApp.ActiveDocument.Variables.Item("Model").Value = ActiveReference;
                CsApp.ActiveDocument.Variables.Item("DateCode").Value = DateCode.GetDateCode(DateTime.Now);
                // Set the Form Caption
                //Text = CsApp.ActivePrinterName;

                if (CsApp.Documents.Count > 0)
                    NoDocOpened = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Label "+ ex.Message);
            }
            return NoDocOpened == true ? new Bitmap(1, 1) : DisplayPreview();
        }
        private Image DisplayPreview()
        {
            if (CsApp.ActiveDocument != null)
            {
                DisposeImages();

                try
                {

                    object obj = CsApp.ActiveDocument.GetPreview(true, true, 100);
                    if (obj is System.Array)
                    {
                        byte[] data = (byte[])obj;

                        System.IO.MemoryStream pStream = new System.IO.MemoryStream(data);
                        _currentImage = new Bitmap(pStream);
                    }

                    RealSizeImage = _currentImage;
                    ResizeIfNeeded();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Preview Label " + ex.Message);
                }
            }
            return _currentImage;
        }
        private void DisposeImages()
        {
            if (RealSizeImage != null)
            {
                RealSizeImage.Dispose();
            }

            if (_currentImage != null)
            {
                _currentImage.Dispose();
            }

        }
        private void ResizeIfNeeded()
        {
            // If image width is greater than the pictureBox width 
            // OR
            // image height is greater than the pictureBox height
            // then it must be resized...
            if (_currentImage != null && Visible)
            {
                if ((_currentImage.Width > _picDefW) || (_currentImage.Height > _picDefH))
                {
                    // which one (width or height) must be used to resize ?
                    if ((_currentImage.Width / _picDefW) > (_currentImage.Height / _picDefH))
                    {
                        // Must use width to resize
                        double a = ((double)_picDefW) / (((double)_currentImage.Width));
                        _currentImage = _currentImage.GetThumbnailImage(_picDefW, (int)((double)_currentImage.Height * a), _myCallback, IntPtr.Zero);
                    }
                    else
                    {
                        // Must use Height to resize
                        double a = ((double)_picDefH) / (((double)_currentImage.Height));
                        _currentImage = _currentImage.GetThumbnailImage((int)((double)_currentImage.Width * a), _picDefH, _myCallback, IntPtr.Zero);

                        //	currentImage = currentImage.GetThumbnailImage((int)(currentImage.Width/(currentImage.Height / picDefH)),picDefH, myCallback, IntPtr.Zero);
                    }
                }
            }

        }
        public Image ResizeIfNeeded(int width, int height)
        {
            // If image width is greater than the pictureBox width 
            // OR
            // image height is greater than the pictureBox height
            // then it must be resized...
            var editImage = _currentImage;
            if (_currentImage != null)
            {
                if ((_currentImage.Width > width) || (_currentImage.Height > height))
                {
                    // which one (width or height) must be used to resize ?
                    if ((_currentImage.Width / width) > (_currentImage.Height / height))
                    {
                        // Must use width to resize
                        double a = ((double)width) / (((double)_currentImage.Width));
                        editImage = _currentImage.GetThumbnailImage(width, (int)((double)_currentImage.Height * a), _myCallback, IntPtr.Zero);
                    }
                    else
                    {
                        // Must use Height to resize
                        double a = ((double)height) / (((double)_currentImage.Height));
                        editImage = _currentImage.GetThumbnailImage((int)((double)_currentImage.Width * a), _picDefH, _myCallback, IntPtr.Zero);

                        //	currentImage = currentImage.GetThumbnailImage((int)(currentImage.Width/(currentImage.Height / picDefH)),picDefH, myCallback, IntPtr.Zero);
                    }
                }
            }
            return editImage;

        }

        private void GroupLabel_Load(object sender, EventArgs e)
        {
            _picDefW = docPreview.Width;
            _picDefH = docPreview.Height;
            docPreview.Image = LoadLabel(SettingHelper.LabelGroupPath() + "\\" + LabelPath);
            lbl_Path.Text = SettingHelper.LabelGroupPath() + "\\" + LabelPath;
            lbl_Printer.Text = SettingHelper.LabelGroupPrinter();

            tb_Left.Text = SettingHelper.GroupLabelHorizontalOffset().ToString();
            tb_Top.Text = SettingHelper.GroupLabelVerticalOffset().ToString();
            cb_Rotate.Text = SettingHelper.GroupLabelRotate().ToString();
        }

       
        public void Print()
        {

            try
            {
                //docPreview.Image = LoadLabel("chrono.lab");
                if (NoDocOpened)
                {
                    MessageBox.Show("A document must be opened to print !");
                    return;
                }

                try
                {
                    // Add Handlers for Printing Events for the Active Document if necessary
                    MLppx2Manager.SwitchPrinter(SettingHelper.LabelGroupPrinter());
                    CsApp.ActiveDocument.HorzPrintOffset = SettingHelper.GroupLabelHorizontalOffset();
                    CsApp.ActiveDocument.VertPrintOffset = SettingHelper.GroupLabelVerticalOffset();
                    CsApp.ActiveDocument.Rotate(SettingHelper.GroupLabelRotate());
                    CsApp.ActiveDocument.PrintDocument(1);

                }
                catch (System.FormatException error)
                {
                    MessageBox.Show("Label qty must be an integer...\n\n\n" + error.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Label Group :" + ex.Message);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            docPreview.Image = LoadLabel(SettingHelper.LabelGroupPath() + "\\" + LabelPath);
            Print();
        }

        private void GroupLabel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        public void CloseApp()
        {
            MLppx2Manager.QuitLppx2();
        }
        public string LabelFullPath()
        {
            return SettingHelper.LabelGroupPath() + "\\" + LabelPath;
        }
        public Image LoadCurrentLabel()
        {
            return LoadLabel(LabelFullPath());
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                SettingHelper.SetGroupLabelHorizontalOffset(Convert.ToInt32(tb_Left.Text));
                SettingHelper.SetGroupLabelVerticalOffset(Convert.ToInt32(tb_Top.Text));
                SettingHelper.SetGroupLabelRotate(Convert.ToInt32(cb_Rotate.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
