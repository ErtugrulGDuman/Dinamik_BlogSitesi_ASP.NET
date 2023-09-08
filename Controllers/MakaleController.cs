using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AltTab.Models;

namespace AltTab.Controllers
{
    public class MakaleController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Makale
        public ActionResult Index()
        {
            var username = User.Identity.Name;
			var makale = db.Makales.Where(i=>i.UseName==username).Select(i => new MakaleModel()
			{
				Id = i.Id,
				Title = i.Title,
				UseName = i.UseName,
				Image = i.Image,
				ReleaseDate = i.ReleaseDate,
				Confirm = i.Confirm,
				Views = i.Views,
				Comments = i.Comments,
				Description = i.Description.Length > 20 ? i.Description.Substring(0, 20) + ("[...]") : i.Description
			}).ToList();
			return View(makale);
		}

        // GET: Makale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: Makale/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Makale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Makale makale, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                makale.UseName=User.Identity.Name;
                string yol = Path.Combine("/Content/images/" + File.FileName);
                File.SaveAs(Server.MapPath(yol));
                makale.Image = File.FileName.ToString();
                db.Makales.Add(makale);
                db.SaveChanges();
                if (this.User.Identity.Name == "admin")
                {
                return RedirectToAction("Index");
                }
                else
                {
                    return View("Onay");
                }
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", makale.CategoryId);
            return View(makale);
        }

        // GET: Makale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", makale.CategoryId);
            return View(makale);
        }

        // POST: Makale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UseName,Title,Image,Description,ReleaseDate,Views,Confirm,CategoryId")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", makale.CategoryId);
            return View(makale);
        }

        // GET: Makale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makales.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makales.Find(id);
            db.Makales.Remove(makale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
