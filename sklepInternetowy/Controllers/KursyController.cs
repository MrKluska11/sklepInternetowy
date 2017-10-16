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
            return View();
        }

        public ActionResult Szczegoly(string id)
        {
            return View();
        }

        [ChildActionOnly]  //ta akcja może być wywoływane tylko poprzez inną akcję
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Kategorie.ToList();

            return PartialView("_KategorieMenu", kategorie);
              
        }
	}
}