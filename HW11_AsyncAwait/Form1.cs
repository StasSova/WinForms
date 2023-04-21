using HW11_AsyncAwait.NewFolder1;
using HW11_AsyncAwait.Task10;
using HW11_AsyncAwait.Task7;
using HW11_AsyncAwait.Task8;
using HW11_AsyncAwait.Task9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace HW11_AsyncAwait
{
    public partial class Form1 : Form
    {
        public SynchronizationContext uiContext;
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                // очистка списка
                uiContext.Send(d => listBox1.Items.Clear(),null);
                Firm1 firm = new Firm1();
                firm.Add(new Employee1("Эмили", "Браун", new DateTime(1990, 06, 15), "+1 (555) 123-4567", "Линкольн", 25, 7));
                firm.Add(new Employee1("Максим", "Карпов", new DateTime(1985, 09, 04), "+1 (555) 234-5678", "Линкольн", 10, 3));
                firm.Add(new Employee1("Лилия", "Васильева", new DateTime(1995, 02, 22), "+1 (555) 345-6789", "Линкольн", 50, 12));
                firm.Add(new Employee1("Лилия", "Васильева", new DateTime(1995, 02, 22), "+1 (555) 345-6789", "Линкольн", 50, 12));
                firm.Add(new Employee1("Дэвид", "Мартинес", new DateTime(1983, 11, 09), "+1 (555) 456-7890", "Бродвей", 75, 8));
                firm.Add(new Employee1("София", "Джонсон", new DateTime(1991, 07, 14), "+1 (555) 567-8901", "Бродвей", 120, 5));
                firm.Add(new Employee1("Алексей", "Петров", new DateTime(1988, 04, 01), "+1 (555) 678-9012", "Линкольн", 15, 2));
                firm.Add(new Employee1("Мэри", "Дэвис", new DateTime(1997, 12, 18), "+1 (555) 789-0123", "Первая", 30, 9));
                firm.Add(new Employee1("Артем", "Смирнов", new DateTime(1989, 05, 23), "+1 (555) 890-1234", "Бродвей", 5, 1));
                firm.Add(new Employee1("Кристина", "Иванова", new DateTime(1994, 03, 11), "+1 (555) 901-2345", "Линкольн", 100, 6));
                firm.Add(new Employee1("Томас", "Мур", new DateTime(1982, 08, 29), "+1 (555) 012-3456", "Бродвей", 50, 3));

                if (string.IsNullOrEmpty(textBox1.Text)) 
                    textBox1.Text = "Линкольн";
                List<Employee1> selected = firm.employees.Where(t=> t.Street == textBox1.Text && t.NumberHouse%2 ==0).ToList();
                int sum = 0;
                foreach (Employee1 item in selected)
                {
                    // возраст
                    sum += DateTime.Now.Year - item.BirthDay.Year;
                    uiContext.Send(d => listBox1.Items.Add(item),null);
                }
                uiContext.Send(d => listBox1.Items.Add($"Средний возраст сотрудников: {sum/selected.Count}"), null);
            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                uiContext.Send(d => listBox1.Items.Clear(),null);
                Firm2 firm = new Firm2();
                firm.Add(new Employee2("Петр","Сидоров",new DateTime(1990,5,14),"Одесса"));
                firm.Add(new Employee2("Елена", "Петрова", new DateTime(1995, 3, 27), "Москва"));
                firm.Add(new Employee2("Андрей", "Козлов", new DateTime(1992, 8, 15), "Киев"));
                firm.Add(new Employee2("Катерина", "Смирнова", new DateTime(1995, 10, 2), "Санкт-Петербург"));
                firm.Add(new Employee2("Дмитрий", "Иванов", new DateTime(1993, 6, 12), "Краснодар"));
                firm.Add(new Employee2("Наталья", "Кузнецова", new DateTime(1986, 4, 4), "Новосибирск"));
                firm.Add(new Employee2("Александр", "Гаврилов", new DateTime(1990, 11, 19), "Минск"));
                firm.Add(new Employee2("Светлана", "Тимофеева", new DateTime(1995, 2, 6), "Рига"));
                firm.Add(new Employee2("Иван", "Попов", new DateTime(1989, 7, 21), "Харьков"));
                firm.Add(new Employee2("Татьяна", "Беляева", new DateTime(1995, 9, 29), "Одесса"));
                firm.Add(new Employee2("Артем", "Морозов", new DateTime(1987, 12, 8), "Белгород"));
                if (string.IsNullOrEmpty(textBox2.Text)) textBox2.Text = "1995";
                int year = Convert.ToInt16(textBox2.Text);
                List<Employee2> selected = firm.employees.Where(t=> t.BirthDay.Year == year).ToList();
                int sum = 0;
                foreach (Employee2 item in selected)
                {
                    // возраст
                    sum += DateTime.Now.Year - item.BirthDay.Year;
                    uiContext.Send(d => listBox1.Items.Add(item), null);
                }
                uiContext.Send(d => listBox1.Items.Add($"Средний возраст сотрудников: {sum / selected.Count}"), null);
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                uiContext.Send(d => listBox1.Items.Clear(),null);
                University un = new University();
                un.Add(new Student("Елена Козлова",10,12,10,4,new DateTime(2022,6,24)));
                un.Add(new Student("Андрей Иванов", 10, 8, 9, 7, new DateTime(2022, 5, 20)));
                un.Add(new Student("Ольга Петрова", 5, 7, 6, 9, new DateTime(2022, 6, 1)));
                un.Add(new Student("Дмитрий Смирнов", 10, 10, 10, 9, new DateTime(2022, 6, 15)));
                un.Add(new Student("Мария Кузнецова", 5, 9, 8, 10, new DateTime(2022, 6, 7)));
                un.Add(new Student("Иван Федоров", 7, 6, 7, 8, new DateTime(2022, 6, 10)));
                un.Add(new Student("Наталья Соколова", 7, 8, 7, 9, new DateTime(2022, 6, 18)));
                un.Add(new Student("Алексей Лебедев", 10, 9, 7, 8, new DateTime(2022, 6, 12)));
                un.Add(new Student("Елена Козлова", 5, 10, 9, 7, new DateTime(2022, 6, 24)));
                un.Add(new Student("Анна Новикова", 7, 8, 9, 10, new DateTime(2022, 6, 8)));
                un.Add(new Student("Максим Козлов", 10, 7, 8, 6, new DateTime(2022, 6, 22)));
                if (string.IsNullOrEmpty(textBox7.Text)) textBox7.Text = "28/6/2022";
                string strDate = textBox7.Text;
                DateTime date;
                try
                {
                    date = DateTime.ParseExact(strDate, "dd/MM/yyyy", null);
                }
                catch { date = DateTime.Now; }
                List<Student> SelectedByDate = un.students.Where(t => t.LastExam < date).ToList();
                List<KeyValuePair<int,List<Student>>> SortedByGroup = new List<KeyValuePair<int, List<Student>>>();
                // сортировка по группам
                foreach (Student student in SelectedByDate)
                {
                    // находим элемент списка с заданным ключом
                    KeyValuePair<int, List<Student>> item = SortedByGroup.Find(x => x.Key == student.NumberGroup);
                    if (item.Value != null)
                    {
                        // если элемент найден, добавляем объект к значению списка, соответствующему ключу
                        item.Value.Add(student);
                    }
                    else
                    {
                        // если элемент не найден, создаем новый элемент списка с заданным ключом и добавляем туда объект
                        List<Student> students = new List<Student>();
                        students.Add(student);
                        SortedByGroup.Add(new KeyValuePair<int, List<Student>>(student.NumberGroup, students));
                    }
                }
                // сортировка групп
                foreach (var item in SortedByGroup)
                {
                    // для каждого елемента значения списка вызываем сортировку
                    item.Value.Sort();
                }
                // вывод на ListBox
                foreach (var item in SortedByGroup)
                {
                    uiContext.Send(d => listBox1.Items.Add($"Группа номер: {item.Key}"),null);
                    foreach (var student in item.Value) 
                    {
                        uiContext.Send(d => listBox1.Items.Add($"\t{student}"), null);
                    }
                }
                if (SortedByGroup.Count == 0)
                    uiContext.Send(d => listBox1.Items.Add("Список пуст"), null);
            });
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                uiContext.Send(d => listBox1.Items.Clear(),null);
                // текст
                if (string.IsNullOrEmpty(textBox4.Text))
                    textBox4.Text = DateTime.Now.ToShortDateString();

                DateTime returned;
                try
                {
                    returned = DateTime.ParseExact(textBox4.Text, "dd/MM/yyyy", null);
                }
                catch { returned = DateTime.Now; }

                if (string.IsNullOrEmpty(textBox5.Text))
                    textBox5.Text = "0";
                int NumberDays = Convert.ToInt32(textBox5.Text);
                // создание библиотеки 
                Library library = new Library();

                library.AddBook(new Book(1000, "Льюис Кэрролл", "Alice's Adventures in Wonderland","Ukrain",new DateTime(1865,10,10),new DateTime(2023,01,21),new DateTime(2023,04,21)));
                library.AddBook(new Book(1001, "Дж. Р. Р. Толкин", "Властелин колец", "АСТ", new DateTime(1954, 7, 29), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1002, "Айзек Азимов", "Я, Робот", "Эксмо", new DateTime(1950, 12, 2), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1003, "Рэй Брэдбери", "451 градус по Фаренгейту", "Эксмо", new DateTime(1953, 10, 19), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1004, "Джордж Оруэлл", "1984", "АСТ", new DateTime(1949, 6, 8), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1005, "Грегори Дэвид Робертс", "Шантарам", "Азбука", new DateTime(2003, 1, 1), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1006, "Дэн Браун", "Код да Винчи", "АСТ", new DateTime(2003, 3, 18), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1007, "Виктор Пелевин", "Жизнь насекомых", "Эксмо", new DateTime(1999, 11, 1), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1008, "Аркадий и Борис Стругацкие", "Пикник на обочине", "Советский писатель", new DateTime(1972, 9, 3), new DateTime(2023, 4, 21), new DateTime(2023, 5, 19)));
                library.AddBook(new Book(1009, "Джеймс Дэшиэль", "Шерлок Холмс: полное собрание", "АСТ", new DateTime(1887, 12, 14), new DateTime(2023, 4, 21), new DateTime(2023,5,19)));

                // выборка 
                List<Book> selected = library.books.Where(t=> (t.DateOfReturn - returned).TotalDays > NumberDays).ToList();
                foreach (var item in selected)
                {
                    uiContext.Send(d => listBox1.Items.Add(item),null);
                }
                if (selected.Count == 0)
                    uiContext.Send(d => listBox1.Items.Add("Просроченных книг нету"), null);

            });
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                uiContext.Send(d => listBox1.Items.Clear(), null);

                DateTime date;
                try { date = DateTime.ParseExact(textBox6.Text, "dd.MM.yyyy", null); }
                catch { date = DateTime.Now; textBox6.Text = date.ToShortDateString(); }

                Shop shop = new Shop();
                shop.Add(new Product(Category.Meat, "Говядина", "Ферма Восточная", new DateTime(2023, 4, 10), new DateTime(2023, 4, 25)));
                shop.Add(new Product(Category.Dairy, "Молоко", "Молочный рай", new DateTime(2023, 4, 12), new DateTime(2023, 4, 23)));
                shop.Add(new Product(Category.Bread, "Батон", "Хлебная лавка", new DateTime(2023, 4, 11), new DateTime(2023, 4, 15)));
                shop.Add(new Product(Category.Meat, "Свинина", "Поляна", new DateTime(2023, 4, 14), new DateTime(2023, 4, 30)));
                shop.Add(new Product(Category.Dairy, "Кефир", "Зеленый двор", new DateTime(2023, 4, 10), new DateTime(2023, 4, 20)));
                shop.Add(new Product(Category.Bread, "Булочка", "Хлебный край", new DateTime(2023, 4, 13), new DateTime(2023, 4, 16)));
                shop.Add(new Product(Category.Meat, "Курица", "Деревенская ферма", new DateTime(2023, 4, 16), new DateTime(2023, 4, 24)));
                shop.Add(new Product(Category.Dairy, "Творог", "Молочное королевство", new DateTime(2023, 4, 10), new DateTime(2023, 4, 22)));
                shop.Add(new Product(Category.Bread, "Пончик", "Сладкая жизнь", new DateTime(2023, 4, 18), new DateTime(2023, 4, 21)));
                shop.Add(new Product(Category.Meat, "Индейка", "Золотая птица", new DateTime(2023, 4, 15), new DateTime(2023, 4, 28)));

                List<Product> SelectedByDay = shop.products.Where(t=> t.BestBeforeDate < date).ToList();
                if (SelectedByDay.Count == 0) 
                {
                    uiContext.Send(d=> listBox1.Items.Add($"Список просроченных товаров пуст"),null);
                    return;
                }

                List<KeyValuePair<Category,List<Product>>> GroupProducts = new List<KeyValuePair<Category, List<Product>>>();
                foreach (Product product in SelectedByDay)
                {
                    KeyValuePair<Category, List<Product>> groups = GroupProducts.Find(x => x.Key == product.category); 
                    if (groups.Value != null) 
                        // если элемент найден, добавляем объект к значению списка, соответствующему ключу
                        groups.Value.Add(product);
                    else
                    {
                        // если элемент не найден, создаем новый элемент списка с заданным ключом и добавляем туда объект
                        List<Product> products = new List<Product>();
                        products.Add(product);
                        GroupProducts.Add(new KeyValuePair<Category, List<Product>>(product.category, products));
                    }
                }
                
                foreach (KeyValuePair<Category, List<Product>> group in GroupProducts) 
                {
                    uiContext.Send(d=> listBox1.Items.Add($"Группа товаров: {group.Key}"),null);
                    foreach (var item in group.Value)
                    {
                        uiContext.Send(d=> listBox1.Items.Add(item),null);
                    }
                }

            });
        }
    }
}
