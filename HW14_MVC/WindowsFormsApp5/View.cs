using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Model;

namespace WindowsFormsApp5
{
    public partial class View : Form
    {
        Controller controller;
        public View()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Book> books;
            listBox1.Items.Clear();
            books = radioButton1.Checked    ? controller.GetBookAuthor(textBox1.Text)
                                            : controller.GetBookName(textBox1.Text);
            if (books.Count == 0)
            { listBox1.Items.Add("Список пуст"); }
            else
            {
                foreach (var item in books)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            controller.SaveBook(new Book(textBox2.Text,textBox3.Text));
            textBox2.Text = string.Empty; textBox3.Text = string.Empty;
        }
    }
}
