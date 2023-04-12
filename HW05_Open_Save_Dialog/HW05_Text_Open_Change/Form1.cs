using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_Text_Open_Change
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                string str = sr.ReadToEnd();
                richTextBox1.Rtf = str;
                sr.Close();
                button2.Enabled = true;
            }
        }
        public void SetText(RichTextBox richText)
        {
            richTextBox1.Text = richText.Text;
        }
        public RichTextBox GetRich()
        {
            return richTextBox1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Constr constr = new Constr(this);
            constr.Show();
        }
    }
}
