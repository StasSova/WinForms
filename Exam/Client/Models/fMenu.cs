using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Models
{
    public partial class fMenu : Form
    {
        public string Result { get; set; }
        public bool IsBlack;
        public fMenu(bool isBlack)
        {
            InitializeComponent();
            this.IsBlack = isBlack;
            SetTheme();
        }
        // New Game
        private void button1_Click(object sender, EventArgs e)
        {
            Result = "[NEW_GAME]";
        }
        // Exit
        private void button2_Click(object sender, EventArgs e)
        {

        }
        // Connect To Game
        private void button3_Click(object sender, EventArgs e)
        {
            Result = "[CONNECT_TO_GAME]";
        }
        private void SetTheme()
        {
            // если темная тогда ... 
            if (IsBlack) 
            {
                this.BackgroundImage = Properties.Resources.black_background;

                button1.BackgroundImage = Properties.Resources.black_background;
                button1.ForeColor = Color.White;

                button2.BackgroundImage = Properties.Resources.black_background;
                button2.ForeColor = Color.White;

                button3.BackgroundImage = Properties.Resources.black_background;
                button3.ForeColor = Color.White;

                pictureBox1.Image = Properties.Resources.Moon2;
                pictureBox1.BackColor = Color.Black;
            }
            // иначе светлая
            else
            {
                this.BackgroundImage = Properties.Resources.BackImage2;

                button1.BackgroundImage = Properties.Resources.BackImage2;
                button1.ForeColor = Color.Black;

                button2.BackgroundImage = Properties.Resources.BackImage2;
                button2.ForeColor = Color.Black;

                button3.BackgroundImage = Properties.Resources.BackImage2;
                button3.ForeColor = Color.Black;

                pictureBox1.Image = Properties.Resources.sun2;
                pictureBox1.BackColor = Color.White;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // меняем состояние
            IsBlack = !IsBlack;
            SetTheme();
        }
    }
}
