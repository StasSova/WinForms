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
    public partial class fMenu : Form
    {
        public string ResultClick;
        public fMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultClick = "[NEW_GAME]";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResultClick = "[LIST_GROUP]";
        }
    }
}
