using sklepInternetowy.DAL;
using sklepInternetowy.Models;
using sklepInternetowy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sklepInternetowy.Controllers
{
    public class HomeController : Controller
    {
        public KursyContext db = new KursyContext();


        public ActionResult Index()
        {
           /* Kategoria kategoria = new Kategoria { NazwaKategorii = "asp.net mvc", NazwaPlikuIkony = "aspnet.png", OpisKategorii = "Opis" };
            db.Kategorie.Add(kategoria);
            db.SaveChanges(); */

            //var kategorie = db.Kategorie.ToList();

            var kategorie = db.Kategorie.ToList();
            var nowosci = db.Kursy.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();
            var bestsellery = db.Kursy.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();  //Guid - nadaje za każdym razem inny identyfikator danej zmiennej

            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestsellery
            }; 

            return View(vm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

	}
}