using sklepInternetowy.DAL;
using sklepInternetowy.Infrastructure;
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

            ICacheProvider cache = new DefaultCacheProvider();

            List<Kategoria> kategorie = new List<Kategoria>();

            if(cache.IsSet(Consts.KategorieCacheKey))
            {
                kategorie = cache.Get(Consts.KategorieCacheKey) as List<Kategoria>;
            }
            else
            {
                kategorie = db.Kategorie.ToList();
                cache.Set(Consts.KategorieCacheKey, kategorie, 60);  //60 minut
            }

            List<Kurs> nowosci;

            if(cache.IsSet(Consts.NowosciCacheKey))
            {
                nowosci = cache.Get(Consts.NowosciCacheKey) as List<Kurs>;
            }

            else
            {
                nowosci = db.Kursy.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();
                cache.Set(Consts.NowosciCacheKey, nowosci, 60);   //60 minut 
            }

            List<Kurs> bestsellery;

            if(cache.IsSet(Consts.BestselleryCacheKey))
            {
                bestsellery = cache.Get(Consts.BestselleryCacheKey) as List<Kurs>;
            }
            else
            {
                bestsellery = db.Kursy.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();  //Guid - nadaje za każdym razem inny identyfikator danej zmiennej
                cache.Set(Consts.BestselleryCacheKey, bestsellery, 60);
            }


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