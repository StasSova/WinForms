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
    public partial class CafeConstr : Form
    {
        List<KeyValuePair<string, double>> Food { get; set; }
        public CafeConstr(List<KeyValuePair<string, double>> food)
        {
            InitializeComponent();
            Food = food;
            textBox1.Text = Food[0].Key;
            textBox2.Text = Food[1].Key;
            textBox3.Text = Food[2].Key;
            textBox4.Text = Food[3].Key;

            textBox5.Text = Food[0].Value.ToString();
            textBox6.Text = Food[1].Value.ToString();
            textBox7.Text = Food[2].Value.ToString();
            textBox8.Text = Food[3].Value.ToString();
        }
        public List<KeyValuePair<string, double>> Change()
        {
            Food[0] = new KeyValuePair<string, double>(textBox1.Text,Convert.ToDouble(textBox5.Text));
            Food[1] = new KeyValuePair<string, double>(textBox2.Text,Convert.ToDouble(textBox6.Text));
            Food[2] = new KeyValuePair<string, double>(textBox3.Text,Convert.ToDouble(textBox7.Text));
            Food[3] = new KeyValuePair<string, double>(textBox4.Text,Convert.ToDouble(textBox8.Text));
            return Food;
        }
    }
}
