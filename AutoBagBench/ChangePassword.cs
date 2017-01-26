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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        public string NewPassword;
        public DialogResult  Result = DialogResult.Cancel;
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            tb_NewPassword.Clear();
        }

        private void btn_ChangeOk_Click(object sender, EventArgs e)
        {
            NewPassword = tb_NewPassword.Text;
            Result = DialogResult.OK;
            this.Hide();
            this.Close();
        }
    }
}
