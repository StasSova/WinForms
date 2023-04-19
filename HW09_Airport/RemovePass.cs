using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW09_Airport
{
    public partial class RemovePass : Form
    {
        internal List<Passenger> passengers { get; set; }
        internal RemovePass(List<Passenger> passengers)
        {
            InitializeComponent();
            this.passengers = passengers;
            foreach (Passenger pas in passengers)
                comboBox1.Items.Add(pas);
            comboBox1.SelectedIndex= 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passengers.Remove((Passenger)comboBox1.SelectedItem);
            comboBox1.Items.Clear();
            foreach (Passenger pas in passengers)
                comboBox1.Items.Add(pas);
            comboBox1.SelectedIndex = 0;
        }
    }
}
