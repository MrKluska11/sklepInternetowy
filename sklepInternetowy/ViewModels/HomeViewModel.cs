using sklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sklepInternetowy.ViewModels
{
    public class HomeViewModel
    {
        //generyczny interfejs, który implementuje wszystkie kolekcje (pozwala zwrócić dowolną kolekcję)

        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<Kurs> Nowosci { get; set; }
        public IEnumerable<Kurs> Bestsellery { get; set; }
    }
}