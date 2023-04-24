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

namespace HW12_SearchInFiles_Mutex
{
    public partial class Form1 : Form
    {
        Mutex mutex;
        SynchronizationContext uiContext;
        public Form1()
        {
            InitializeComponent();
            mutex = new Mutex(false,"My_Mutex");
            uiContext = SynchronizationContext.Current;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            uiContext.Send(d => listBox1.Items.Clear(), null);
            List<string> PathFiles = new List<string>();
            // получаю список всех файлов
            PathFiles.AddRange(Directory.GetFiles(textBox1.Text,"*.txt",SearchOption.AllDirectories));
            string search = textBox2.Text;
            foreach (string path in PathFiles)
            {
                await Task.Run(() => {
                    int repeat = 0;
                    using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                    {
                        string text = sr.ReadToEnd();
                        int pos = 0;
                        while ((pos = text.IndexOf(search, pos)) != -1)
                        {
                            repeat++;
                            pos += search.Length;
                        }
                    }
                    if (repeat > 0)
                    {
                        mutex.WaitOne();
                        uiContext.Send(d=>listBox1.Items.Add("-----------------------------------------"),null);
                        uiContext.Send(d => listBox1.Items.Add($"File name: {Path.GetFileName(path)}"), null);
                        uiContext.Send(d => listBox1.Items.Add($"Path: {path}"), null);
                        uiContext.Send(d => listBox1.Items.Add($"Repeat: {repeat}"), null);
                        uiContext.Send(d => listBox1.Items.Add("-----------------------------------------"), null);
                        mutex.ReleaseMutex();
                    }
                });
            }
        }
    }
}
