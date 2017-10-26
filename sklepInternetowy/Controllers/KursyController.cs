using sklepInternetowy.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sklepInternetowy.Controllers
{
    public class KursyController : Controller
    {

        KursyContext db = new KursyContext(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string nazwaKategorii)
        {
            var kategoria = db.Kategorie.Include("Kursy").Where(k => k.NazwaKategorii.ToUpper() == nazwaKategorii.ToUpper()).Single();

            var kursy = kategoria.Kursy.ToList();

            return View(kursy);
        }

        public ActionResult Szczegoly(int id)
        {
            var kurs = db.Kursy.Find(id);

            return View(kurs);
        }

        [ChildActionOnly]  //ta akcja może być wywoływane tylko poprzez inną akcję
        [OutputCache(Duration = 60000)]  //60000 sekund = 1 dzień; dane nie są pobierane z bazy tylko są w cache przez 60000 sekund
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Kategorie.ToList();

            return PartialView("_KategorieMenu", kategorie);
              
        }

	}
}