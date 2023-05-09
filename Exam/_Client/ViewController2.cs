using _Client.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client
{
    internal class ViewController2
    {
        ListBox listBox1 = new ListBox();
        AdminLobbyModel adminLobby;
        StartGameModel startGame;
        public ViewController2()
        {
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(39, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(626, 180);
            this.listBox1.TabIndex = 0;
        }
        public void ShowAdminLobby()
        {
            adminLobby = new AdminLobbyModel();
            adminLobby.listBox1 = this.listBox1;
            adminLobby.Show();
        }
        public void ShowUserLobby()
        {
            startGame = new StartGameModel();
            startGame.listBox1 = this.listBox1;
            startGame.Show();
        }
        public void AddPlayer(string name)
        {
            if (adminLobby != null) adminLobby.AddPlayer(name);
            else startGame.AddPlayer(name);
        }
    }
}
