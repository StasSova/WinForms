using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client.Models
{
    public partial class fNameOfTheGame : Form
    {
        public fNameOfTheGame(bool isBlack)
        {
            InitializeComponent();
            if (isBlack)
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                button2.BackgroundImage = Properties.Resources.black_background;
                button2.ForeColor = Color.White;

                textBox1.BackColor = Color.Black;
                textBox1.ForeColor= Color.White;

                label1.BackColor = Color.Black;
                label1.ForeColor= Color.White;
            }
        }
        public string _name { get; set; }
        // Ввели название игры
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            { 
                _name =  textBox1.Text; 
                this.DialogResult= DialogResult.OK;
                this.Close();
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }
    }
}
