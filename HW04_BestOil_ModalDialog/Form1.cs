using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HW04_BestOil_ModalDialog
{
    public partial class Form1 : Form
    {
        private Cafe cafe { get; set; }
        private CafeConstr cafeConstr { get; set; }
        private Oil oil { get; set; }
        private OilConstructor oilConstr { get; set; }
        MainMenu MyMenu;
        MenuItem menu, OilConstr, CafeConstr;
        public Form1()
        {
            InitializeComponent();
            //
            // Menu
            //
            cafe = new Cafe();
            MyMenu = new MainMenu();

            menu = new MenuItem("Редактор");
            MyMenu.MenuItems.Add(menu);

            oil= new Oil();
            OilConstr = new MenuItem("Автозаправка");
            OilConstr.Click += new EventHandler(Oil_Constr);
            menu.MenuItems.Add(OilConstr);

            CafeConstr = new MenuItem("Кафе");
            CafeConstr.Click += new EventHandler(Cafe_Constr);
            menu.MenuItems.Add(CafeConstr);

            this.Menu = MyMenu;
        }
        // Cafe
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = cafe.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.Text = cafe.Check;
            }
        }
        // Oil
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = oil.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox2.Text = oil.Check;
            }
        }
        // Next
        private void button3_Click(object sender, EventArgs e)
        {
            cafe.Reset();
            oil.Reset();
            textBox1.Text = "0";
            textBox2.Text = "0";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
        }

        private void Oil_Constr(object sender, EventArgs e)
        {
            oilConstr = new OilConstructor(oil.Fuel);
            DialogResult res = oilConstr.ShowDialog();
            if (res == DialogResult.OK)
            {
                oil.Fuel = oilConstr.Fuel;
            }
        }
        private void Cafe_Constr(object sender, EventArgs e)
        {
            cafeConstr = new CafeConstr(cafe.Food);
            DialogResult res = cafeConstr.ShowDialog();
            if (res == DialogResult.OK)
            {
                cafe.Food = cafeConstr.Change();
                cafe.Redraw();
            }
        }
    }
}
