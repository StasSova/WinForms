using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04_BestOil_ModalDialog
{
    public partial class Cafe : Form
    {
        public string Check { get { return label5.Text; } }
        public List<KeyValuePair<string, double>> Food { get; set; }
        public Cafe()
        {
            InitializeComponent();
            //
            // заполенение товаров
            //
            Food = new List<KeyValuePair<string, double>>();
            Food.Add(new KeyValuePair<string, double>("Хот-Дог", 40));
            Food.Add(new KeyValuePair<string, double>("Гамбургер", 90));
            Food.Add(new KeyValuePair<string, double>("Картопля-фрі", 50));
            Food.Add(new KeyValuePair<string, double>("Кока-кола", 35));
            Redraw();
        }
        //
        // Checked Changed 
        //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "0";
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
                textBox2.Text = "1";
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
                textBox3.Text = "1";
            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox4.Enabled = true;
                textBox4.Text = "1";
            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";
            }
        }
        //
        // Text Changed
        //
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label16.Text = (Convert.ToDouble(label12.Text) * Convert.ToDouble(textBox1.Text)).ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label15.Text = (Convert.ToDouble(label11.Text) * Convert.ToDouble(textBox2.Text)).ToString();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label14.Text = (Convert.ToDouble(label10.Text) * Convert.ToDouble(textBox3.Text)).ToString();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label13.Text = (Convert.ToDouble(label9.Text) * Convert.ToDouble(textBox4.Text)).ToString();
        }
        private void label16_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (Convert.ToDouble(label16.Text) +
                Convert.ToDouble(label15.Text) +
                Convert.ToDouble(label14.Text) +
                Convert.ToDouble(label13.Text)).ToString();
        }

        public void Reset()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        public void Redraw()
        {
            checkBox1.Text = Food[0].Key; label12.Text = Food[0].Value.ToString();
            checkBox2.Text = Food[1].Key; label11.Text = Food[1].Value.ToString();
            checkBox3.Text = Food[2].Key; label10.Text = Food[2].Value.ToString();
            checkBox4.Text = Food[3].Key; label9.Text = Food[3].Value.ToString();
        }
    }
}
