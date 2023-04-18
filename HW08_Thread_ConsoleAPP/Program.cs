using System.Collections.Generic;
using System.Threading;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public override string ToString()
    {
        return $"{Name}, {Age}";
    }
}
class Bank
{
    public string Name { get; private set; }
    public int Percent { get; private set; }
    public int Money { get; private set; }
    Thread savePer;
    Thread saveMon;
    public void SavePercent(object obj)
    {
        stData data = (stData)obj;
        StreamWriter sw = new StreamWriter(Name + ".txt", true);
        sw.WriteLine($"Изменение процента. Было {data.Old} стало {data.New}");
        sw.Close();
    }
    public Bank(string name, int amount, int percent)
    {
        Name = name; Money = amount; Percent = percent;

        savePer = new Thread(new ParameterizedThreadStart(SavePercent));

        savePer.IsBackground = true;
        saveMon = new Thread(new ParameterizedThreadStart(SaveMoney));
        saveMon.IsBackground = true;
    }
    private struct stData
    {
        public int Old { get; set; }
        public int New { get; set; }
    }

    public void SetPercent(int percent)
    {
        stData data = new stData();
        data.New = percent;
        data.Old = Percent;
        Percent = percent;
        savePer.Start(data);
    }
    private void SaveMoney(object obj)
    {
        stData data = (stData)obj;
        StreamWriter sw = new StreamWriter(Name + ".txt", true);
        sw.WriteLine($"Изменение баланса. Было {data.Old} стало {data.New}");
        sw.Close();
    }
    public void SetMoney(int money)
    {
        stData data = new stData();
        data.New = money;
        data.Old = Money;
        Money = money;
        saveMon.Start(data);
    }
}
public class Programm
{
    //
    // Task1
    //
    public static void Task1()
    {
        List<Person> persons = new List<Person>();
        persons.Add(new Person("Stas", 20));
        persons.Add(new Person("Artom", 21));
        persons.Add(new Person("Sveta", 22));
        persons.Add(new Person("Valera", 20));

        Thread th = new Thread(new ParameterizedThreadStart(ThreadParam));
        th.IsBackground = true;
        th.Start(persons);
        Console.ReadKey();
    }
    public static void Task2()
    {
        Bank bank = new Bank("Private",100000,3);
        bank.SetMoney(bank.Money + 1000);
        bank.SetMoney(bank.Money + 1000);
        bank.SetPercent(5);
        bank.SetPercent(5);
        bank.SetMoney(bank.Money + 1000);
        Console.ReadKey();
    }
    public static void ThreadParam(object obj)
    {
        List<Person> persons = (List<Person>)obj;
        foreach (Person per in persons)
            Console.WriteLine(per);
    }

    public static void Main()
    {
        Task2();
    }
}

