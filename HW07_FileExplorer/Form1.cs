using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HW07_FileExplorer
{
    public partial class Form1 : Form
    {
        ImageList image_list1 = new ImageList(); // список изображений для хранения малых значков
        ImageList image_list2 = new ImageList(); // список изображений для хранения больших значков
        ImageList image_list3 = new ImageList(); // список изображений папок

        List<TreeNode> ForwardHistory = new List<TreeNode>();
        List<TreeNode> BackHistory = new List<TreeNode>();
        public Form1()
        {
            InitializeComponent();
            //
            // ИКОНКИ
            //
            #region
            // глубина цвета изображений
            image_list1.ColorDepth = ColorDepth.Depth32Bit;
            // установим размер изображения
            image_list1.ImageSize = new Size(16, 16);
            // ассоциируем список маленьких изображений с ListView
            listView1.SmallImageList = image_list1;
            // глубина цвета изображений
            image_list2.ColorDepth = ColorDepth.Depth32Bit;
            // установим размер изображения
            image_list2.ImageSize = new Size(32, 32);
            // ассоциируем список маленьких изображений с ListView
            listView1.LargeImageList = image_list2;
            // добавляем папку
            image_list3.Images.Add(Properties.Resources.folder);
            image_list3.Images.Add(Properties.Resources.hdd);
            treeView1.ImageList = image_list3;
            #endregion
            //
            // прочие
            //
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            //
            // Начальная инициализация дерева
            //
            #region
            // При изменении размеров формы автоматически будет изменяться размер дерева
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            string[] LD = System.IO.Directory.GetLogicalDrives();
            // получаем корневые узлы
            foreach (string logicalDisk in LD)
            {
                treeView1.Nodes.Add(logicalDisk);
            }
            //корневым узлам добавляем потомков
            Icon icon = new Icon("D:\\Visual_Studio\\WinForms\\HW07_FileExplorer\\icons\\CLSDFOLD.ICO");
            foreach (TreeNode node in treeView1.Nodes)
            {
                string path = node.FullPath;
                string[] directories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly)
                .Where(dir => (File.GetAttributes(dir) & FileAttributes.Hidden) != FileAttributes.Hidden).ToArray();
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                foreach (string dir in directories)
                {
                    node.Nodes.Add(dir, Path.GetFileName(dir));
                }
            }
            #endregion
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                TreeNode node = treeView1.SelectedNode;
                string[] files = Directory.GetFiles(node.Name);
                string[] directories = Directory.GetDirectories(node.Name);
                Icon icon = new Icon(@"D:\Visual_Studio\WinForms\HW07_FileExplorer\icons\CLSDFOLD.ICO");
                image_list1.Images.Clear();
                image_list2.Images.Clear();
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                foreach (string dir in directories)
                {
                    listView1.Items.Add(Path.GetFileName(dir), 0);
                }
                int index = 1;
                foreach (string file in files)
                {
                    try
                    {
                        icon = Icon.ExtractAssociatedIcon(file);
                        image_list1.Images.Add(icon);
                        image_list2.Images.Add(icon);
                        listView1.Items.Add(Path.GetFileName(file), index++);
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }
        }
        bool auto = false;
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode Node = e.Node;
            if (!auto)
            { 
                BackHistory.Add(Node);
                if (toolStripButton1.Enabled == false) toolStripButton1.Enabled = true;
                Icon icon = new Icon("D:\\Visual_Studio\\WinForms\\HW07_FileExplorer\\icons\\CLSDFOLD.ICO");
                foreach (TreeNode node in Node.Nodes)
                {
                    try
                    {
                        string[] directories = Directory.GetDirectories(node.Name);
                        image_list1.Images.Add(icon);
                        image_list2.Images.Add(icon);
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        foreach (string dir in directories)
                        {
                            TreeNode temp = new TreeNode();
                            temp.Text = dir;
                            temp.Name = Path.GetFileName(dir);
                            node.Nodes.Add(temp.Text,temp.Name);
                        }
                    }
                    catch (Exception ex) { }
                }
                auto = false;
            }
        }

        //назад
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (BackHistory.Count != 0)
            {
                auto = true;
                if (BackHistory.Last().IsExpanded)  // если открыт, 
                {
                    BackHistory.Last().Collapse();  // закрыть
                }
                else BackHistory.Last().Expand();   // иначе открыть
                ForwardHistory.Add(BackHistory.Last()); // добавляем "вперед"
                BackHistory.Remove(BackHistory.Last()); // удаляем "назад"
                if (BackHistory.Count == 0) toolStripButton1.Enabled = false; // отключаем назад
                toolStripButton2.Enabled = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ForwardHistory.Count != 0)
            {
                if (ForwardHistory.Last().IsExpanded)
                {
                    ForwardHistory.Last().Collapse();
                }
                else ForwardHistory.Last().Expand();
                ForwardHistory.Remove(ForwardHistory.Last());
                if (ForwardHistory.Count == 0) toolStripButton2.Enabled = false;
            }
        }
    }
}
