using _Server.FolderGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _Server
{
    internal class Player : IEquatable<Player>
    {
        public bool isReady;
        public TcpClient _tcp { get; set; }
        public string _nickname { get; set; }
        public History history { get; set; }
        public Player(TcpClient tcp, string nickname) 
        {
            history = new History(nickname);
            _tcp = tcp;
            _nickname = nickname;
        }
        public bool Equals(Player other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (_tcp != other._tcp)
                return false;
            if (_nickname != other._nickname)
                return false;

            return true;
        }
    }
}
