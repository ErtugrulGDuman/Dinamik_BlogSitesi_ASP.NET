using AltTab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltTab.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.onaylı=db.Makales.Where(i => i.Confirm==true).Count();
            ViewBag.onaysız=db.Makales.Where(i => i.Confirm==false).Count();
            ViewBag.sayi = db.Makales.Count();
            return View();
        }
        public ActionResult YazarListesi()
        {
            var makale = db.Makales.ToList();
            return View(makale);
        }
        public ActionResult OnaylıMakale()
        {
            var makale = db.Makales.Where(i=>i.Confirm==true).ToList();
            return View(makale);
        }
		public ActionResult OnaysızMakale()
		{
			var makale = db.Makales.Where(i => i.Confirm == false).ToList();
			return View(makale);
		}
	}
}