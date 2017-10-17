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
                new Kategoria() { KategoriaId = 1, NazwaKategorii = "asp.net mvc", NazwaPlikuIkony = "aspnet.png", OpisKategorii = "Opis asp.net mvc"},
                new Kategoria() { KategoriaId = 2, NazwaKategorii = "javascript", NazwaPlikuIkony = "javascript.png", OpisKategorii = "Opis javascript"},
                new Kategoria() { KategoriaId = 3, NazwaKategorii = "php", NazwaPlikuIkony = "php.jpg", OpisKategorii = "Opis php"}
            }; 

            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges(); 


            var kursy = new List<Kurs>
            {
                new Kurs() { KursId = 1, AutorKursu = "Tomek", TytulKursu = "asp.net", KategoriaId = 1, CenaKursu = 99, Bestseller = true, NazwaPlikuObrazka = "obrazekaspnet.png", DataDodania = DateTime.Now, OpisKursu = "Opis kursu1"},
                new Kurs() { KursId = 2, AutorKursu = "Jurek", TytulKursu = "javascript", KategoriaId = 1, CenaKursu = 120, Bestseller = true, NazwaPlikuObrazka = "obrazekjavascript.png", DataDodania = DateTime.Now, OpisKursu = "Opis kursu2"},
                new Kurs() { KursId = 3, AutorKursu = "Wojtek", TytulKursu = "csharp", KategoriaId = 1, CenaKursu = 120, Bestseller = true, NazwaPlikuObrazka = "obrazekcsharp.png", DataDodania = DateTime.Now, OpisKursu = "Opis kursu3"}
            };

            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();


        }

    }
} 