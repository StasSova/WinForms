using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01_Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DialogResult res;
            Random random = new Random();
            int a = 0;
            do
            {
                do
                {   // отгадывание
                    res = MessageBox.Show($"Загаданное число: {random.Next(0, 200)}", "", MessageBoxButtons.YesNo);
                    a++;
                } while (res == DialogResult.No);
                res = MessageBox.Show($"Количество попыток: {a}.\nСыграть ещё раз?", "Вы угадали", MessageBoxButtons.YesNo);
                a = 0;
            } while (res == DialogResult.Yes);

        }
    }
}
