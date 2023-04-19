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
    public partial class AddFlight : Form
    {
        internal List<Flight> flights { get; set; }
        public AddFlight()
        {
            InitializeComponent();
            flights= new List<Flight>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                    throw new Exception("Поле Номер рейса не может быть пустым");
                if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrEmpty(textBox6.Text))
                    throw new Exception("Поле Отправление не может быть пустым");
                if (string.IsNullOrEmpty(textBox3.Text))
                    throw new Exception("Поле Количество часов полета не может быть пустым");
                if (string.IsNullOrEmpty(textBox4.Text))
                    throw new Exception("Поле Направление не может быть пустым");
                flights.Add(new Flight(Convert.ToInt16(textBox1.Text), 
                    new DateTime(Convert.ToInt16(textBox6.Text), Convert.ToInt16(textBox5.Text), Convert.ToInt16(textBox2.Text)), 
                    Convert.ToInt16(textBox3.Text), textBox4.Text));
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message,"Error"); }
        }
    }
}
