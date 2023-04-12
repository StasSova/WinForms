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

namespace HW05_Search_Files_by_Mask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] Files = Directory.GetFiles(folderBrowserDialog1.SelectedPath,textBox1.Text);
                foreach (string file in Files)
                {
                    listBox1.Items.Add(file);
                }
            }
        }
    }
}
