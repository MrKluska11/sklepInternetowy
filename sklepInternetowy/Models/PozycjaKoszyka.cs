using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sklepInternetowy.Models
{
    public class PozycjaKoszyka
    {
        public Kurs kurs { get; set; }
        public int ilosc { get; set; }
        public decimal wartosc { get; set; }
    }
}