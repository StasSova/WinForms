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

namespace _Client.MODELS
{
    public partial class LobbyModel : Form
    {
        public string SelectedGame { get; set; }
        public LobbyModel(List<string> games)
        {
            InitializeComponent();
            foreach (var item in games)
            {
                listBox1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectedGame = listBox1.SelectedItem.ToString();
        }

    }
}
