using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW02_Quiz
{
    public partial class Form1 : Form
    {
        int Max = 120;
        int Min = 0;
        int Cur = 0;
        DateTime time = DateTime.Now;
        TimeSpan temp;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Maximum = Max;
            progressBar1.Minimum = Min;
            progressBar1.Value = Cur;
            timer1.Start();
        }
        //
        // Возможные варианты ответов
        //
        void True_AnswerRad(object Sender, EventArgs e)
        {
            RadioButton but = (RadioButton)Sender;
            if (but.Checked) { Cur += 10; }
            else { Cur-= 10; }
            if (checkBox16.Checked)
            progressBar1.Value = Cur;
        }
        void True_1_AnswerCheck(object Sender, EventArgs e)
        {
            CheckBox but = (CheckBox)Sender;
            if (but.Checked) { Cur += 10; }
            else { Cur -= 10; }
            if (checkBox16.Checked)
                progressBar1.Value = Cur;
        }
        void True_2_AnswerCheck(object Sender, EventArgs e)
        {
            CheckBox but = (CheckBox)Sender;
            if (but.Checked) { Cur += 10/2; }
            else { Cur -= 10/2; }
            if (checkBox16.Checked)
                progressBar1.Value = Cur;
        }
        void True_3_AnswerCheck(object Sender, EventArgs e)
        {
            CheckBox but = (CheckBox)Sender;
            if (but.Checked) { Cur += 10 / 3; }
            else { Cur -= 10 / 3; }
            if (checkBox16.Checked)
                progressBar1.Value = Cur;
        }
        void True_4_AnswerCheck(object Sender, EventArgs e)
        {
            CheckBox but = (CheckBox)Sender;
            if (but.Checked) { Cur += 10 / 4; }
            else { Cur -= 10 / 4; }
            if (checkBox16.Checked)
                progressBar1.Value = Cur;
        }
        void True_5_AnswerCheck(object Sender, EventArgs e)
        {
            CheckBox but = (CheckBox)Sender;
            if (but.Checked) { Cur += 10 / 5; }
            else { Cur -= 10 / 5; }
            if (checkBox16.Checked)
                progressBar1.Value = Cur;
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked) { progressBar1.Value = Cur; }
            else { progressBar1.Value = 0; }
        }
        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton but = (RadioButton)sender;
            if (but.Checked) { Cur += 20; }
            else { Cur -= 20; }
            if (checkBox16.Checked)
                progressBar1.Value = Cur;
        }
        //
        // Завершения
        //
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            progressBar1.Value = Cur;
            MessageBox.Show($"Количество правильных ответов: {Cur/10}/{Max/10}");
            Save();
        }

        //
        // Сохранения в файл
        //
        void Save()
        {
            try
            {
                StreamWriter answ = new StreamWriter("Answer.txt", false);
                answ.WriteLine($"{DateTime.Now}\tКоличество ответов:  {Cur/10}\\{Max/10}\tВремя: " + string.Format($"{temp.Minutes}" + ":{0:D2}", temp.Seconds));
                answ.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //
        // Таймер
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            temp = DateTime.Now.Subtract(time);
            Text = string.Format($"{temp.Minutes}"+":{0:D2}",temp.Seconds);
        }
    }
}
