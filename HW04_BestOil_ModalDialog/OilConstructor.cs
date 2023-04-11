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
    public partial class OilConstructor : Form
    {
        public List<KeyValuePair<string, double>> Fuel { get; set; }
        public OilConstructor(List<KeyValuePair<string, double>> fuel)
        {
            InitializeComponent();
            Fuel = fuel;
            Redraw();
        }
        private void TypeFuel_SelectedIndexChanged(object sender, EventArgs e)
        {// Смена типа топлива
            ComboBox temp = (ComboBox)sender;
            PriceFuel.Text = Fuel[temp.SelectedIndex].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fuel[TypeFuel.SelectedIndex] = new KeyValuePair<string, double>(TypeFuel.SelectedItem.ToString(),Convert.ToDouble(PriceFuel.Text));
        }

        public void Redraw()
        {
            foreach (KeyValuePair<string, double> var in Fuel)
                TypeFuel.Items.Add(var.Key);
            TypeFuel.SelectedIndex = 0;
        }
    }
}
