using System;
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
            Hide();
            Close();
        }

        private void tb_NewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ChangeOk_Click(btn_ChangeOk, null);
            }
        }
    }
}
