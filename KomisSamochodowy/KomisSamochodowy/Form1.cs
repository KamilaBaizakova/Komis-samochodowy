using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomisSamochodowy
{
    public partial class Form1 : Form
    {
        public List<Samochod> samochody { get; set; }
        public List<JazdaProbna> jazdy { get; set; }

        public Form1()
        {
            InitializeComponent();

            samochody = ReadSamochody();
            jazdy = ReadJazdy();
        }

        private List<Samochod> ReadSamochody()
        {
            List<Samochod> list = new List<Samochod>();

            try
            {
                foreach (string line in File.ReadAllLines("samochody.txt"))
                {
                    string[] parts = line.Split(',');

                    list.Add(new Samochod(parts[0], parts[1], parts[2], parts[3], decimal.Parse(parts[4])));
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Wystąpił błąd odczytu pliku");
            }

            return list;
        }

        public void SaveSamochody()
        {
            String txt = "";

            foreach(Samochod s in samochody)
            {
                txt += $"{s.Marka},{s.Model},{s.Kolor},{s.Silnik},{s.Cena}\n";
            }

            File.WriteAllText("samochody.txt", txt);
        }

        private List<JazdaProbna> ReadJazdy()
        {
            List<JazdaProbna> list = new List<JazdaProbna>();

            try
            {
                foreach (string line in File.ReadAllLines("jazdy.txt"))
                {
                    string[] parts = line.Split(',');

                    list.Add(new JazdaProbna(parts[0], DateTime.Parse(parts[1]), parts[2]));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wystąpił błąd odczytu pliku");
            }

            return list;
        }

        public void SaveJazdy()
        {
            string txt = "";

            foreach (JazdaProbna j in jazdy)
            {
                txt += $"{j.Samochod},{j.Data},{j.Klient}\n";
            }

            File.WriteAllText("jazdy.txt", txt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Konfigurator konfigurator = new Konfigurator(this);
            konfigurator.Show();
            this.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Samochody sam = new Samochody(this);
            this.Enabled = false;
            sam.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JazdyProbne j = new JazdyProbne(this);
            this.Enabled = false;
            j.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSamochody();
            SaveJazdy();
        }
    }
}
