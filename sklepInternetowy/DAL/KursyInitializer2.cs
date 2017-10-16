using sklepInternetowy.Migrations;
using sklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace sklepInternetowy.DAL
{
    public class KursyInitializer2 : MigrateDatabaseToLatestVersion<KursyContext, Configuration>
    {
        //metoda Seed nie występuje w tej klasie, ponieważ jest w  klasie Configuration

        public static void SeedKursyData(KursyContext context)
        {
            var kategorie = new List<Kategoria> 
            {
                new Kategoria() {NazwaKategorii = "asp.net mvc", NazwaPlikuIkony = "aspnet.png", OpisKategorii = "Opis asp.net mvc", KategoriaId = 1},
                new Kategoria() {NazwaKategorii = "javascript", NazwaPlikuIkony = "javascript.png", OpisKategorii = "Opis javascript", KategoriaId = 2},
                new Kategoria() {NazwaKategorii = "php", NazwaPlikuIkony = "php.jpg", OpisKategorii = "Opis php", KategoriaId = 3}
            };

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();


            var kursy = new List<Kurs>
            {
                new Kurs() {AutorKursu = "Tomek", TytulKursu = "asp.net mvc", KategoriaId = 1, CenaKursu = 99, Bestseller = true, NazwaPlikuObrazka = "obrazekaspnet.png", DataDodania = DateTime.Now, OpisKursu = "Opis kursu1", KursId = 1},
                new Kurs() {AutorKursu = "Jurek", TytulKursu = "javascript", KategoriaId = 1, CenaKursu = 120, Bestseller = true, NazwaPlikuObrazka = "obrazekjavascript.png", DataDodania = DateTime.Now, OpisKursu = "Opis kursu2", KursId = 2},
                new Kurs() {AutorKursu = "Wojtek", TytulKursu = "csharp", KategoriaId = 1, CenaKursu = 120, Bestseller = true, NazwaPlikuObrazka = "obrazekcsharp.png", DataDodania = DateTime.Now, OpisKursu = "Opis kursu3", KursId = 3}
            };

            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();


        }

    }
}