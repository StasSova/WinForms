using Client.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    internal class View
    {
        private bool isBlack = false;
        public string ConnectToServer()
        {
            fConnect model = new fConnect();
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                return model.res;
            }
            else if (res == DialogResult.Cancel) 
            {
                throw new Exception("[EXIT]");           
            }
            return null;
        }
        public string Menu()
        {
            fMenu model = new fMenu(isBlack);
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK) 
            {
                isBlack = model.IsBlack; // сохраняем выбранную тему
                // если выбрали новая игра
                if (model.Result == "[NEW_GAME]")
                {
                    string name =  NameOfTheGame();
                    if (name == "[CANCEL]")
                    {
                        return "[CANCEL]";
                    }
                    else return "*" + name;
                }   
                // если выбрали присоединится к игре
                else if (model.Result == "[CONNECT_TO_GAME]")
                {
                    // код для отправки запроса на сервер
                    return "[LIST_GROUP]";
                }
            }
            else
            {
                throw new Exception("[EXIT]");
            }
            return null;
        }
        private string NameOfTheGame()
        {
            fNameOfTheGame model = new fNameOfTheGame(isBlack);
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK) 
            {
                return model._name;
            }
            else if (res == DialogResult.Cancel)
            {
                return "[CANCEL]";
            }
            return null;
        }
        public string ListGame(string names)
        {
            fListGame model = new fListGame(isBlack, names);
            DialogResult res = model.ShowDialog();
            if (DialogResult.OK == res)
            {
                return model.SelectedGame;
            }
            else
            {
                return "[CANCEL]";
            }
        }
        public string Lobby(TcpClient client,string players)
        {
            fLobby model = new fLobby(isBlack, client, players);
            DialogResult res = model.ShowDialog();
            // запуск игры 
            if (res == DialogResult.OK)
            {
                return "[START]";
            }
            // Удаление игры
            else if (res == DialogResult.Cancel)
            {
                return "[REMOVE]";
            }
            // Выход учасника
            else if (res == DialogResult.Abort)
            {
                return "[EXIT]";
            }
            // автоматический выход
            else if (res == DialogResult.Retry)
            {
                MessageBox.Show("Игра была удаленна лидером", "Error",MessageBoxButtons.OK);
                return "[MENU]";
            }
            return null;
        }
        public string FirstGame()
        {
            fFirstGame model = new fFirstGame(isBlack);
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                return model.History;
            }
            else
            {
                // удаление с игры и команды
                return "[EXIT]";
            }
        }
        public Bitmap Draw(string theme)
        {
            Paint.Draw model= new Paint.Draw(isBlack, theme, 60);
            DialogResult res = model.ShowDialog();
            if (res == DialogResult.OK)
            {
                return model._result;
            }
            else
                return null;
        }
        public string ShowPictureDescription(Bitmap btm)
        {
            fDescr model = new fDescr(isBlack, btm); // 3й параметр время по ум. = 20
            DialogResult res =model.ShowDialog();
            if (res == DialogResult.OK)
            {
                return model.Theme == null ? "" : model.Theme;
            }
            return null;
        }
        public void History(TcpClient client)
        {
            fHistory model = new fHistory(isBlack, client);
            model.ShowDialog();
        }
    }
}
