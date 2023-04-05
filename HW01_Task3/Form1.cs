using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01_Task3
{
    public partial class Form1 : Form
    {
        private bool Ctrl;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // левая 
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > 10 && e.X < this.Width - 30 &&
                    e.Y > 10 && e.Y < this.Height - 70)
                    Text = $"Вы нажали внутри границы  X:{e.X} Y:{e.Y}";
                else
                    Text = $"Вы нажали снаружи границы  X:{e.X} Y:{e.Y}";
                if ((e.X == 10 || e.X == this.Width-30) && (e.Y >= 10 || e.Y <= this.Height-70) ||
                    (e.X >= 10 || e.X <= this.Width - 30) && (e.Y == 10 || e.Y == this.Height - 70))
                Text = $"Вы нажали на границу  X:{e.X} Y:{e.Y}";
            }
            // левая + ctrl
            if (e.Button == MouseButtons.Left && Ctrl)
            {
                Application.Exit();
            }
            // правая
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Ширина:{this.Width}, Высота:{this.Height}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) Ctrl= true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) Ctrl = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"X:{e.X} Y:{e.Y}";
        }
    }
}
