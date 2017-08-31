using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoBagBench
{
    public partial class IndividualLabel : Form
    {
        public Lppx2Manager MLppx2Manager = null;
        public LabelManager2.Application CsApp = null;
        public bool NoDocOpened = true;
        private int _picDefW;
        private int _picDefH;
        private Image _currentImage;
        public   Image RealSizeImage;
        private Image.GetThumbnailImageAbort _myCallback;
        public string LabelPath;
        private string _activeReference ;
        private string _referenceFamily;
        public bool Printed;
        private LabelManager2.Document _loadedDocument;
        public string ActiveReference
        {
            get
            {
                return _activeReference;
            }
            set
            {
                _activeReference = value;
                var reg = Regex.Match(_activeReference, @"XS\d{1}");
                _referenceFamily = reg.Success ? reg.Value : "";
            }
        }

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
             _myCallback = ThumbnailCallback;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
        public IndividualLabel()
        {
            InitializeComponent();
            Init();
        }

        public string LabelFullPath()
        {
            return SettingHelper.LabelIndividualPath() + @"\" + LabelPath;
        }
        private void IndividualLabel_Load(object sender, EventArgs e)
        {
            try
            {
                _picDefW = docPreview.Width;
                _picDefH = docPreview.Height;
                var j = LabelFullPath();
                docPreview.Image = LoadLabel(j);
            }
            catch (Exception ex)
            {
                MessageBox.Show(LabelFullPath() + "\r\n"+ ex);
            }
            lbl_Path.Text = SettingHelper.LabelIndividualPath() + @"\" + LabelPath;
            lbl_Printer.Text = SettingHelper.LabelIndividualPrinter();

            tb_Left.Text = SettingHelper.IndividualLabelHorizontalOffset().ToString();
            tb_Top.Text = SettingHelper.IndividualLabelVerticalOffset().ToString();
            cb_Rotate.Text = SettingHelper.IndividualLabelRotate().ToString();
        }
        public Image LoadLabel(string path)
        {
            try
            {
                _loadedDocument?.Close();


                _loadedDocument = CsApp.Documents.Open( path, false);
                _loadedDocument.Variables.Item("ImagePath").Value = SettingHelper.LabelIndividualImagePath() + @"\" +
                                                                         _referenceFamily + @"\" + _activeReference +
                                                                         ".jpg";

                if (CsApp.Documents.Count > 0)
                    NoDocOpened = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Load Individual Label : " + ex.StackTrace+ "\r\n"+path+"]\r\n" + SettingHelper.LabelIndividualImagePath() + @"\" +
                                                                         _referenceFamily + @"\" + _activeReference +
                                                                         ".jpg");
            }
            return NoDocOpened ? new Bitmap(1, 1) : DisplayPreview();
        }
        private Image DisplayPreview()
        {
            if (_loadedDocument != null)
            {
                DisposeImages();

                try
                {

                    object obj = _loadedDocument.GetPreview(true, true, 100);
                    if (obj is Array)
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
                    MessageBox.Show(@"Load Preview Individual Label " + ex.Message);
                }
            }
            return _currentImage;
        }
        private void DisposeImages()
        {
            RealSizeImage?.Dispose();
            _currentImage?.Dispose();
        }
        private void ResizeIfNeeded()
        {
            if (_currentImage != null && Visible)
            {
                if ((_currentImage.Width > _picDefW) || (_currentImage.Height > _picDefH))
                {
                    if ((_currentImage.Width / _picDefW) > (_currentImage.Height / _picDefH))
                    {
                        double a = ((double)_picDefW) / (((double)_currentImage.Width));
                        _currentImage = _currentImage.GetThumbnailImage(_picDefW, (int)((double)_currentImage.Height * a), _myCallback, IntPtr.Zero);
                    }
                    else
                    {
                        double a = ((double)_picDefH) / (((double)_currentImage.Height));
                        _currentImage = _currentImage.GetThumbnailImage((int)((double)_currentImage.Width * a), _picDefH, _myCallback, IntPtr.Zero);
                    }
                }
            }

        }
        public Image ResizeIfNeeded(int width, int height)
        {
            var editImage = _currentImage;
            if (_currentImage != null)
            {
                if ((_currentImage.Width > width) || (_currentImage.Height > height))
                {
                    if ((_currentImage.Width / width) > (_currentImage.Height / height))
                    {                  
                        double a = ((double)width) / (((double)_currentImage.Width));
                        editImage = _currentImage.GetThumbnailImage(width, (int)((double)_currentImage.Height * a), _myCallback, IntPtr.Zero);
                    }
                    else
                    {                       
                        double a = ((double)height) / (((double)_currentImage.Height));
                        editImage = _currentImage.GetThumbnailImage((int)((double)_currentImage.Width * a), _picDefH, _myCallback, IntPtr.Zero);                     
                    }
                }
            }
            return editImage;

        }

        public void Print()
        {
            Printed = false;
            try
            { 
                if (NoDocOpened)
                {
                    MessageBox.Show(@"A document must be opened to print !");
                    Printed = false;
                    return;
                }

                try
                {
                    _loadedDocument.Printer.SwitchTo(SettingHelper.LabelIndividualPrinter());
                    _loadedDocument.HorzPrintOffset = SettingHelper.IndividualLabelHorizontalOffset();
                    _loadedDocument.VertPrintOffset = SettingHelper.IndividualLabelVerticalOffset();
                    _loadedDocument.Rotate(SettingHelper.IndividualLabelRotate());
                    _loadedDocument.PrintDocument(1);
                    Printed = true;
                   
                }
                catch (FormatException error)
                {
                    MessageBox.Show(@"Label qty must  an integer...\n\n\n" + error.Message);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Label "+ex.Message);
              
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            
           Print();
        }

        private void IndividualLabel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void CloseApp()
        {
            MLppx2Manager.QuitLppx2();
        }

        public Image LoadCurrentLabel()
        {
            return LoadLabel(LabelFullPath());
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                SettingHelper.SetIndividualLabelHorizontalOffset(Convert.ToInt32(tb_Left.Text));
                SettingHelper.SetIndividualLabelVerticalOffset(Convert.ToInt32(tb_Top.Text));
                SettingHelper.SetIndividualLabelRotate(Convert.ToInt32(cb_Rotate.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

      
    }
}
