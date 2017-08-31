using System;
using System.Windows.Forms;

namespace AutoBagBench
{
    public partial class OpenProcessList : Form
    {
        public OpenProcessList()
        {
            InitializeComponent();
            dgvList.Columns.Add("clmOrderNumber","Order Number");
            dgvList.Columns.Add("clmProductReference", "Product Reference");
            dgvList.Columns.Add("clmStartDate", "Start Date");

            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        public string SelectedOrderNumber;
        public bool LoadNew;
        private void OpenProcessList_Load(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadOrderNumber_Click(object sender, EventArgs e)
        {
            LoadNew = true;
            SelectedOrderNumber = dgvList.SelectedRows[0].Cells[0].Value.ToString();
            Close();
        }
    }
}
