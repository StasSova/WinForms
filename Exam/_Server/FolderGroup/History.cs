using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Server.FolderGroup
{
    internal class History
    {
        public string author { get; set; }
        public List<string> themes { get; set; }
        public List<Bitmap> images { get; set; }
        public History(string author)
        {
            this.author = author;
            themes = new List<string>();
            images = new List<Bitmap>();
        }
    }
}
