using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class fConnect : Form
    {
        public string res;
        public fConnect()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // по нажатию на кнопку присоединится проходит проверка на 
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && // есть ли какой-то ник
                Regex.IsMatch(textBox2.Text, @"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")) // корректность IP
                {
                    res = string.Join("|", textBox1.Text, textBox2.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK); }
        }
    }
}
