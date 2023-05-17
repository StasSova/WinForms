using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client.Models
{
    public partial class fListGame : Form
    {
        public string SelectedGame { get; set; }
        public fListGame(bool isBlack, string games)
        {
            InitializeComponent();
            if (isBlack)
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                button2.BackgroundImage = Properties.Resources.black_background;
                button2.ForeColor = Color.White;

                listBox1.BackColor = Color.Black;
                listBox1.ForeColor= Color.White;
            }
            string[] _games = games.Split('|');
            foreach (string _game in _games) 
            { 
                listBox1.Items.Add(_game);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null
                && !string.IsNullOrWhiteSpace(listBox1.SelectedItem.ToString())) 
            {
                SelectedGame = listBox1.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
