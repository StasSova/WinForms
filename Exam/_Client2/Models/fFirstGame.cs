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

namespace _Client2.Models
{
    public partial class fFirstGame : Form
    {
        int NumberSecondForGame = 20;
        public string _history { get; set; }
        SynchronizationContext uiContext;
        public fFirstGame(string from = null)
        {
            InitializeComponent();
            label1.Text += ("   " +from);
            uiContext = SynchronizationContext.Current;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NumberSecondForGame--;
            if (NumberSecondForGame == 0)
            {
                uiContext.Send(d =>
                {
                    Init();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }, null);
            }
        }
        private void Init()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                _history = textBox1.Text;
            else _history = "Птичка летела в мак";
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
