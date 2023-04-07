using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW03_ProgressBar_ReadFile
{
    public partial class Form1 : Form
    {
        string path = "D:\\Visual_Studio\\WinForms\\HW03_ProgressBar_ReadFile\\1.txt";
        string text;
        int MaxCount;
        public Form1()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            text = sr.ReadToEnd();
            sr.Close();
            MaxCount = text.Length;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = MaxCount;
            label1.Text = "0";
            label2.Text = MaxCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                progressBar1.Value += line.Length;
                Thread.Sleep(100);
            }
            sr.Close();
        }
    }
}
