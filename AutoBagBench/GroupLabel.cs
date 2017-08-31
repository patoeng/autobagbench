using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoBagBench
{
    public partial class GroupLabel : Form
    {
        public Lppx2Manager MLppx2Manager = null;
        public LabelManager2.Application CsApp = null;
        public bool NoDocOpened = true;
        private int _picDefW;
        private int _picDefH;
        private Image _currentImage;
        public Image RealSizeImage;
        private Image.GetThumbnailImageAbort _myCallback;
        private const  string LabelPath = "XS15602.lab";
        public string ActiveReference;
        private LabelManager2.Document _loadedDocument; 
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
        public GroupLabel()
        {
            InitializeComponent();
            Init();
        }

        public Image LoadLabel(string path)
        {
            try
            {
                _loadedDocument?.Close();


                _loadedDocument = CsApp.Documents.Open(path, false);
                _loadedDocument.Variables.Item("Model").Value = ActiveReference;
                _loadedDocument.Variables.Item("DateCode").Value = DateCode.GetDateCode(DateTime.Now);

                if (CsApp.Documents.Count > 0)
                    NoDocOpened = false;
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Load Label :"+ ex.Message);
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
                    MessageBox.Show(@"Preview Label " + ex.Message);
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
            if (_currentImage == null || !Visible) return;
            if ((_currentImage.Width <= _picDefW) && (_currentImage.Height <= _picDefH)) return;
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
        public Image ResizeIfNeeded(int width, int height)
        {
            var editImage = _currentImage;
            if (_currentImage == null) return editImage;
            if ((_currentImage.Width <= width) && (_currentImage.Height <= height)) return editImage;
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
            return editImage;

        }

        private void GroupLabel_Load(object sender, EventArgs e)
        {
            _picDefW = docPreview.Width;
            _picDefH = docPreview.Height;
            docPreview.Image = LoadLabel(SettingHelper.LabelGroupPath() + @"\" + LabelPath);
            lbl_Path.Text = SettingHelper.LabelGroupPath() + @"\" + LabelPath;
            lbl_Printer.Text = SettingHelper.LabelGroupPrinter();

            tb_Left.Text = SettingHelper.GroupLabelHorizontalOffset().ToString();
            tb_Top.Text = SettingHelper.GroupLabelVerticalOffset().ToString();
            cb_Rotate.Text = SettingHelper.GroupLabelRotate().ToString();
        }

       
        public void Print()
        {
            try
            {
                if (NoDocOpened)
                {
                    MessageBox.Show(@"A document must be opened to print !");
                    return;
                }

                try
                {
                    _loadedDocument.Printer.SwitchTo(SettingHelper.LabelGroupPrinter());
                    _loadedDocument.HorzPrintOffset = SettingHelper.GroupLabelHorizontalOffset();
                    _loadedDocument.VertPrintOffset = SettingHelper.GroupLabelVerticalOffset();
                    _loadedDocument.Rotate(SettingHelper.GroupLabelRotate());
                    _loadedDocument.PrintDocument(1);
                }
                catch (FormatException error)
                {
                    MessageBox.Show(@"Printing :" + error.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Label Group :" + ex.Message);
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

        private void btnReload_Click(object sender, EventArgs e)
        {

        }
    }
}
