using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoBagBench.Persistence;
using Microsoft.ApplicationBlocks.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AutoBagBench
{
    public partial class ProductReferenceList : Form
    {
        public ProductReferenceList()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += BackgroundWorker1OnDoWork;
            backgroundWorker1.ProgressChanged += BackgroundWorker1OnProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void BackgroundWorker1OnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            progressBar1.Value = progressChangedEventArgs.ProgressPercentage % 100;
        }

        private void BackgroundWorker1OnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            ImportFromExcel(_exportLocation);
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
                dataGV1.Rows.Add(datas.Id.ToString(), datas.ReferenceName, datas.ArticleNumber, datas.GroupingSize, datas.BagType, datas.AccessoriesType, datas.LabelFile, "Delete", "View", "Edit", "Add");
            }
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

        private void SearchByReference(string referenceFilter)
        {
            referenceFilter = referenceFilter.ToUpper();
            dataGV1.Rows.Clear();
            var data = _repo.GetAll().Where(m => m.ReferenceName.Contains(referenceFilter));
            foreach (var datas in data)
            {
                View.Text = "View";
                dataGV1.Rows.Add(datas.Id.ToString(), datas.ReferenceName, datas.ArticleNumber, datas.GroupingSize, datas.BagType, datas.AccessoriesType, datas.LabelFile, "Delete", "View", "Edit", "Add");
            }

        }

        private void ExportToExcel(string fileName)
        {
            try
            {
                var data = _repo.GetAll();
                var newFile = new FileInfo(fileName);

                if (newFile.Exists)
                {
                    newFile.Delete(); // ensures we create a new workbook
                    newFile = new FileInfo(fileName);
                }

                var package = new ExcelPackage();
                var ws = package.Workbook.Worksheets.Add("Product Reference");

                foreach (var pp in data)
                {
                    ws.InsertRow(1, 1);
                    ws.SetValue(1, 1, pp.ReferenceName);
                    ws.SetValue(1, 2, pp.ArticleNumber);
                    ws.SetValue(1, 3, pp.AccessoriesType.ToString());
                    ws.SetValue(1, 4, pp.BagType.ToString());
                    ws.SetValue(1, 5, pp.GroupingSize);
                    ws.SetValue(1, 6, pp.LabelFile);
                }

                //Create header
                ws.InsertRow(1, 1);
                ws.SetValue(1, 1, "Reference Name");
                ws.SetValue(1, 2, "Article Number");
                ws.SetValue(1, 3, "Accessories");
                ws.SetValue(1, 4, "Bag Size");
                ws.SetValue(1, 5, "Grouping Size");
                ws.SetValue(1, 6, "Label Template");

                using (var rng = ws.Cells[1, 1, 1, 6])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.WrapText = false;
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                    rng.AutoFitColumns();
                }
                package.SaveAs(newFile);
                MessageBox.Show(@"Export Ok!");
            }
            catch
            {
                MessageBox.Show(@"Export Failure!");
            }
        }

        private void ImportFromExcel(string fileName)
        {
            try
            {
                
                var newFile = new FileInfo(fileName);

                if (!newFile.Exists)
                {
                    return;
                }

                var package = new ExcelPackage(newFile);
                var ws = package.Workbook.Worksheets["Product Reference"];
                int i = 3;
                int j = 2;
                while (i > 0 && !backgroundWorker1.CancellationPending)
                {
                    try
                    {
                        var reff = ws.Cells[j, 1].Value.ToString().ToUpper();
                        var data = _repo.GetByReferenceName(reff);
                        if (data.ReferenceName != null)
                        {
                            AccessoriesType accessories;
                            var m = ws.Cells[j, 3].Value.ToString();
                            Enum.TryParse(m, out accessories);
                            BagType bagType;
                            m = ws.Cells[j, 4].Value.ToString();
                            Enum.TryParse(m, out bagType);

                            data.ArticleNumber = ws.Cells[j, 2].Value?.ToString().ToUpper();
                            data.AccessoriesType = accessories;
                            data.BagType = bagType;
                            data.GroupingSize = Convert.ToInt32(ws.Cells[j, 5].Value.ToString());
                            data.LabelFile = ws.Cells[j, 6].Value?.ToString().ToUpper();
                            _repo.Update(data);

                        }
                        else
                        {
                            data = new ProductReference();
                            AccessoriesType accessories;
                            Enum.TryParse(ws.Cells[j, 3].Value.ToString(), out accessories);
                            BagType bagType;
                            Enum.TryParse(ws.Cells[j, 4].Value.ToString(), out bagType);

                            data.ReferenceName = reff;
                            data.ArticleNumber = ws.Cells[j, 2].Value?.ToString().ToUpper();
                            data.AccessoriesType = accessories;
                            data.BagType = bagType;
                            data.GroupingSize = Convert.ToInt32(ws.Cells[j, 5].Value.ToString());
                            data.LabelFile = ws.Cells[j, 6].Value?.ToString().ToUpper();
                            _repo.Add(data);

                        }
                      
                        i = 3;
                    }
                    catch(Exception ex)
                    {
                        i--;
                    }
                    j++;
                    backgroundWorker1.ReportProgress(j);
                }


                MessageBox.Show(@"Import Ok!");
            }
            catch
            {
                MessageBox.Show(@"Import Failure!");
            }
           
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {           
            var j = tbReferenceFilter.Text;
            if (j=="")return;
            btnSearch.Enabled = false;
            try
            {
                SearchByReference(j);
                MessageBox.Show(@"Search Done!");
            }
            catch (Exception)
            {
                MessageBox.Show(@"Search Failure!");
            }           
            btnSearch.Enabled = true;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            btnExportToExcel.Enabled = false;
            using (FileDialog fd = new SaveFileDialog())
            {
                fd.Title = @"Lokasi Tempat Untuk Menyimpan hasil Export Auto Bag Product Reference.";
                fd.Filter = @"Microsoft Excel 2013 up|*.xlsx";
                fd.ShowDialog();
                _exportLocation = fd.FileName;
                ExportToExcel(_exportLocation);
            }
            btnExportToExcel.Enabled = true;
        }

        private string _exportLocation;
        private void btnImportFromExcel_Click(object sender, EventArgs e)
        {
            btnImportFromExcel.Enabled = false;
            using (FileDialog fd = new OpenFileDialog())
            {
                fd.Title = @"Lokasi Auto Bag Product Reference.";
                fd.Filter = @"Microsoft Excel 2013 up|*.xlsx";
                fd.ShowDialog();
                _exportLocation = fd.FileName;
                pnlImporting.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
            
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void ProductReferenceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlImporting.Visible = false;
            btnImportFromExcel.Enabled = true;
        }
    }
}
