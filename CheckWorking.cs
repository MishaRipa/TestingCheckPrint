using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;

namespace CheckPrinter
{
    public partial class CheckWorking : Form
    {
        public CheckWorking()
        {
            InitializeComponent();
        }

        private void CheckWorking_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.checks". При необходимости она может быть перемещена или удалена.
            this.checksTableAdapter.Fill(this.checksDataSet.checks);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.fuel". При необходимости она может быть перемещена или удалена.
            this.fuelTableAdapter.Fill(this.checksDataSet.fuel);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.bottom". При необходимости она может быть перемещена или удалена.
            this.bottomTableAdapter.Fill(this.checksDataSet.bottom);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "checksDataSet.nalog". При необходимости она может быть перемещена или удалена.
            this.nalogTableAdapter.Fill(this.checksDataSet.nalog);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yy hh:mm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox15.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && dateTimePicker1.Text != "")
            {
                if (MessageBox.Show("Створити чек?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.checksTableAdapter.InsertQuery(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, Convert.ToInt32(textBox9.Text), textBox10.Text, textBox11.Text, textBox12.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDouble(textBox15.Text), Convert.ToInt32(comboBox2.SelectedValue), dateTimePicker1.Value, Convert.ToInt32(comboBox3.SelectedValue));
                }
            }
            else MessageBox.Show("Треба заповнити усі поля!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox15.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && dateTimePicker1.Text != "")
            {
                if (MessageBox.Show("Відредагувати чек?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.checksTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, Convert.ToInt32(textBox9.Text), textBox10.Text, textBox11.Text, textBox12.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDouble(textBox15.Text), Convert.ToInt32(comboBox2.SelectedValue), dateTimePicker1.Value, Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(label42.Text));
                }
            }
            else MessageBox.Show("Треба заповнити усі поля!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox15.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && dateTimePicker1.Text != "")
            {
                if (MessageBox.Show("Розрахувати усю інформацію?", "Інформація", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    label29.Text = dateTimePicker1.Text;
                    label27.Text = textBox5.Text;
                    label25.Text = textBox9.Text;
                    label31.Text = Convert.ToString(RoundUp(Convert.ToDecimal(fuelTableAdapter.FindFuelPrice(comboBox1.Text)),2));
                    label20.Text = Convert.ToString(nalogTableAdapter.FindNalog(comboBox2.Text));
                    label41.Text = comboBox2.Text;
                    label17.Text = label15.Text = Convert.ToString(RoundUp(Convert.ToDecimal(label31.Text) * Convert.ToDecimal(textBox15.Text),2));
                    label21.Text = Convert.ToString(RoundUp((Convert.ToDecimal(label17.Text) * Convert.ToDecimal(label20.Text)) / (100 + Convert.ToDecimal(label20.Text)),2));

                }
            }
            else MessageBox.Show("Треба заповнити усі поля!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static decimal RoundUp(decimal number, int digits)
        {
            var factor = Convert.ToDecimal(Math.Pow(10, digits));
            return Math.Ceiling(number * factor) / factor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox15.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && dateTimePicker1.Text != "")
            {
                if (label31.Text != "" && label15.Text != "" && label41.Text != "" && label17.Text != "" && label20.Text != "" && label21.Text != "" && label25.Text != "" && label27.Text != "" && label29.Text != "")
                {
                    reportViewer report = new reportViewer();
                    ForPrint crystal = new ForPrint();
                    TextObject company = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
                    company.Text = textBox1.Text;
                    TextObject place = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                    place.Text = textBox2.Text;
                    TextObject oblast = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                    oblast.Text = textBox3.Text;
                    TextObject street = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
                    street.Text = textBox4.Text;
                    TextObject FH = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
                    FH.Text = textBox5.Text;
                    TextObject ZH = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
                    ZH.Text = textBox6.Text;
                    TextObject IA = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                    IA.Text = textBox7.Text;
                    TextObject PN = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                    PN.Text = textBox8.Text;
                    TextObject number = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                    number.Text = textBox9.Text;
                    TextObject cashier = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                    cashier.Text = textBox10.Text;
                    TextObject checks_11 = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
                    checks_11.Text = textBox11.Text;
                    TextObject checks_12 = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
                    checks_12.Text = textBox12.Text;
                    TextObject fuel_name = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                    fuel_name.Text = Convert.ToString(comboBox1.Text);
                    TextObject fuel_price = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                    fuel_price.Text = label31.Text;
                    TextObject litre = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                    litre.Text = textBox15.Text;
                    TextObject sum_first = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
                    sum_first.Text = label15.Text;
                    TextObject nalog_name_first = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                    nalog_name_first.Text = label41.Text;
                    TextObject sum_two = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];
                    sum_two.Text = label17.Text;
                    TextObject nalog_name_second = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                    nalog_name_second.Text = comboBox2.Text;
                    TextObject nalog_amount = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
                    nalog_amount.Text = label20.Text;
                    TextObject percent = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                    percent.Text = label21.Text;
                    TextObject checks_number = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                    checks_number.Text = label25.Text;
                    TextObject checks_date1 = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                    checks_date1.Text = dateTimePicker1.Text;
                    TextObject fh = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
                    fh.Text = label27.Text;
                    TextObject checks_date2 = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                    checks_date2.Text = label29.Text;
                    TextObject checks_bottom = (TextObject)crystal.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                    checks_bottom.Text = comboBox3.Text;
                    report.crystalReportViewer1.ReportSource = crystal;
                    report.Show();
                }
                else MessageBox.Show("Спочатку натисніть на Розрахувати!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Заповніть усі поля!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
