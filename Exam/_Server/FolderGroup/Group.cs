using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Server.FolderGroup
{
    internal class Group
    {
        public int CurrrentNumberReadyPlayers {get; set;}
        public int MaxNumberReadyPlayers { get; set; }
        public int CurrentRound { get; set;}
        public bool InGame;
        public string _name { get; set; }
        public List<Player> _players { get; set; }
        public Group(string Name,Player player) 
        {
            _name = Name;
            _players = new List<Player> { player };
            MaxNumberReadyPlayers = _players.Count;
            InGame = false;
            CurrentRound = 0;
            CurrrentNumberReadyPlayers = 0;
        }
        public void AddToGroup(Player player)
        { 
            _players.Add(player); 
            MaxNumberReadyPlayers++;
        }
        public void RemoveFromGroup(Player player) 
        { 
            _players.Remove(player);
            MaxNumberReadyPlayers--;
        }
        public List<Player> GetPlayersWithout(Player player) 
        { 
            List<Player> res = new List<Player>(_players);
            res.Remove(player);
            return res;
        }
        public List<string> GetPlayersNameWithout(Player player)
        {
            List<string> res = new List<string>();
            lock(_players)
            {
                Parallel.ForEach<Player>(_players, i => 
                { 
                    if (i != player)
                    res.Add(i._nickname); 
                });
                return res;
            }
        }

        public Player NextPlayer(Player player)
        {
            int currentIndex = _players.IndexOf(player);
            int nextIndex = (currentIndex + 1) % _players.Count;
            return _players[nextIndex];
        }
        public Player PreviousPlayer(Player player, int number)
        {
            int currentPlayerIndex = _players.IndexOf(player);
            int numberOfPlayers = _players.Count;
            int targetIndex = (currentPlayerIndex - number);
            if (targetIndex < 0)
            {
                targetIndex = numberOfPlayers + targetIndex;
            }
            return _players[targetIndex];
        }
    }
}
