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

namespace _Server
{
    public partial class View : Form
    {
        // конекст синхронизации
        private SynchronizationContext uiContext;
        private Client_Server controller;
        public View()
        {
            InitializeComponent();
            uiContext= SynchronizationContext.Current;
            controller = new Client_Server(this);
        }
        public async void AddToListBox(string message)
        {
            await Task.Run(() =>
            {
                uiContext.Send(d => listBox1.Items.Add(message), null);
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            uiContext.Send(d =>
            { 
                controller.StartServer();
            }, null);
        }
    }
}
