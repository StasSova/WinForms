using _Client2.Models;
using MessageDll;
using Paint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static _Client2.ConnectWithServer;
using static _Client2.Program;

namespace _Client2
{
    internal class ViewController
    {
        fLobby model;
        public string ShowConnect()
        {
            string name = null,
                        ip = null;
            fConnect model = new fConnect();
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                name = model.NickName;
                ip = model.IP;
                return string.Join("|", name, ip);
            }
            return null;
        }
        public string ShowMenu() 
        {
            string Result = null;
            fMenu model = new fMenu();
            DialogResult res = model.ShowDialog();
            // если нажали хоть на какую-либо кнопку
            if (res == DialogResult.OK)
            {
                if (model.ResultClick == "[LIST_GROUP]")
                {
                    Result = model.ResultClick;
                }
                else
                {
                    Result = ShowGameName();
                }
            }
            return Result;
        }
        private string ShowGameName()
        {
            string name = null;
            fGameName model = new fGameName();
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK) 
            {
                name = model._name;
            }
            return name;
        }
        public string ShowLobby(TcpClient client, MyMessage mes, bool isLeader, NetworkStream net, string player)
        {
            string _res = null;
            model = new fLobby(client, mes,isLeader, net,player);
            try
            {
                DialogResult res = model.ShowDialog();
                if (res == DialogResult.Cancel)
                {
                    _res = "Exit";
                }
                else if (res == DialogResult.OK) 
                {
                    _res = "[START_GAME]";
                }
            }
            catch (Exception ex) { _res = ex.Message; } // [START_GAME] 
            return _res;
        }
        public string ShowLobby(TcpClient client, MyMessage mes, bool isLeader, NetworkStream net, string player,List<string> otherPlayers)
        {
            string _res = null;
            model = new fLobby(client, mes,isLeader, net, player, otherPlayers);
            try
            {
                DialogResult res = model.ShowDialog();
                if (res == DialogResult.Cancel)
                {
                    _res = "Exit";
                }
                else if (res == DialogResult.OK)
                {
                    _res = "[START_GAME]";
                }
            }
            catch (Exception ex) { _res = "ТУТА"; }//ex.Message; } // [START_GAME] 
            return _res;
        }
        public string ShowListGame(List<string> games)
        {
            fListGame model = new fListGame(games);
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                return model.SelectedGame;
            }
            return null;
        }

        // 
        // Сама игра
        // 
        public string ShowFirstGame(string me)
        {
            fFirstGame model = new fFirstGame(me);
            string _res = null;
            try
            {
                DialogResult res = model.ShowDialog();
                if (res == DialogResult.OK)
                {
                    _res = model._history;
                }
                else
                {
                    _res = "Exit";
                }
            }
            catch(Exception ex) { _res = "Exit"; }
            return _res;
        }
        public Bitmap ShowDrawFromTheme(string theme)
        {
            Bitmap bitmap= null;
            Draw draw = new Draw(theme,60);
            DialogResult result = draw.ShowDialog();
            if (result == DialogResult.OK)
            {
                bitmap = draw._result;
            }
            return bitmap;
        }
        public string ShowPictureDescription(Bitmap bitmap)
        {
            string res = null;
            fDescribing desc = new fDescribing(bitmap,20);
            DialogResult result = desc.ShowDialog();
            if (result == DialogResult.OK) 
            {
                res = desc.descr;
            }
            return res;
        }
        public string ShowHistory(TcpClient client, MyMessage mes, NetworkStream net) 
        {
            string res = null;
            fHistory model = new fHistory(client,mes,net);
            DialogResult dRes = model.ShowDialog();
            if (dRes == DialogResult.OK)
            {

            }
            else
            {

            }
            return res;
        }
    }
}
