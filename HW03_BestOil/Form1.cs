using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW03_BestOil
{
    public partial class Form1 : Form
    {
        List<KeyValuePair<string, double>> Fuel = new List<KeyValuePair<string, double>>();
        List<KeyValuePair<string, double>> Food = new List<KeyValuePair<string, double>>();
        MainMenu MyMenu;
        MenuItem Next, Reset, Exit;

        ContextMenuStrip ContMenu;
        ToolStripMenuItem cNext,cReset,cExit;
        
        public Form1()
        {
            InitializeComponent();
            //
            // Menu
            //
            MyMenu = new MainMenu();

            Next = new MenuItem("Наступний");
            Next.Select += new EventHandler(Next_Select);
            MyMenu.MenuItems.Add(Next);

            Reset = new MenuItem("Скинути");
            Reset.Select += new EventHandler(Reset_Select);
            MyMenu.MenuItems.Add(Reset);

            Exit = new MenuItem("Вихід");
            Exit.Select += new EventHandler(Exit_Select);
            MyMenu.MenuItems.Add(Exit);
            Menu = MyMenu;
            //
            // Context Menu Stip
            //
            ContMenu = new ContextMenuStrip();
            
            cNext = new ToolStripMenuItem("Наступний");
            cNext.Click += new EventHandler(Next_Select);
            ContMenu.Items.Add(cNext);

            cReset = new ToolStripMenuItem("Скинути");
            cReset.Click += new EventHandler(Reset_Select);
            ContMenu.Items.Add(cReset);

            cExit = new ToolStripMenuItem("Вихід");
            cExit.Click += new EventHandler(Exit_Select);
            ContMenu.Items.Add(cExit);
            this.ContextMenuStrip = ContMenu;
            //
            // Cafe
            //
            CocaCola.Enabled = false;
            Potato.Enabled = false;
            HotDog.Enabled = false;
            Hamburger.Enabled = false;

            Food.Add(new KeyValuePair<string, double>("Хот-Дог", 40));
            Food.Add(new KeyValuePair<string, double>("Гамбургер", 90));
            Food.Add(new KeyValuePair<string, double>("Картопля-фрі", 50));
            Food.Add(new KeyValuePair<string, double>("Кока-кола", 35));

            checkBox1.Text = Food[0].Key; label8.Text = Food[0].Value.ToString();
            checkBox2.Text = Food[1].Key; label9.Text = Food[1].Value.ToString();
            checkBox3.Text = Food[2].Key; label10.Text = Food[2].Value.ToString();
            checkBox4.Text = Food[3].Key; label11.Text = Food[3].Value.ToString();

            SumCafe.Text = "0";
            //
            // Oil
            //

            SumOfFuel.Enabled = false;

            Fuel.Add(new KeyValuePair<string, double>("A-95+",51));
            Fuel.Add(new KeyValuePair<string, double>("A-95",49));
            Fuel.Add(new KeyValuePair<string, double>("A-92",49));
            Fuel.Add(new KeyValuePair<string, double>("ДП",50));
            Fuel.Add(new KeyValuePair<string, double>("Газ",22));

            foreach (KeyValuePair<string,double> var in Fuel)
                TypeFuel.Items.Add(var.Key);
            TypeFuel.SelectedIndex = 0;

            SumOil.Text = "0";
        }
        //
        // Buttons Checked Changed
        //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { HotDog.Enabled = true; }
            else { HotDog.Enabled = false; HotDog.Text = ""; }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { Hamburger.Enabled = true; }
            else { Hamburger.Enabled = false; Hamburger.Text = ""; }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { Potato.Enabled = true; }
            else { Potato.Enabled = false; Potato.Text = ""; }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { CocaCola.Enabled = true; }
            else { CocaCola.Enabled = false; CocaCola.Text = ""; }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { Count.Enabled = true; SumOfFuel.Text = ""; }
            else { Count.Enabled = false; Count.Text = "0"; SumOil.Text = "0"; }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { SumOfFuel.Enabled = true; }
            else { SumOfFuel.Enabled = false; }
        }
        private void TypeFuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox temp = (ComboBox)sender;
            PriceFuel.Text = Fuel[temp.SelectedIndex].Value.ToString();
        }


        //
        // Logics Oil
        //
        private void Count_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Regex.IsMatch(Count.Text, @"^\d+([,]\d{1,2})?$"))
                { // Строка соответствует формату.
                    Count.ForeColor = Color.Green;
                    SumOil.Text = (Convert.ToDouble(Count.Text) * Convert.ToDouble(PriceFuel.Text)).ToString();
                }
                else
                { // Строка не соответствует формату.
                    Count.ForeColor = Color.Red;
                    SumOil.Text = "0";
                }
            }
        }
        private void SumOil_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToDouble(SumOil.Text) + Convert.ToDouble(SumCafe.Text)).ToString();
        }


        //
        // Logics Cafe
        //
        private void HotDog_TextChanged(object sender, EventArgs e)
        {
            double sum = 0;
            TextBox Text = (TextBox) sender;
            if (Regex.IsMatch(Text.Text, @"^\d+$"))
            { // Строка соответствует формату.
                Text.ForeColor = Color.Green;

            }
            else
            { // Строка не соответствует формату.
                Text.ForeColor = Color.Red;

            }

            if (checkBox1.Checked && HotDog.ForeColor == Color.Green)
                sum += Food[0].Value * Convert.ToInt32(HotDog.Text);
            if (checkBox2.Checked && Hamburger.ForeColor == Color.Green)
                sum += Food[1].Value * Convert.ToInt32(Hamburger.Text);
            if (checkBox3.Checked && Potato.ForeColor == Color.Green)
                sum += Food[2].Value * Convert.ToInt32(Potato.Text);
            if (checkBox4.Checked && CocaCola.ForeColor == Color.Green)
                sum += Food[3].Value * Convert.ToInt32(CocaCola.Text);
            SumCafe.Text = Convert.ToString(sum);
        }

        private void SumOfFuel_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (SumOfFuel.Text == "") 
                    SumOfFuel.Text = "0";
                SumOil.Text = SumOfFuel.Text;
                Count.Text = String.Format("{0:F2}", (Convert.ToDouble(SumOfFuel.Text) / Convert.ToDouble(PriceFuel.Text)));
            }
        }



        // 
        // Menu 
        // 
        private void Next_Select(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("1.txt", true);
            sw.WriteLine("\n\nBestOil");
            // тип топлива
            sw.WriteLine("Type fuel: "+TypeFuel.SelectedItem.ToString()); 
            // кол-во или цена
            if (radioButton1.Checked)
            sw.WriteLine("Count: " + Count.Text);
            sw.WriteLine("Sum: " + SumOil.Text);

            sw.WriteLine("\n\nCafe");
            if (checkBox1.Checked)
                sw.WriteLine("HotDog: " + HotDog.Text + " pcs.");
            if (checkBox2.Checked)
                sw.WriteLine("Hamburger: " + Hamburger.Text + " pcs.");
            if (checkBox3.Checked)
                sw.WriteLine("Potato: " + Potato.Text + " pcs.");
            if (checkBox4.Checked)
                sw.WriteLine("CocaCola: " + CocaCola.Text + " pcs.");
            sw.WriteLine("Sum: " + SumCafe.Text);
            sw.Close();
            Reset_Select(Reset,e);
        }

        private void Reset_Select(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            radioButton1.Checked = true;
            Count.Text = "";
            TypeFuel.SelectedIndex = 0;
        }

        private void Exit_Select(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
