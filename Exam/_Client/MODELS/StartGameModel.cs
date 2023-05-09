using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client.MODELS
{
    public partial class StartGameModel : Form
    {
        public StartGameModel()
        {
            InitializeComponent();
        }
        public StartGameModel(List<string> players)
        {
            InitializeComponent();
            foreach (string layer in players) 
            { 
                listBox1.Items.Add(layer);
            }
        }
        public void Exit()
        {
            this.Close();
        }
        public void AddPlayer(string playerName)
        {
            lock(listBox1)
            {
                listBox1.Items.Add(playerName);
                listBox1.Invalidate();
            }
        }
    }
}
