using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01_FirstProject
{
    public partial class Form1 : Form
    {
        int a = 0;
        public Form1()
        {
            InitializeComponent();
            string temp = "Короче, я Стас";
            a += temp.Length;
            MessageBox.Show(temp,"Приветсвтвие",MessageBoxButtons.OK);

            temp = "Учусь в ШАГе";
            a += temp.Length;
            MessageBox.Show(temp,"Образование", MessageBoxButtons.OK);

            temp = "Сказали сделать так";
            a += temp.Length;
            MessageBox.Show("Сказали сделать так", $"Кол-во симовлов:{a}");
        }
    }
}
