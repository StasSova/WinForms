using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Models
{
    public partial class fDescr : Form
    {
        private int TIME; 
        public string Theme { get; set; }
        public fDescr(bool isBlack,Bitmap btm,int time = 20)
        {
            InitializeComponent();
            if (isBlack)
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                label1.Image = Properties.Resources.black_background;
                label1.ForeColor = Color.White;

                label2.Image = Properties.Resources.black_background;
                label2.ForeColor = Color.White;

                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = Color.White;
            }
            TIME = time;
            pictureBox1.Image = btm;
            if (btm.Tag != null)
            pictureBox1.BackColor = (Color)btm.Tag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Theme = textBox1.Text;
                this.DialogResult= DialogResult.OK;
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = (--TIME).ToString();
            if (TIME == 0)
            {
                Theme = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
