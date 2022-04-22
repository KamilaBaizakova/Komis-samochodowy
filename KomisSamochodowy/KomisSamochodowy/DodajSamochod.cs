using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomisSamochodowy
{
    public partial class DodajSamochod : Form
    {
        private Samochody samForm;

        public DodajSamochod(Samochody samochody)
        {
            InitializeComponent();
            samForm = samochody;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marka = textBox1.Text;
            string model = textBox2.Text;
            string kolor = comboBox1.Text;
            string silnik = textBox4.Text;
            decimal cena;

            if(string.IsNullOrEmpty(marka) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(kolor) || string.IsNullOrEmpty(silnik) || !decimal.TryParse(textBox5.Text, out cena))
            {
                MessageBox.Show("Podano niepoprawne dane");
            }
            else
            {
                Samochod s = new Samochod(marka, model, kolor, silnik, cena);

                samForm.win.samochody.Add(s);
                samForm.Read();
                samForm.Enabled = true;
                this.Close();
            }
        }

        private void DodajSamochod_FormClosed(object sender, FormClosedEventArgs e)
        {
            samForm.Enabled = true;
        }
    }
}
