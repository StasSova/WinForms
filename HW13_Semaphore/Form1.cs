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

namespace HW13_Semaphore
{
    public partial class Form1 : Form
    {
        List<Button> buttons = new List<Button>();
        string FileName = "Т9_Words.txt";
        StreamWriter StW;
        StreamReader StR;
        Semaphore s = new Semaphore(1, 1, "Sem_File_T9");
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            #region
            foreach (Control control in Controls) 
            { 
                if (control is Button) 
                {
                    buttons.Add(control as Button);
                }
            }
            #endregion
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try { 
            buttons.Where(d =>
            d.Text == ( (e.KeyCode.ToString().Contains("D") && e.KeyCode.ToString().Length != 1) ?
                        e.KeyCode.ToString().ToLower().Substring(1) :
                        e.KeyCode.ToString().ToLower())).First().BackColor = Color.Blue;
            }
            catch { }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                buttons.Where(d =>
                d.Text == ((e.KeyCode.ToString().Contains("D") && e.KeyCode.ToString().Length != 1) ?
                            e.KeyCode.ToString().ToLower().Substring(1) :
                            e.KeyCode.ToString().ToLower())).First().BackColor = Color.GhostWhite;
            }
            catch { }
        }
        private async void добавитьВТ9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string SlectedText = richTextBox1.SelectedText;
            await Task.Run(() =>
            {
                s.WaitOne();
                    StW = new StreamWriter(FileName,true);
                    StW.WriteLine(SlectedText);
                    StW.Close();
                s.Release();
            });
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // последнее написанное слово
            string LastWord = richTextBox1.Text.Substring ((
                richTextBox1.Text.Contains(" ") ? // Проверяем на наличие пробела
                richTextBox1.Text.LastIndexOf(" ")+1 : 0 ));
            string  SelectedWord1 = "",
                    SelectedWord2 = "",
                    SelectedWord3 = "",
                    temp;
            s.WaitOne();
            StR = new StreamReader(FileName);
            do
            {
                temp = StR.ReadLine();
                if (temp.StartsWith(LastWord) && LastWord != ""){
                    if (SelectedWord1 == "") { 
                    SelectedWord1 = temp;}
                    else if (SelectedWord2 == "") {
                        SelectedWord2 = temp;}
                    else if (SelectedWord3 == "") {
                        SelectedWord3 = temp; break;}
                }
            } while (!StR.EndOfStream);
            StR.Close();
            s.Release();
            label1.Text = SelectedWord1;
            label2.Text = SelectedWord2;
            label3.Text = SelectedWord3;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string Text = ((Label)sender).Text;
            int CurrPos = richTextBox1.SelectionStart;
            int StartPos = richTextBox1.Text.LastIndexOf(" ", CurrPos); // +1
            if (StartPos == -1) StartPos = 0;
            int EndPos = richTextBox1.Text.IndexOf(" ",StartPos+1);
            if (EndPos == -1) EndPos = richTextBox1.Text.Length;
            richTextBox1.Text = richTextBox1.Text.Remove(StartPos, EndPos - StartPos);
            richTextBox1.Text = richTextBox1.Text.Insert(StartPos," " + Text + " ");
            richTextBox1.SelectionStart = StartPos + Text.Length+2;
        }
    }
}
