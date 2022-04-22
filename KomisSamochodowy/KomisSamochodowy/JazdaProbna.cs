using System;
using System.Collections.Generic;
using System.Text;

namespace KomisSamochodowy
{
    public class JazdaProbna
    {
        public string Samochod { get; set; }
        public DateTime Data { get; set; }
        public string Klient { get; set; }

        public JazdaProbna(string samochod, DateTime data, string klient)
        {
            Samochod = samochod;
            Data = data;
            Klient = klient;
        }
    }
}
