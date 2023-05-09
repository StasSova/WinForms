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
    public partial class fGameName : Form
    {
        public string _name { get; set; }
        public fGameName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _name = textBox1.Text;
        }
    }
}
