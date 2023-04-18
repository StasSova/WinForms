using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW08_Thread_Forms
{
    public partial class Form1 : Form
    {
        List<string> paths = new List<string>();
        string Disk;
        string Mask;

        public Form1()
        {
            InitializeComponent();
            //
            // Buttons
            //
            button2.Enabled = false;
            // 
            // Диски
            //
            string[] LD = System.IO.Directory.GetLogicalDrives();
            foreach (string logicalDisk in LD)
            {
                comboBox1.Items.Add(logicalDisk);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void AllSearch()
        {
            List<string> directors = new List<string>();
            directors.AddRange(Directory.GetDirectories(Disk));
            List<string> temp = new List<string>();
            bool end = false;
            int i = 0;
            do
            {
                temp.Clear();
                for (; i < directors.Count; i++)
                {
                    try { temp.AddRange(Directory.GetDirectories(directors[i])); }
                    catch (Exception ex) { }
                }
                directors.AddRange(temp);
            } while (temp.Count != 0 && i != directors.Count);
            // в Папка получаем все файлы, которые соответсвтуют данным условия
            paths = directors;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (checkBox1.Checked)
            {
                listView1.Clear();
                Disk = comboBox1.Text;
                Mask = textBox1.Text;
                Thread allThread = new Thread(AllSearch);
                button1.Enabled = false;
                allThread.Start();
                // ожидаем завершения потока
                allThread.Join();
                button1.Enabled = true;
                label5.Text = paths.Count.ToString();
                foreach (string path in paths)
                {
                    try
                    {
                        string[] files = Directory.GetFiles(path, textBox1.Text);
                        foreach (string file in files)
                        {
                            listView1.Items.Add(file);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            else
            {
                listView1.Clear();
                string[] files = Directory.GetFiles(comboBox1.Text, textBox1.Text);
                foreach (string file in files)
                { listView1.Items.Add(file); }
            }
        }
    }
}
