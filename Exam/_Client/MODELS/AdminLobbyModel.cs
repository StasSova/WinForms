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
    public partial class AdminLobbyModel : Form
    {
        public AdminLobbyModel()
        {
            InitializeComponent();
        }
        public void AddPlayer(string name)
        {
            lock(this.listBox1)
            {
                listBox1.Items.Add(name);
            }
        }
        public async void RemovePlayer(string name)
        {
            await Task.Run(() =>
            {
                lock (this.listBox1)
                {
                    listBox1.Items.Remove(name);
                }
            });
        }
    }
}
