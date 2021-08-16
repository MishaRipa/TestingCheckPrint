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
    public partial class Fuel : Form
    {
        public Fuel()
        {
            InitializeComponent();
        }

        private void fuelBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fuelBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.checksDataSet);

        }

        private void Fuel_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.fuel". При необходимости она может быть перемещена или удалена.
            this.fuelTableAdapter.Fill(this.checksDataSet.fuel);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (MessageBox.Show("Додати паливо?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.fuelTableAdapter.InsertQuery(textBox1.Text, Convert.ToDecimal(textBox2.Text));
                    this.fuelTableAdapter.Fill(this.checksDataSet.fuel);
                }
            }
            else MessageBox.Show("Треба заповнити поля з назвою налогу та його відсотком!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fuelDataGridView.RowCount > 0)
            {
                if (MessageBox.Show("Ви дійсно бажаєте видалити паливо?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if ((int)(this.fuelTableAdapter.FuelIsUsed((int)fuelDataGridView.CurrentRow.Cells[0].Value)) != 1)
                    {
                        this.fuelTableAdapter.DeleteQuery((int)fuelDataGridView.CurrentRow.Cells[0].Value);
                        this.fuelTableAdapter.Fill(this.checksDataSet.fuel);
                    }
                    else MessageBox.Show("На це паливо існує чек! Видаліть або змініть усі чеки з цим паливом!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Нічого видаляти!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fuelDataGridView.RowCount > 0)
            {
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    if (MessageBox.Show("Змінити паливо?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.fuelTableAdapter.UpdateQuery(textBox3.Text, Convert.ToDecimal(textBox4.Text), (int)fuelDataGridView.CurrentRow.Cells[0].Value);
                        this.fuelTableAdapter.Fill(this.checksDataSet.fuel);
                    }
                }
                else MessageBox.Show("Оберіть поле та зробіть усі необхідні зміни!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Нічого змінювати!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void fuelDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fuelDataGridView.RowCount > 0)
            {
                textBox3.Text = Convert.ToString(fuelDataGridView.CurrentRow.Cells[1].Value);
                textBox4.Text = Convert.ToString(fuelDataGridView.CurrentRow.Cells[2].Value);
            }
        }
    }
}
