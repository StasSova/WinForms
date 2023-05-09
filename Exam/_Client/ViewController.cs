using _Client.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Client
{
    internal class ViewController
    {
        AdminLobbyModel adminLobby;
        public ViewController() 
        {
            adminLobby = new AdminLobbyModel();
        }
        public string ShowConnectDialog()
        {
            string  name = null, 
                    ip = null;
            ConnectToServerModel model = new ConnectToServerModel();
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                name = model.Nickname;
                ip = model.IP;
                return string.Join("|", name, ip);
            }
            else
            {
                Application.Exit();
            }
            return null;
        }
        public string ShowMainMenuDialog()
        {
            string sRes = null;
            StartModel model = new StartModel();
            DialogResult dRes = model.ShowDialog();
            if (dRes == DialogResult.Cancel)
            {
                sRes = "EXIT";
            }
            else
            {
                sRes = model.Choice;
            }
            return sRes;
        }
        public string ShowNameGameDialog() 
        { 
            NameGameModel model = new NameGameModel();
            DialogResult dRes = model.ShowDialog();
            if (dRes == DialogResult.Cancel) 
            {
                return "EXIT";
            }
            else if (dRes == DialogResult.OK)
            {
                return model._name;
            }    
            return null;
        }
        public void ShowAdminLobby(string player)
        {
            DialogResult res;
            // Режим ожидания
            Parallel.Invoke(() =>
            {
                adminLobby.AddPlayer(player);
                res = adminLobby.ShowDialog();
                if (res == DialogResult.OK)
                {
                    // Начало игры
                }
            });
        }
        public string ShowListGames(List<string> games)
        {
            LobbyModel model = new LobbyModel(games);
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                return model.SelectedGame;
            }
            else
            {
                ShowMainMenuDialog();
            }
            return null;
        }
        StartGameModel model;
        public async void ShowStartGameModel(List<string> players)
        {
            await Task.Run(() =>
            {
                model = new StartGameModel(players);
                model.ShowDialog();
            });
        }
        public void AddPlayerToStartGameModel(string player)
        {
            if (model != null)
            {
                model.AddPlayer(player);
            }
            if (adminLobby != null)
            {
                adminLobby.AddPlayer(player);
            }
        }
    }
}

