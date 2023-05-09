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
    public partial class StartModel : Form
    {
        public string Choice { get; set; }
        public StartModel()
        {
            InitializeComponent();
        }

        // Новая игра
        private void button1_Click(object sender, EventArgs e)
        {
            Choice = "NEW_GAME";
        }
        // Присоединится
        private void button3_Click(object sender, EventArgs e)
        {
            Choice = "[LIST_GROUP]";
        }
        // Выход
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
