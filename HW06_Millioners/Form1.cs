using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public struct Question
{
    public string question { get; set; }
    public List<KeyValuePair<string, bool>> answer { get; set; }
    public Question (string quest, params (string,bool)[] answer)
    {
       this.question = quest; // вопрос
       this.answer = new List<KeyValuePair<string, bool>>();
       // ответы
       for (int i = 0; i < answer.Length;i++)
       {
           this.answer.Add(new KeyValuePair<string, bool>(answer[i].Item1, answer[i].Item2));
       }
    }
    public override string ToString()
    {
        return question;
    }
}
namespace HW06_Millioners
{
    
    public partial class Form1 : Form
    {
        List<KeyValuePair<int,int>> PriceList= new List<KeyValuePair<int,int>>();
        internal List<Question> Questions = new List<Question>();
        internal List<Question> Removed = new List<Question>();
        SoundPlayer player = new SoundPlayer();
        int Number = 0;
        bool First = true;
        bool Two = true;
        bool Three = true;

        bool VisibleOne = false;
        bool VisibleTwo = false;
        bool VisibleThree = false;

        bool start = true;
        private void NextQuest(int pos)
        {
            player.Stop();
            if (!start)
            { 
                player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\gong.wav";
                player.PlaySync();
            }
            Random r = new Random();
            // случайный выбор вопроса
            Question quest = Questions[r.Next(0,Questions.Count)];
            textBox1.Text = quest.question;
            button7.Text = quest.answer[0].Key;
            button8.Text = quest.answer[1].Key;
            button9.Text = quest.answer[2].Key;
            button10.Text = quest.answer[3].Key;
            listView1.Items[pos].BackColor = Color.RosyBrown;
            // закрашываем предыдущее
            if (pos > 0) listView1.Items[pos-1].BackColor = Color.Black;
            // подкрашиваем гарантированный выигрыш 
            if (pos % 5 == 0 && pos > 0)
                listView1.Items[pos - 1].BackColor = Color.Green;
        }
        public Form1()
        {
            InitializeComponent();
            //
            // PriceList
            //
            #region
            PriceList.Add(new KeyValuePair<int, int>(1, 100));
            PriceList.Add(new KeyValuePair<int, int>(2, 200));
            PriceList.Add(new KeyValuePair<int, int>(3, 300));
            PriceList.Add(new KeyValuePair<int, int>(4, 500));
            PriceList.Add(new KeyValuePair<int, int>(5, 1000));
            PriceList.Add(new KeyValuePair<int, int>(6, 2000));
            PriceList.Add(new KeyValuePair<int, int>(7, 4000));
            PriceList.Add(new KeyValuePair<int, int>(8, 8000));
            PriceList.Add(new KeyValuePair<int, int>(9, 16000));
            PriceList.Add(new KeyValuePair<int, int>(10, 32000));
            PriceList.Add(new KeyValuePair<int, int>(11, 64000));
            PriceList.Add(new KeyValuePair<int, int>(12, 125000));
            PriceList.Add(new KeyValuePair<int, int>(13, 250000));
            PriceList.Add(new KeyValuePair<int, int>(14, 500000));
            PriceList.Add(new KeyValuePair<int, int>(15, 1000000));
            #endregion
            foreach (var kvp in PriceList)
            {
            listView1.Items.Add(string.Format(kvp.Key + "-\t" + kvp.Value));
                if (kvp.Key %5 == 0)
                    listView1.Items[listView1.Items.Count-1].BackColor = Color.Red;
            }
            //
            // Помощь зала
            //
            panel1.Visible = false;
            pictureBox1.Visible = false;
            label5.Visible = false;

            player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\begin.wav";
            player.Play();
            //
            // Questions
            //
            
            #region
            Questions.Add(new Question("Как называется место на берегу, где обитают тюлени?",
                ("Лежбище", true),
                ("Стойбище", true),
                ("Пастбище", true),
                ("Гульбище", true)));
            Questions.Add(new Question("Как мировая пресса называла премьер-министра Великобритании Маргарет Тэтчер?",
                ("Железная леди", true),
                ("Стальная леди", true),
                ("Оловянный солдатик", true),
                ("Крепкий орешек", true)));
            Questions.Add(new Question("Какой из этих городов южнее остальных?",
                ("Каир", true),
                ("Токио", false),
                ("Мадрид", false),
                ("Сан-Франциско", false)));
            Questions.Add(new Question("Через какой город мира проходит нулевой меридиан?",
                ("Гринвич", true),
                ("Гринсборо", false),
                ("Глазго", false),
                ("Гронинген", false)));
            Questions.Add(new Question("Какая птица является символом Новой Зеландии?",
                ("Киви", true),
                ("Жако", false),
                ("Эму", false),
                ("Казуар", false)));
            Questions.Add(new Question("Какого короля англичане прозвали \"Львиное сердце\"?",
                ("Ричард I", true),
                ("Вильгельм I", false),
                ("Георг I", false),
                ("Генрих I", false)));
            Questions.Add(new Question("Как в народе называются финансовые институты, обещающие вкладчикам золотые горы?",
                ("Пирамиды", true),
                ("Гробницы", false),
                ("Захоронения", false),
                ("Сфинксы", false)));
            Questions.Add(new Question("Какая награда вручается вместе с присвоением звания Героя России?",
                ("Медаль \"Золотая Звезда\"", true),
                ("Медаль \"За отвагу\"", false),
                ("Орден Суворова", false),
                ("Орден мужества", false)));
            Questions.Add(new Question("В каком городе родился Вольфганг Амадей Моцарт?",
                ("Зальцбург", true),
                ("Веймар", false),
                ("Прага", false),
                ("Вена", false)));
            Questions.Add(new Question("Какую реку Юлий Цезарь перешел со словами \"Жребий брошен\"?",
                ("Рубикон", true),
                ("Припять", false),
                ("Нил", false),
                ("Евфрат", false)));
            Questions.Add(new Question("Как называется искусство аранжировки цветов?",
                ("Икебана", true),
                ("Суши", false),
                ("Кэндо", false),
                ("Харакири", false)));
            Questions.Add(new Question("Какая страна является мировым лидером по производству кофе?",
                ("Бразилия", true),
                ("Венесуэла", false),
                ("Мексика", false),
                ("Аргентина", false)));
            Questions.Add(new Question("Что труднее всего дается не трезвому человеку?",
                ("Вязать лыко", true),
                ("Трепать нервы", false),
                ("Бить баклуши", false),
                ("Витать в облаках", false)));
            Questions.Add(new Question("Как называют японских мафиози?",
                ("Якудза", true),
                ("Джакузи", false),
                ("Камикадзе", false),
                ("Коза Ностра", false)));
            Questions.Add(new Question("Участник какого из перечисленных спортивных состязаний экипирован винтовкой?",
                ("Биатлон", true),
                ("Бейсбол", false),
                ("Бадминтон", false),
                ("Бобслей", false)));
            Questions.Add(new Question("В каком канадском городе находится самая высокая в мире телебашня?",
                ("Торонто", true),
                ("Оттава", false),
                ("Ванкувер", false),
                ("Монреаль", false)));
            Questions.Add(new Question("Какой из этих романов написал не Хемингуэй?",
                ("\"Триумфальная арка\"", true),
                ("\"Фиеста\"", false),
                ("\"По ком звонит колокол\"", false),
                ("\"Острова в океане\"", false)));
            Questions.Add(new Question("В каком виде спорта прославился Евгений Кафельников?",
                ("Теннис", true),
                ("Бокс", false),
                ("Метание ядра", false),
                ("Охота на лис", false)));
            Questions.Add(new Question("Как называется пара, присутствующая на церемонии бракосочетания вместе с молодыми?",
                ("Свидетели", true),
                ("Соучастники", false),
                ("Запасные", false),
                ("Защитники", false)));
            Questions.Add(new Question("Как звали невесту Эдмона Дантеса, будущего графа Монте-Кристо?",
                ("Мерседес", true),
                ("Тойота", false),
                ("Хонда", false),
                ("Лада", false)));
            Questions.Add(new Question("Какой цвет получается при смешении синего и красного?",
                ("Фиолетовый", true),
                ("Коричневый", false),
                ("Зеленый", false),
                ("Голубой", false)));
            Questions.Add(new Question("Какая компания в Италии выпускает наибольшее количество автомобилей?",
                ("Фиат", true),
                ("Феррари", false),
                ("Ламборгини", false),
                ("Альфа Ромео", false)));
            Questions.Add(new Question("Кто из древних философов, по преданию, жил в бочке?",
                ("Диоген", true),
                ("Демокрит", false),
                ("Платон", false),
                ("Сократ", false)));
            Questions.Add(new Question("Каким из этих природных явлений А.Островский назвал свою пьесу?",
                ("Гроза", true),
                ("Снегопад", false),
                ("Шаровая молния", false),
                ("Гололед", false)));
            Questions.Add(new Question("Какой туман кажется В.Добрынину похожим на обман в одной из его песен?",
                ("Синий", true),
                ("Утренний", false),
                ("Сиреневый", false),
                ("Желтый", false)));
            Questions.Add(new Question("Кому принадлежат строки - пророчества: \"Настанет год, России черный год, Когда царей корона упадет...\"?",
                ("Лермонтов", true),
                ("Пушкин", false),
                ("Нострадамус", false),
                ("Некрасов", false)));
            Questions.Add(new Question("Как называется маскировочная окраска военной техники и обмундирования?",
                ("Камуфляж", true),
                ("Макияж", false),
                ("Хаки", false),
                ("Камуфлет", false)));
            Questions.Add(new Question("Какой материк омывается всеми четырьмя океанами?",
                ("Евразия", true),
                ("Северная Америка", false),
                ("Австралия", false),
                ("Южная Америка", false)));
            Questions.Add(new Question("Какие машины предпочитал угонять Юрий Деточкин?",
                ("Волга", true),
                ("Победа", false),
                ("Иномарки", false),
                ("Жигули", false)));
            #endregion
            NextQuest(Number);
            start = false;
        }
        // Click Answer
        private void button7_Click(object sender, EventArgs e)
        {
            player.Stop();

            Button button = (Button)sender;
            if (VisibleOne) 
            { 
                button7.BackColor = Color.Black;
                button8.BackColor = Color.Black;
                button9.BackColor = Color.Black;
                button10.BackColor = Color.Black;
            }
            if (VisibleTwo) { pictureBox1.Visible = false; label5.Visible = false; }
            if (VisibleThree) panel1.Visible = false;
            // сперва находим по вопросу, а потом из этого находим правильный ответ
            Question temp = Questions.Where(t => t.question == textBox1.Text).FirstOrDefault();
            Removed.Add(temp);
            Questions.Remove(temp);
            if (button.Text == temp.answer.Where(t => t.Value == true).FirstOrDefault().Key)
            {
                player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\true.wav";
                //MessageBox.Show("Правильный ответ");
                button.BackColor = Color.Green;
                if (Number < Questions.Count)
                {
                    player.PlaySync();
                    NextQuest(++Number);
                }
                // последний вопрос
                else
                {
                    MessageBox.Show("Вы выиграли: " + PriceList[PriceList.Count - 1].Value);
                    button1_Click(sender, e);
                }
                button.BackColor = Color.Black;
            }
            else
            {
                player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\false.wav";
                player.PlaySync();
                //MessageBox.Show("Не правильный ответ");
                if (Number >= 5)
                {
                    int i = 5;
                    for (; i <= Number; i+=5) { }
                    MessageBox.Show($"Вы заработали: {PriceList[i-6].Value}");
                }
                else
                {
                    MessageBox.Show($"Вы лузер");
                }

            }
        }
        private void Restart()
        {
            First = true;
            Two = true;
            Three = true;
            panel1.Visible = false;
            pictureBox1.Visible = false;
            label5.Visible = false;

            player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\begin.wav";
            player.PlaySync();
            button5.Image = Properties.Resources._1;
            button4.Image = Properties.Resources._2;
            button6.Image = Properties.Resources._3;
            Questions.AddRange(Removed);
            for (int i = 5; i < listView1.Items.Count; i += 5)
            {
                listView1.Items[i - 1].BackColor = Color.Red;
            }
            listView1.Items[Number].BackColor = Color.Black;
            Number = 0;
            player.Stop();
            player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\begin.wav";
            player.PlaySync();
            NextQuest(Number);
        }
        // 50 на 50
        private void button5_Click(object sender, EventArgs e)
        {
            button5.Image = Properties.Resources._4;
            if (First)
            {
                player.Stop();
                player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\zal.wav";
                player.PlaySync();
                First= false;
                VisibleOne = true;
                Question temp = Questions.Where(t => t.question == textBox1.Text).First();

                if (button7.Text == temp.answer.Where(t => t.Value == true).First().Key)
                { button7.BackColor = Color.Green; button8.BackColor = Color.Green; }

                if (button8.Text == temp.answer.Where(t => t.Value == true).First().Key)
                { button8.BackColor = Color.Green; button9.BackColor = Color.Green; }

                if (button9.Text == temp.answer.Where(t => t.Value == true).First().Key)
                { button9.BackColor = Color.Green; button10.BackColor = Color.Green; }

                if (button10.Text == temp.answer.Where(t => t.Value == true).First().Key)
                { button10.BackColor = Color.Green; button7.BackColor = Color.Green; }
            }

        }
        // звонок другу
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Image = Properties.Resources._5;
            if (Two)
            {
                player.Stop();
                player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\zvonok.wav";
                player.PlaySync();
                Two = false;
                VisibleTwo = true;
                pictureBox1.Visible = true;
                label5.Visible = true;
                label5.Text = $"Я думаю {Questions[Number].answer[new Random().Next(0,3)].Key}";
            }
        }
        // помощь зала
        private void button6_Click(object sender, EventArgs e)
        {
            
            int max = 100;
            Random r = new Random();
            button6.Image = Properties.Resources._6;
            if (Three)
            {
                player.Stop();
                player.SoundLocation = "D:\\Visual_Studio\\WinForms\\HW06_Millioners\\Ресурсы\\Music\\zal.wav";
                player.PlaySync();
                Three = false;
                VisibleThree = true;
                int number = r.Next(0, max);
                number = r.Next(0, max);
                max -= number;
                label1.Text = $"{number}% {Questions[Number].answer[0].Key}";
                number = r.Next(0, max);
                max -= number;
                label2.Text = $"{number}% {Questions[Number].answer[1].Key}";
                number = r.Next(0, max);
                max -= number;
                label3.Text = $"{number}% {Questions[Number].answer[2].Key}";
                label4.Text = $"{max}% {Questions[Number].answer[3].Key}";
                panel1.Visible = true;
            }
        }
        // Restart
        private void button1_Click(object sender, EventArgs e)
        {
            Restart();
        }
        // Close
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Restart
        private void сначалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
        // Close
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        // AddQuest
        private void добавитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddQuest add = new AddQuest(this);
            if (add.ShowDialog() == DialogResult.OK)
            {
                Questions.AddRange(add.list);
            }
        }
        // Remove&Change Quest
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemoveQuest remove = new RemoveQuest(Questions);
            if (remove.ShowDialog() == DialogResult.OK)
            {
                Questions = remove.questions;
            }
        }
    }
}
