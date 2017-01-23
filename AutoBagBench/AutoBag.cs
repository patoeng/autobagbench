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
    public partial class AutoBag : Form
    {
        public AutoBag()
        {
            InitializeComponent();
        }

        private void AutoBag_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Setting jj = new Setting())
            {
                jj.ShowDialog();
            }
        }

        private Plc m221;
        private void button2_Click(object sender, EventArgs e)
        {
             m221 = new Plc();
            m221.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m221 != null)
            {
                label1.Text = m221.OutputQuantity.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var jj = new BarcodeReader())
            {
                jj.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IndividualLabel jj = new IndividualLabel {LabelPath = "Food.lab"};
            jj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupLabel gl = new GroupLabel {LabelPath = "Chrono.lab"};
            gl.ShowDialog();
        }
    }
}
