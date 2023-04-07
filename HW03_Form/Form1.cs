using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW03_Form
{
    public partial class Form1 : Form
    {
        IChecked check = new DefaultChecked();
        ListPart list = new ListPart();
        bool change = false;
        Participant a;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked ) { button1.Enabled = true; }
            else { button1.Enabled = false; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //
                // Проверки 
                //
                if (!check.CheckFirstname(textBox1.Text))
                    throw new Exception("Неправильный ввод имени");
                if (!check.CheckLastname(textBox2.Text))
                    throw new Exception("Неправильный ввод фамилии");
                if (!check.CheckEmail(textBox3.Text))
                    throw new Exception("Неправильный ввод почты");
                if (!check.CheckPhone(maskedTextBox1.Text))
                    throw new Exception("Неверный формат номера телефона");
                
                Participant part = new Participant(textBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox1.Text);
                if (!list.participants.Contains(part))
                {
                    if (!change)
                    {
                        list.Add(part);
                        listBox1.Items.Add(part);
                    }
                    else
                    {
                        list.participants[list.participants.FindIndex(t => t == a)] = part;
                        listBox1.Items[listBox1.SelectedIndex] = part;
                        button1.Text = "Участвовать";
                        change= false;
                    }
                }
                else
                { MessageBox.Show("Данный учасник уже существует"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK); }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if(listBox.SelectedItem == null)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Participant a = (Participant)listBox1.SelectedItem;
            list.Remove(a);
            listBox1.Items.Remove(a);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            a = (Participant)listBox1.SelectedItem;
            textBox1.Text = a.FirstName;
            textBox2.Text = a.LastName;
            textBox3.Text = a.Email; // почему то меняет эти значения
            maskedTextBox1.Text = a.NumberPhone; // вот это
            button1.Text = "Изменить";
            change = true;
        }

        string path = "D:\\Visual_Studio\\WinForms\\HW03_Form\\1.xml";

        // сохранить
        private void button4_Click(object sender, EventArgs e)
        {
            list.Save(path);
        }

        // загрузить
        private void button5_Click(object sender, EventArgs e)
        {
            list.Load(path);
            listBox1.Items.Clear();
            foreach(Participant var in list.participants)
            {
                listBox1.Items.Add(var);
            }
        }
    }
}
