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
    public partial class Nalog : Form
    {
        public Nalog()
        {
            InitializeComponent();
        }

        private void nalogBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nalogBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.checksDataSet);
        }

        private void Nalog_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.nalog". При необходимости она может быть перемещена или удалена.
            this.nalogTableAdapter.Fill(this.checksDataSet.nalog);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nalogDataGridView.RowCount > 0)
            {
                if (MessageBox.Show("Ви дійсно бажаєте видалити налог?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if ((int)(this.nalogTableAdapter.NalogIsUsed((int)nalogDataGridView.CurrentRow.Cells[0].Value)) != 1)
                    {
                        this.nalogTableAdapter.DeleteQuery((int)nalogDataGridView.CurrentRow.Cells[0].Value);
                        this.nalogTableAdapter.Fill(this.checksDataSet.nalog);
                    }
                    else MessageBox.Show("На цей налог існує чек! Видаліть або змініть усі чеки з цим налогом!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Нічого змінювати!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nalogDataGridView.RowCount > 0)
            {
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    if (Convert.ToInt32(textBox4.Text) >= 0 && Convert.ToInt32(textBox4.Text) <= 100)
                    {
                        if (MessageBox.Show("Змінити налог?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            this.nalogTableAdapter.UpdateQuery(textBox3.Text, textBox4.Text, (int)nalogDataGridView.CurrentRow.Cells[0].Value);
                            this.nalogTableAdapter.Fill(this.checksDataSet.nalog);
                        }
                    }
                    else MessageBox.Show("Треба вводити відсотки від 0 до 100!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Оберіть поле та зробіть усі необхідні зміни!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Нічого видаляти!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (Convert.ToInt32(textBox2.Text) >= 0 && Convert.ToInt32(textBox2.Text) <= 100)
                {
                    if (MessageBox.Show("Додати налог?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.nalogTableAdapter.InsertQuery(textBox1.Text, textBox2.Text);
                        this.nalogTableAdapter.Fill(this.checksDataSet.nalog);
                    }
                }
                else MessageBox.Show("Треба вводити відсотки від 0 до 100!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Треба заповнити поля з назвою налогу та його відсотком!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nalogDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (nalogDataGridView.RowCount > 0)
            {
                textBox3.Text = Convert.ToString(nalogDataGridView.CurrentRow.Cells[1].Value);
                textBox4.Text = Convert.ToString(nalogDataGridView.CurrentRow.Cells[2].Value);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
