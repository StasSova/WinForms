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
    public partial class fConnect : Form
    {
        public string NickName { set; get; }
        public string IP { set; get; }

        public fConnect()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            NickName = textBox1.Text;
            IP = textBox2.Text;
        }
    }
}
