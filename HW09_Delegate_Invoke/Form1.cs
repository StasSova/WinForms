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

namespace HW09_Delegate_Invoke
{
    public partial class Form1 : Form
    {
        ListView listView1;
        Button btnSearch;
        Button btnStop;
        TextBox txtMask;
        TextBox txtWord;
        ComboBox comboBox1;
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Init()
        {
            if (!Controls.Contains(listView1)) listView1 = new ListView();
            if (!Controls.Contains(btnSearch)) btnSearch = new Button();
            if (!Controls.Contains(btnStop)) btnStop = new Button();
            if (!Controls.Contains(txtMask)) txtMask = new TextBox();
            if (!Controls.Contains(txtWord)) txtWord = new TextBox();
            if (!Controls.Contains(comboBox1)) comboBox1 = new ComboBox();

            try
            {
                // listView1
                #region
                Action ListView1 = delegate
                {
                    listView1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    listView1.Location = new Point(10,60);
                    listView1.Size = new Size(this.Width-40,this.Height - 110);
                    listView1.View = View.Details;
                    listView1.Columns.Add("Имя",200);
                    listView1.Columns.Add("Тип файла",70);
                    listView1.Columns.Add("Дата изменения",150);
                    listView1.Columns.Add("Создатель",150);
                    Controls.Add(listView1);
                };
                #endregion
                // btnSearch
                #region
                Action ButSearch = delegate
                {
                    btnSearch.Text = "Найти";
                    btnSearch.Size = new Size(75,30);
                    btnSearch.Location = new Point(600,30- btnSearch.Height/2);
                    //btnSearch.Width= 30;
                    //btnSearch.Height = 75;
                    Controls.Add(btnSearch);
                };
                #endregion
                // btnStop
                #region
                Action ButStop = delegate
                {
                    btnStop.Text = "Стоп";
                    btnStop.Size = new Size(75, 30);
                    btnStop.Location = new Point(700, 30 - btnStop.Height / 2);
                    Controls.Add(btnStop);
                };
                #endregion
                // txtMask
                #region
                Action TXTMask = delegate
                {
                    txtMask.Text = "*.txt";
                    txtMask.Size = new Size(75, 30);
                    txtMask.Location = new Point(100, 30- txtMask.Height/2);
                    Controls.Add(txtMask);
                };
                #endregion
                // txtWord
                #region
                Action TXTWord = delegate
                {
                    txtWord.Size = new Size(275, 30);
                    txtWord.Location = new Point(200, 30- txtWord.Height/2);
                    Controls.Add(txtWord);
                };
                #endregion
                // comboBox1
                #region
                Action ComboBox = delegate
                {
                    string[] disk = Directory.GetLogicalDrives();
                    foreach (string diskName in disk) 
                    { comboBox1.Items.Add(diskName.Replace("\\", "")); }
                    comboBox1.SelectedIndex= 0;
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox1.Size = new Size(30, 30);
                    comboBox1.Location = new Point(500, 30 - comboBox1.Height/2);
                    Controls.Add(comboBox1);
                };
                #endregion
                this.Invoke(ListView1);
                this.Invoke(ButSearch);
                this.Invoke(ButStop);
                this.Invoke(TXTMask);
                this.Invoke(TXTWord);
                this.Invoke(ComboBox);
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(Init);
            // Старт потока
            thread.Start();
            Controls.Remove(button1);
        }
    }
}
