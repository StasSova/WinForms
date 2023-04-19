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
    public partial class RemoveFlight : Form
    {
        internal List<Flight> flights { get; set; }
        internal RemoveFlight(List<Flight> flights)
        {
            InitializeComponent();
            this.flights = flights;
            foreach (Flight flight in flights) { comboBox1.Items.Add(flight); }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flights.Remove((Flight)comboBox1.SelectedItem);
            comboBox1.Items.Clear();
            foreach (Flight flight in flights) { comboBox1.Items.Add(flight); }
            comboBox1.SelectedIndex = 0;
        }
    }
}
