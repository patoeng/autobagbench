using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBagBench
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public DialogResult Result = DialogResult.Cancel;
        public string Password;
        private void LoginForm_Load(object sender, EventArgs e)
        { 
            tb_Password.Clear();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Password = tb_Password.Text;
            Result = DialogResult.OK;
            this.Hide();
            this.Close();
        }
    }
}
