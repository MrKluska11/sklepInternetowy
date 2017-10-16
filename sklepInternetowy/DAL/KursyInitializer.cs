using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using sklepInternetowy.Models;

namespace sklepInternetowy.DAL
{
    public class KursyInitializer : DropCreateDatabaseAlways<KursyContext>
    {
        protected override void Seed(KursyContext context)
        {
            SeedKursyData(context);
            base.Seed(context);
        }

        private void SeedKursyData(KursyContext context)
        {
            var kategorie = new List<Kategoria> 
            {
                new Kategoria() {NazwaKategorii = "asp.net mvc", NazwaPlikuIkony = "aspnet.jpg", OpisKategorii = "Opis asp.net mvc"},
                new Kategoria() {NazwaKategorii = "java", NazwaPlikuIkony = "java.jpg", OpisKategorii = "Opis java"},
                new Kategoria() {NazwaKategorii = "php", NazwaPlikuIkony = "php.jpg", OpisKategorii = "Opis php"}
            };

            kategorie.ForEach(k => context.Kategorie.Add(k));
            context.SaveChanges();


            var kursy = new List<Kurs>
            {
                new Kurs() {AutorKursu = "Tomek", TytulKursu = "asp.net mvc", KategoriaId = 1, CenaKursu = 99, Bestseller = true, NazwaPlikuObrazka = "aspnet.jpg", DataDodania = DateTime.Now, OpisKursu = "Opis kursu1"},
                new Kurs() {AutorKursu = "Jurek", TytulKursu = "java", KategoriaId = 1, CenaKursu = 120, Bestseller = true, NazwaPlikuObrazka = "java.jpg", DataDodania = DateTime.Now, OpisKursu = "Opis kursu2"},
                new Kurs() {AutorKursu = "Wojtek", TytulKursu = "python", KategoriaId = 1, CenaKursu = 120, Bestseller = true, NazwaPlikuObrazka = "python.jpg", DataDodania = DateTime.Now, OpisKursu = "Opis kursu3"}
            };

            kursy.ForEach(k => context.Kursy.Add(k));
            context.SaveChanges();


        }

    }
}