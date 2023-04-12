using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_Text_Open_Change
{
    public partial class Constr : Form
    {
        Form1 main;
        public Constr(Form1 form)
        {
            InitializeComponent();
            main = form;
            richTextBox1.Text = main.GetRich().Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.SetText(richTextBox1);
        }
    }
}
