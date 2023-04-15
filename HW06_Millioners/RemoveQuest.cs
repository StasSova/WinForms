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
    public partial class RemoveQuest : Form
    {
        public List<Question> questions { get; set; }
        public RemoveQuest(List<Question> list)
        {
            InitializeComponent();
            questions = list;
            foreach(Question question in questions) 
            { comboBox1.Items.Add(question); }
            comboBox1.SelectedIndex = 1;
            Redraw();

        }
        // сохранить
        private void button1_Click(object sender, EventArgs e)
        {
            Question temp = new Question();
            temp.question = comboBox1.Text;
            temp.answer = new List<KeyValuePair<string, bool>>();
            temp.answer.Add(new KeyValuePair<string, bool>(textBox1.Text, true));
            temp.answer.Add(new KeyValuePair<string, bool>(textBox2.Text, false));
            temp.answer.Add(new KeyValuePair<string, bool>(textBox3.Text, false));
            temp.answer.Add(new KeyValuePair<string, bool>(textBox4.Text, false));
            MessageBox.Show(questions[comboBox1.SelectedIndex].ToString());
            questions.Remove(questions[comboBox1.SelectedIndex]);
            questions.Add(temp);
            Redraw();
        }
        // удалить
        private void button2_Click(object sender, EventArgs e)
        {
            if (questions.Count < 16)
            {
                MessageBox.Show("Нельзя удалить вопрос.\nМинимальное количество вопросов 16");
            }
            else
            {
                questions.Remove(questions[comboBox1.SelectedIndex]);
                Redraw();
            }
        }
        // отмена (сброс)
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = questions[comboBox1.SelectedIndex].answer[0].Key;
            textBox2.Text = questions[comboBox1.SelectedIndex].answer[1].Key;
            textBox3.Text = questions[comboBox1.SelectedIndex].answer[2].Key;
            textBox4.Text = questions[comboBox1.SelectedIndex].answer[3].Key;
        }
        // завершить
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Question temp = questions[comboBox1.SelectedIndex];
            textBox1.Text = temp.answer[0].Key;
            textBox2.Text = temp.answer[1].Key;
            textBox3.Text = temp.answer[2].Key;
            textBox4.Text = temp.answer[3].Key;
        }
        private void Redraw()
        {
            comboBox1.Items.Clear();
            foreach (Question question in questions)
            { comboBox1.Items.Add(question); }
            comboBox1.SelectedIndex = 1;
        }
    }
}
