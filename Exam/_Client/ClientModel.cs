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
    public partial class ClientModel : Form
    {
        public ClientModel()
        {
            InitializeComponent();
            ClientServer server = new ClientServer();
            server.Start();
            if (!server.client.Connected)
            {
                MessageBox.Show("Вы не подключены");
                return;
            }
            else
            {
                Parallel.Invoke(new Action(() =>
                {
                    server.ReadMessage();
                    server.ShowMainMenu();
                }));
            }
        }
    }
}
