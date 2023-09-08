using AltTab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AltTab.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayi=1)
        {
            var makale = db.Makales.Where(i=>i.Confirm==true).Select(i=>new MakaleModel()
            {
                Id = i.Id,
                Title = i.Title,
                UseName = i.UseName,
                Image = i.Image,
                ReleaseDate = i.ReleaseDate,
                Confirm = i.Confirm,
                Views = i.Views,
                Comments = i.Comments,
                Description = i.Description.Length>60?i.Description.Substring(0,60)+("[...]"):i.Description
            }).ToList().ToPagedList(sayi,4);
            return View(makale);
        }
        public ActionResult MakaleListesi(int ? id)
        {
            var makale = db.Makales.Where(x=>x.Confirm==true).AsQueryable();
            if (id != null)
            {
                makale=makale.Where(x=>x.Id==id);
            }
            return View(makale.ToList());
        }
        public ActionResult Search(string deger)
        {
            var ara = db.Makales.Where(x=>x.Confirm==true&&x.Description.Contains(deger)).ToList();
            return View(ara);
        }
        public PartialViewResult MostRead()
        {
            var mostRead = db.Makales.Where(x=>x.Confirm==true).OrderByDescending(x=>x.Views).Take(5).ToList();
            return PartialView(mostRead);
        }
        public ActionResult Detay(int id)
        {
            var sonuc = (from ortalama in db.Comments
                         where ortalama.MakaleId==id
                         select ortalama.puan).DefaultIfEmpty(0).Average();

            ViewBag.ortalama = Math.Round(sonuc);

            var makale = db.Makales.Find(id);
            ViewBag.makale = makale;

            var sayi = db.Makales.ToList().Find(x=>x.Id==id);
            sayi.Views += 1;
            db.SaveChanges();

            ViewBag.sayi = db.Comments.ToList().Where(x=>x.MakaleId==id).Count();

            var yorum = new Comment()
            {
                MakaleId = makale.Id,
            };
            return View("Detay", yorum);
        }
        public ActionResult YorumGonder(Comment comment, int? rating)
        {
			comment.UserId=User.Identity.Name;
            comment.Date = DateTime.Now;
            comment.puan=Convert.ToInt32(rating);
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Detay", "Home", new { id=comment.MakaleId });
        }
    }
}