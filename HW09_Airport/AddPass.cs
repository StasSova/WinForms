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
    public partial class AddPass : Form
    {
        internal List<Flight> flights { get; set; }
        internal List<Passenger> passengers { get; set; }
        internal AddPass(List<Flight> flights)
        {
            InitializeComponent();
            this.flights = flights;
            passengers= new List<Passenger>();
            foreach (Flight flight in flights) 
            { comboBox1.Items.Add(flight); }
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                    throw new Exception("Поле Фамилии не должно быть пустым");
                if (string.IsNullOrEmpty(textBox2.Text))
                    throw new Exception("Поле Количество багажа не должно быть пустым");
                if (string.IsNullOrEmpty(textBox3.Text))
                    throw new Exception("Поле Общая масса багажа не должно быть пустым");
                passengers.Add(new Passenger(textBox1.Text,Convert.ToInt16(textBox2.Text),Convert.ToInt16(textBox3.Text),(Flight)comboBox1.SelectedItem));
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                comboBox1.SelectedIndex = 0;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
