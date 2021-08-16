using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckPrinter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print form = new Print();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Ви дійсно бажаєте вийти?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Check form = new Check();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fuel form = new Fuel();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nalog form = new Nalog();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bottom form = new Bottom();
            form.Show();
        }
    }
}
