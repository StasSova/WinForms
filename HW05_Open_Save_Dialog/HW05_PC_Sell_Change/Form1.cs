using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_PC_Sell_Change
{
    public partial class Form1 : Form
    {
        List<KeyValuePair<string, double>> List { get; set; }
        public Form1()
        {
            InitializeComponent();
            //
            // Items
            //
            List = new List<KeyValuePair<string, double>>();
            List.Add(new KeyValuePair<string, double>("Intel Core i5-11600K",8500));
            List.Add(new KeyValuePair<string, double>("Kingston HyperX Fury 16GB DDR4 3200 MHz",3000));
            List.Add(new KeyValuePair<string, double>("Seagate Barracuda 2TB 7200 RPM",3500));
            List.Add(new KeyValuePair<string, double>("Samsung 970 EVO Plus 500GB",4000));
            List.Add(new KeyValuePair<string, double>("NVIDIA GeForce RTX 3060 Ti ",23000));
            List.Add(new KeyValuePair<string, double>("ASUS TUF Gaming B560M-Plus Wi-Fi",5000));
            List.Add(new KeyValuePair<string, double>("Corsair CX650M 650W", 3000));
            List.Add(new KeyValuePair<string, double>("AeroCool Cylon Mini", 1500));
            List.Add(new KeyValuePair<string, double>("Redragon K552 Kumara", 900));
            List.Add(new KeyValuePair<string, double>("Logitech G502 HERO", 2000));

            // 
            // ComboBox 
            // 
            foreach (KeyValuePair <string,double> item in List)
                comboBox1.Items.Add(item.Key);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = List[comboBox1.SelectedIndex].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(List[comboBox1.SelectedIndex]);
            double sum = 0;
            foreach (KeyValuePair<string, double> Item in listBox1.Items)
            {
                sum += Item.Value;
            }
            label3.Text = sum.ToString();
        }

        private void редакторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Constr constr = new Constr(List);
            if (DialogResult.OK == constr.ShowDialog())
            {
                List = constr.List;
                // очищаем
                comboBox1.Items.Clear();
                // добавляем обновленные
                foreach (KeyValuePair<string, double> item in List)
                    comboBox1.Items.Add(item.Key);
                comboBox1.SelectedIndex = 0;
            }
        }
    }
}
