using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client2.Models
{
    public partial class fDescribing : Form
    {
        private int TimeToEnd;
        public string descr { get; set; }
        public fDescribing(Bitmap image, int time)
        {
            InitializeComponent();
            TimeToEnd = time;
            pictureBox1.Image = image;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeToEnd--;
            label2.Text = TimeToEnd.ToString();
            if (TimeToEnd == 0)
            {
                // конец
                this.DialogResult = DialogResult.OK;
                descr = textBox1.Text;
                timer1.Stop();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            descr = textBox1.Text;
        }
    }
}
