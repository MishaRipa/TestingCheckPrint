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
    public partial class Bottom : Form
    {
        public Bottom()
        {
            InitializeComponent();
        }

        private void bottomBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bottomBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.checksDataSet);

        }

        private void Bottom_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.bottom". При необходимости она может быть перемещена или удалена.
            this.bottomTableAdapter.Fill(this.checksDataSet.bottom);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bottomDataGridView.RowCount > 0)
            {
                if (textBox2.Text != "")
                {
                    if (MessageBox.Show("Змінити нижню назву?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.bottomTableAdapter.UpdateQuery(textBox2.Text, (int)bottomDataGridView.CurrentRow.Cells[0].Value);
                        this.bottomTableAdapter.Fill(this.checksDataSet.bottom);
                    }
                }
                else MessageBox.Show("Треба обрати стару назву та заповнити поле з новою!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Нічого змінювати!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Додати нижню назву?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.bottomTableAdapter.InsertQuery(textBox1.Text);
                    this.bottomTableAdapter.Fill(this.checksDataSet.bottom);
                }
            }
            else MessageBox.Show("Треба заповнити поле з нижньою назвою!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bottomDataGridView.RowCount > 0)
            {
                if (MessageBox.Show("Ви дійсно бажаєте видалити нижню назву?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if ((int)(this.bottomTableAdapter.BottomIsUsed((int)bottomDataGridView.CurrentRow.Cells[0].Value)) != 1)
                    {
                        this.bottomTableAdapter.DeleteQuery((int)bottomDataGridView.CurrentRow.Cells[0].Value);
                        this.bottomTableAdapter.Fill(this.checksDataSet.bottom);
                    }
                    else MessageBox.Show("На цю назву існує чек! Видаліть або змініть усі чеки з цією назвою!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Нічого видаляти!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bottomDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bottomDataGridView.RowCount > 0)
            {
                textBox2.Text = Convert.ToString(bottomDataGridView.CurrentRow.Cells[1].Value);
            }
        }
    }
}
