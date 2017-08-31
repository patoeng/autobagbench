using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoBagBench.Persistence;

namespace AutoBagBench
{
    public partial class ProductReferenceForm : Form
    {
        public ProductReference ProductReference;

        private bool _readOnly;
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set {
                _readOnly = value;
                tb_Article.ReadOnly = _readOnly;
                tb_ReferenceName.ReadOnly = _readOnly;
                tb_GroupingSize.ReadOnly = _readOnly;
                cbb_AccessoriesType.Enabled = !_readOnly;
                cbb_BagType.Enabled = !_readOnly;
                btn_Save.Enabled = !_readOnly;
                tb_LabelFile.Enabled = !_readOnly;
            }
        }

        public ProductReferenceForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ProductReferenceForm_Load(object sender, EventArgs e)
        {
            if (ProductReference == null)
            {
                ProductReference = new ProductReference {Id = Guid.NewGuid()};
            }
            LoadEnums();
            UpdateDisplay();
        }

        private void LoadEnums()
        {
            foreach (BagType bg in Enum.GetValues(typeof (BagType)))
            {
                cbb_BagType.Items.Add(bg.ToString());
            }
            foreach (AccessoriesType acc in Enum.GetValues(typeof(AccessoriesType)))
            {
                cbb_AccessoriesType.Items.Add(acc.ToString());
            }
        }
        private void UpdateDisplay()
        {
            tb_Id.Text = ProductReference.Id.ToString();
            tb_Article.Text = ProductReference.ArticleNumber;
            tb_ReferenceName.Text = ProductReference.ReferenceName;
            tb_GroupingSize.Text = ProductReference.GroupingSize.ToString();
            cbb_AccessoriesType.Text = ProductReference.AccessoriesType.ToString();
            cbb_BagType.Text = ProductReference.BagType.ToString();
            tb_LabelFile.Text = ProductReference.LabelFile;
        }

        private ProductReference LoadFromForm()
        { 
            ProductReference productReference = new ProductReference();
            productReference.Id = new Guid(tb_Id.Text);
            productReference.ReferenceName = tb_ReferenceName.Text;
            productReference.GroupingSize = Convert.ToInt32(tb_GroupingSize.Text);
            productReference.AccessoriesType = (AccessoriesType)Enum.Parse(typeof(AccessoriesType), cbb_AccessoriesType.Text);
            productReference.BagType = (BagType)Enum.Parse(typeof(BagType), cbb_BagType.Text);
            productReference.ArticleNumber = tb_Article.Text;
            productReference.LabelFile = tb_LabelFile.Text;
            return productReference;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            IProductReferenceRepository repo = new ProductReferenceRepository();
            try
            {
                repo.Update(LoadFromForm());
                MessageBox.Show("Data Saved!");
                Hide();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
