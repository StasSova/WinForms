using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW06_Quiz_TabControl
{
    public partial class Form1 : Form
    {
        int rez = 0;
        int max = 9;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.SelectedIndex = 1;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.SelectedIndex = 2;
            button2.Enabled = false;
        }

        // конец
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы набрали {rez} из {max} возможных","Конец");
            button3.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton sen = (RadioButton)sender;
            if (sen.Checked)
                rez++;
            else rez--;
        }
    }
}
