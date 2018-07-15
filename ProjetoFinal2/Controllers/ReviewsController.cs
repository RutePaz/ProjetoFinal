using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal2.Models;
using TI2PFINAL.Models;

namespace ProjetoFinal2.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Musical).Include(r => r.User);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            return View(reviews);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title");
            ViewBag.UserFK = new SelectList(db.User, "ID_User", "Username");
            return View();
        }

        // POST: Reviews/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Review,Review,MusicalFK,UserFK")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", reviews.MusicalFK);
            ViewBag.UserFK = new SelectList(db.User, "ID_User", "Username", reviews.UserFK);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", reviews.MusicalFK);
            ViewBag.UserFK = new SelectList(db.User, "ID_User", "Username", reviews.UserFK);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Review,Review,MusicalFK,UserFK")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", reviews.MusicalFK);
            ViewBag.UserFK = new SelectList(db.User, "ID_User", "Username", reviews.UserFK);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reviews reviews = db.Reviews.Find(id);
            db.Reviews.Remove(reviews);
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
