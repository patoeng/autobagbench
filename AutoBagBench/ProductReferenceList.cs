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
using LabelManager2;
using NHibernate.Type;

namespace AutoBagBench
{
    public partial class ProductReferenceList : Form
    {
        public ProductReferenceList()
        {
            InitializeComponent();
        }

        private readonly IProductReferenceRepository _repo = new ProductReferenceRepository();
        private void ProductReferenceList_Load(object sender, EventArgs e)
        {
            LoadEnums();
            LoadData();
           
        }

        private void LoadEnums()
        {
            
           
        }
        private void LoadData()
        {
            dataGV1.Rows.Clear();
            var data = _repo.GetAll();
            foreach (var datas in data)
            {
                
                View.Text = "View";
                dataGV1.Rows.Add(new object[]
                {
                  datas.Id.ToString(), datas.ReferenceName, datas.ArticleNumber,datas.GroupingSize , datas.BagType, datas.AccessoriesType, datas.LabelFile,"Delete","View","Edit","Add"
                });
            }
        }

        private bool DeleteByName(string name)
        {
            var prod = _repo.GetByReferenceName(name);
            if (!String.IsNullOrWhiteSpace(prod.ReferenceName))
            {
                try
                {
                    _repo.Delete(prod.Id);
                    return true;
                }
                catch (Exception ex)
                {
                    return false; 
                }
            }
            return false;
        }
        private bool DeleteById(string id)
        {
            var prod = _repo.Get(new Guid(id));
            if (prod!=null)
            {
                try
                {
                    _repo.Delete(prod.Id);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        private void dataGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var senderGrid = (DataGridView)sender;
            var referenceId =(senderGrid.Rows[e.RowIndex].Cells[0].Value ?? Guid.Empty).ToString();
            var reference = senderGrid.Rows[e.RowIndex].Cells[1].Value??"";
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && referenceId!=Guid.Empty.ToString())
            {
                switch (senderGrid.Columns[e.ColumnIndex].HeaderText)
                {
                    case "DELETE":

                        var dialog = MessageBox.Show("Apakah anda ingin menghapus data "+reference+" ?","Hapus Reference",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            DeleteById(referenceId);
                            LoadData();
                        }
                        break;
                    case "VIEW":
                        using (ProductReferenceForm form = new ProductReferenceForm())
                        {
                            var data = _repo.Get(new Guid(referenceId));
                            form.ProductReference = data;
                            form.ReadOnly = true;
                            form.ShowDialog();
                        }
                        break;
                    case "EDIT":
                        using (ProductReferenceForm form = new ProductReferenceForm())
                        {
                            var data = _repo.Get(new Guid(referenceId));
                            form.ProductReference = data;
                            form.ReadOnly = false;
                            form.ShowDialog();
                            LoadData();
                        }
                        break;
                    case "ADD":
                        using (ProductReferenceForm form = new ProductReferenceForm())
                        {
                            form.ShowDialog();
                            LoadData();
                        }
                        break;
                }
            }
            
        }
    }
}
