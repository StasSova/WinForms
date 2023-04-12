using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_PC_Sell_Change
{
    public partial class Constr : Form
    {
        public List<KeyValuePair<string, double>> List { get; set; }
        public Constr(List<KeyValuePair<string, double>> list)
        {
            InitializeComponent();
            List = list;
            // 
            // ComboBox 
            // 
            foreach (KeyValuePair<string, double> item in List)
                comboBox1.Items.Add(item.Key);
            comboBox1.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = List[comboBox1.SelectedIndex].Key;
            textBox2.Text = List[comboBox1.SelectedIndex].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List[comboBox1.SelectedIndex] = new KeyValuePair<string, double>(textBox1.Text,Convert.ToDouble(textBox2.Text));
        }
    }
}
