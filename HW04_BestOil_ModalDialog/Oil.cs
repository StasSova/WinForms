using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04_BestOil_ModalDialog
{
    public partial class Oil : Form
    {
        public string Check { get { return SumOil.Text; }}
        public List<KeyValuePair<string, double>> Fuel = new List<KeyValuePair<string, double>>();
        public Oil()
        {
            InitializeComponent();
            Count.Enabled = true;

            // 
            // Вид топлива 
            // 
            Fuel.Add(new KeyValuePair<string, double>("A-95+", 51));
            Fuel.Add(new KeyValuePair<string, double>("A-95", 49));
            Fuel.Add(new KeyValuePair<string, double>("A-92", 49));
            Fuel.Add(new KeyValuePair<string, double>("ДП", 50));
            Fuel.Add(new KeyValuePair<string, double>("Газ", 22));

            // Отрисовка и заполнение ComboBox
            Redraw();
        }
        //
        // Button Checked Changed
        //
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {// галочка на Кол-во
            if (radioButton1.Checked)
            {
                Count.Enabled = true;
            }
            else
            {
                Count.Enabled = false;
            }
                Count.Text = "";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {// галочка на Сума
            if (radioButton2.Checked)
            {
                SumOfFuel.Enabled = true;
            }
            else
            {
                SumOfFuel.Enabled = false;
            }
            SumOfFuel.Text = "";
            SumOil.Text = "";
        }
        private void TypeFuel_SelectedIndexChanged(object sender, EventArgs e)
        {// Смена типа топлива
            ComboBox temp = (ComboBox)sender;
            PriceFuel.Text = Fuel[temp.SelectedIndex].Value.ToString();
        }

        //
        // Text Chenged
        //
        private void Count_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Regex.IsMatch(Count.Text, @"^\d+([,]\d{1,2})?$"))
                { // Строка соответствует формату.
                    Count.ForeColor = Color.Green;
                    SumOil.Text = (Convert.ToDouble(Count.Text) * Convert.ToDouble(PriceFuel.Text)).ToString();
                }
                else
                { // Строка не соответствует формату.
                    Count.ForeColor = Color.Red;
                    SumOil.Text = "0";
                }
            }
        }
        private void SumOfFuel_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (Regex.IsMatch(SumOfFuel.Text, @"^\d+([,]\d{1,2})?$"))
                {
                    SumOfFuel.ForeColor = Color.Green;
                    if (SumOfFuel.Text == "")
                        SumOfFuel.Text = "0";
                    SumOil.Text = SumOfFuel.Text;
                    Count.Text = String.Format("{0:F2}", (Convert.ToDouble(SumOfFuel.Text) / Convert.ToDouble(PriceFuel.Text)));
                }
                else
                {
                    SumOfFuel.ForeColor = Color.Red;
                    Count.Text = "0";
                }
            }
        }

        public void Redraw()
        {
            foreach (KeyValuePair<string, double> var in Fuel)
                TypeFuel.Items.Add(var.Key);
            TypeFuel.SelectedIndex = 0;
        }
        public void Reset()
        {
            TypeFuel.SelectedIndex = 0;
            radioButton1.Checked = true;
            Count.Text = "";
        }
        
    }
}
