using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Models
{
    public partial class fFirstGame : Form
    {
        public string History { get; set; }
        public fFirstGame(bool isBlack)
        {
            InitializeComponent();
            if (isBlack)
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                label1.Image = Properties.Resources.black_background;
                label1.ForeColor = Color.White;

                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                History = textBox1.Text;
                this.DialogResult= DialogResult.OK;
                this.Close();
            }
        }
    }
}
