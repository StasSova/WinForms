using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Server.FolderGroup
{
    internal class ListGroup
    {
        private List<Group> groups;
        public ListGroup()
        {
            groups= new List<Group>();
        }
        public async void CreateGroup(string GroupName, Player player)
        {
            await Task.Run(() =>
            {
                lock (groups)
                {
                    groups.Add(new Group(GroupName, player));
                }
            });
        }
        public async void RemoveGroup(string GroupName)
        {
            await Task.Run(() =>
            {
                lock (groups)
                {
                    groups.Remove(groups.Find(d => d._name == GroupName));
                }
            });
        }
        public void AddPlayerToGroup(string GroupName, Player player)
        {
            Group FindGroup = groups.First(d => d._name == GroupName);
            if (FindGroup != null)
            {
                FindGroup.AddToGroup(player);
            }
            else
            {
                //MessageBox.Show("Группа не найденна");
            }
        }
        public async void RemovePlayerFromGroup(Player player)
        {
            await Task.Run(() =>
            {
                lock (groups)
                {
                    foreach (Group group in groups) 
                    {
                        if (group._players.Contains(player))
                        {
                            group._players.Remove(player);
                            break;
                        }
                    }
                }
            });
        }
        public List<string> GetAllGroupName() 
        { 
            List<string> GroupName= new List<string>();
            lock (groups) 
            { 
                foreach (var item in groups)
                {
                    GroupName.Add(item._name);
                }
            }
            return GroupName;
        }
        public Group GetGroup(string name)
        {
            Group group = null;
            lock(groups)
            {
                group = groups.First(d => d._name == name);
            }
            return group;
        }
        public Group GetGroup(Player player)
        {
            Group group = null;
            lock (groups)
            {
                group = groups.Find(d => d._players.Contains(player));
            }
            return group;
        }
    }
}
