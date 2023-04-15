using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW06_Millioners
{
    public partial class AddQuest : Form
    {
        public List<Question> list { get; set; }
        Form1 ParForm;
        public AddQuest(Form1 form)
        {
            InitializeComponent();
            list = new List<Question>();
            ParForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Add(new Question(textBox1.Text,
                (textBox2.Text,true),
                (textBox3.Text, false),
                (textBox4.Text, false),
                (textBox5.Text, false)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }
        public void CloseDialog()
        {
            this.Close();
        }
    }
}
