using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client
{
    public partial class ConnectToServerModel : Form
    {
        public string Nickname { get; set; }
        public string IP { get; set; }
        public ConnectToServerModel()
        {
            InitializeComponent();
            textBox2.Text = "192.168.0.102";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nickname = textBox1.Text;
            IP = textBox2.Text;
        }
    }
}
