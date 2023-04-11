using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04_WinFormApplModalDialog
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }
        public string SetText
        {
            set
            {
                textBox2.Text = value;
            }
        }
        public string GetText
        {
            get
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                    return textBox1.Text;
                throw new Exception("Пустая строка");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2= new Form2();
            form2.ParentForm = this;
            form2.SetText = GetText;

            DialogResult res = form2.ShowDialog();
            if (res == DialogResult.OK)
            {
                SetText = form2.GetText;
            }
        }
    }
}
