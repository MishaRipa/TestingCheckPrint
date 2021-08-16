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
    public partial class Check : Form
    {
        public int id;
        public Check()
        {
            InitializeComponent();
        }

        private void checksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.checksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.checksDataSet);
            id = Convert.ToInt32(checksDataGridView.CurrentRow.Cells[0].Value);
        }

        private void Check_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.checks". При необходимости она может быть перемещена или удалена.
            this.checksTableAdapter.Fill(this.checksDataSet.checks);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checksDataGridView.RowCount > 0)
            {
                if (MessageBox.Show("Ви дійсно бажаєте видалити чек?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.checksTableAdapter.DeleteQuery(id);
                    this.checksTableAdapter.Fill(this.checksDataSet.checks);

                }
            }
            else MessageBox.Show("Нічого видаляти!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckWorking form = new CheckWorking();
            form.button2.Visible = false;
            form.button1.Visible = true;
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checksDataGridView.RowCount > 0)
            {
                CheckWorking form = new CheckWorking();
                form.button1.Visible = false;
                form.button2.Visible = true;
                form.textBox1.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[1].Value);
                form.textBox2.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[2].Value);
                form.textBox3.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[3].Value);
                form.textBox4.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[4].Value);
                form.textBox5.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[5].Value);
                form.textBox6.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[6].Value);
                form.textBox7.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[7].Value);
                form.textBox8.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[8].Value);
                form.textBox9.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[9].Value);
                form.textBox10.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[10].Value);
                form.textBox11.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[11].Value);
                form.textBox12.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[12].Value);
                form.textBox15.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[14].Value);
                form.comboBox1.SelectedItem = Convert.ToString(checksDataGridView.CurrentRow.Cells[13].Value);
                form.comboBox2.SelectedItem = Convert.ToString(checksDataGridView.CurrentRow.Cells[15].Value);
                form.dateTimePicker1.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[16].Value);
                form.comboBox3.SelectedItem = Convert.ToString(checksDataGridView.CurrentRow.Cells[17].Value);
                form.textBox1.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[1].Value);
                form.textBox1.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[1].Value);
                form.textBox1.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[1].Value);
                form.label42.Text = Convert.ToString(checksDataGridView.CurrentRow.Cells[0].Value);
                
                form.Show();
            }
            else MessageBox.Show("Нічого редагувати!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Check_Activated(object sender, EventArgs e)
        {
            this.checksTableAdapter.Fill(this.checksDataSet.checks);
        }

        private void checksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(checksDataGridView.CurrentRow.Cells[0].Value);
        }
    }
}
