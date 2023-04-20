using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace HW10_KillProcess
{
    public partial class Form1 : Form
    {
        Process[] processes;
        Process process;
        public Form1()
        {
            InitializeComponent();
            processes = Process.GetProcesses().Where(t=> t.Responding).ToArray();
            foreach(Process process in processes) 
            { 
                listView1.Items.Add(process.ProcessName);
                listView1.Items[listView1.Items.Count-1].SubItems.Add(process.Id.ToString());
            }
        }

        private void завершитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedProcessName = listView1.SelectedItems[0].Text;
                int SelectedProcessId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
                Process selectedProcess = processes.FirstOrDefault
                    (p =>   p.ProcessName == selectedProcessName &&
                            p.Id == SelectedProcessId);
                if (selectedProcess != null)
                {
                    //selectedProcess.Kill();
                    MessageBox.Show($"Процесс {selectedProcessName}, {SelectedProcessId} завершен");
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
        }
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            processes = Process.GetProcesses().Where(t => t.Responding).ToArray();
            foreach (Process process in processes)
            {
                listView1.Items.Add(process.ProcessName);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(process.Id.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            process = new Process();
            try 
            { 
                process.StartInfo.FileName = textBox1.Text; 
                process.Start();
                listView1.Items.Add(process.ProcessName);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(process.Id.ToString());
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
