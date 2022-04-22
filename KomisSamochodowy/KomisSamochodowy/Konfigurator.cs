using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomisSamochodowy
{
    public partial class Konfigurator : Form
    {
        public Form1 win;

        public Konfigurator(Form1 win)
        {
            InitializeComponent();

            this.win = win;

            comboBox1.Items.AddRange(win.samochody.Select(s => s.Marka).Distinct().ToArray());
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var wybrane = win.samochody.Where(w => w.Marka == comboBox1.SelectedItem.ToString()).ToList();
                PokazWybrane(wybrane);
                var modele = wybrane.Select(s => s.Model).Distinct().ToArray();
                comboBox2.Items.AddRange(modele);
                comboBox2.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                var wybrane = win.samochody.Where(w => w.Model == comboBox2.SelectedItem.ToString()).ToList();
                PokazWybrane(wybrane);
                var kolory = wybrane.Select(s => s.Kolor).Distinct().ToArray();
                comboBox3.Items.AddRange(kolory);
                comboBox3.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                var wybrane = win.samochody.Where(w => w.Kolor == comboBox3.SelectedItem.ToString()).ToList();
                PokazWybrane(wybrane);
                var silniki = wybrane.Select(s => s.Silnik).Distinct().ToArray();
                comboBox4.Items.AddRange(silniki);
                comboBox4.Enabled = true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem != null)
            {
                var wybrane = win.samochody.Where(w => w.Silnik == comboBox4.SelectedItem.ToString()).ToList();
                PokazWybrane(wybrane);
            }
        }

        private void Konfigurator_FormClosed(object sender, FormClosedEventArgs e)
        {
            win.Enabled = true;
        }

        public void PokazWybrane(List<Samochod> wybrane)
        {
            string txt = "";

            foreach(Samochod s in wybrane)
            {
                txt += s + "\n";
            }

            label5.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox2.Items.Clear();
            comboBox3.SelectedItem = null;
            comboBox3.Items.Clear();
            comboBox4.SelectedItem = null;
            comboBox4.Items.Clear();
            label5.Text = "";
        }
    }
}
