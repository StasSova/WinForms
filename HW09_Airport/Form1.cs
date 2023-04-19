using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW09_Airport
{
 
    public partial class Form1 : Form
    {
        List<Passenger> passengers = new List<Passenger>();
        List<Flight> flights = new List<Flight>();
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            #region
            // Добавление рейсов
            flights.Add(new Flight(1, new DateTime(2023, 5, 10), 2, "Kiew"));
            flights.Add(new Flight(1, new DateTime(2023, 6, 15), 3, "Odesa"));
            flights.Add(new Flight(1, new DateTime(2023, 7, 20), 4, "Kharkiv"));
            flights.Add(new Flight(1, new DateTime(2023, 8, 25), 5, "Lviv"));
            // Добавление пассажиров
            passengers.Add(new Passenger("Foster, A. J.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Baker, K. L.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Collins, R. D.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Peterson, E. M.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Anderson, L. J.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Davis, J. H.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Wilson, S. R.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Edwards, M. B.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Johnson, K. D.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            passengers.Add(new Passenger("Smith, T. A.", random.Next(1, 5), random.Next(10, 35), flights[random.Next(0, flights.Count)]));
            #endregion

            foreach (Flight a in flights)
                comboBox1.Items.Add(a);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Passenger> pass = passengers.Where(t => t.Flight == comboBox1.SelectedItem).ToList();
            Flight fl = (Flight)comboBox1.SelectedItem;
            // Информация о пассажирах
            Action Pass = delegate
            {
                listView1.Items.Clear();
                foreach (Passenger pas in pass)
                    listView1.Items.Add(pas.ToString());
            };
            Action Fly = delegate
            {
                listView2.Clear();
                int temp = 0;
                listView2.Items.Add($"Номер рейса: {fl.FlightNumber}");
                listView2.Items.Add($"Время отправления: {fl.Departure}");
                listView2.Items.Add($"Количество часов полета: {fl.NumberOfHoursInFlight}");
                listView2.Items.Add($"Направление: {fl.Destination}");
                listView2.Items.Add($"Пассажиры");
                listView2.Items.Add($"Количество: {pass.Count}");
                listView2.Items.Add($"Багаж");
                foreach (Passenger p in pass) { temp += p.NumberOfLuggage; }
                listView2.Items.Add($"Количество: {temp}");
                temp = 0;
                foreach (Passenger p in pass) { temp += p.MassOfLuggage; }
                listView2.Items.Add($"Масса: {temp}");
            };
            this.Invoke(Pass);
            this.Invoke(Fly);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex= 0;
        }
        // рейс
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFlight temp = new AddFlight();
            if (DialogResult.OK == temp.ShowDialog())
            {
                flights.AddRange(temp.flights);
                foreach (Flight fl in temp.flights)
                    comboBox1.Items.Add(fl);
            }
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFlight remove = new RemoveFlight(flights);
            if (DialogResult.OK == remove.ShowDialog())
                flights = remove.flights;
            comboBox1.Items.Clear();
            if (flights.Count != 0)
            {
            foreach (Flight a in flights)
                comboBox1.Items.Add(a);
                comboBox1.SelectedIndex = 0;
            }
            
        }

        // пассажиры
        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddPass pas = new AddPass(flights);
            if(DialogResult.OK == pas.ShowDialog())
            {
                passengers.AddRange(pas.passengers);
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemovePass pass = new RemovePass(passengers);
            if (DialogResult.OK == pass.ShowDialog())
            {
                passengers = pass.passengers;
            }
        }
    }
    class Passenger
    {
        public string Name { get; set; }
        public int NumberOfLuggage { get; set; }
        public int MassOfLuggage { get; set; }
        public Flight Flight { get; set; }
        public Passenger() { }
        public Passenger(string name, int numberOfLuggage, int massOfLuggage, Flight flight)
        {
            Name = name;
            NumberOfLuggage = numberOfLuggage;
            MassOfLuggage = massOfLuggage;
            Flight = flight;
        }
        public override string ToString()
        {
            return $"{Name} - {Flight.Destination}";
        }
    }
    class Flight
    {
        public int FlightNumber { get; set; }
        public DateTime Departure { get; set; }
        public int NumberOfHoursInFlight { get; set; }
        public string Destination { get; set; }
        public Flight(int flightNumber, DateTime departure, int numberOfHoursInFlight, string destination)
        {
            FlightNumber = flightNumber;
            Departure = departure;
            NumberOfHoursInFlight = numberOfHoursInFlight;
            Destination = destination;
        }
        public override string ToString()
        {
            return $"{Destination} - {Departure.Year}.{Departure.Month},{Departure.Day}";
        }
    }
}
