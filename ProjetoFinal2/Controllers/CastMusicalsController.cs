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
    public class CastMusicalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CastMusicals
        public ActionResult Index()
        {
            var castMusical = db.CastMusical.Include(c => c.Cast).Include(c => c.Musical);
            return View(castMusical.ToList());
        }

        // GET: CastMusicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMusical castMusical = db.CastMusical.Find(id);
            if (castMusical == null)
            {
                return HttpNotFound();
            }
            return View(castMusical);
        }

        // GET: CastMusicals/Create
        public ActionResult Create()
        {
            ViewBag.CastFK = new SelectList(db.Actor, "ID_Actor", "Name");
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title");
            return View();
        }

        // POST: CastMusicals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MusicalFK,CastFK,Character")] CastMusical castMusical)
        {
            if (ModelState.IsValid)
            {
                db.CastMusical.Add(castMusical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CastFK = new SelectList(db.Actor, "ID_Actor", "Name", castMusical.CastFK);
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", castMusical.MusicalFK);
            return View(castMusical);
        }

        // GET: CastMusicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMusical castMusical = db.CastMusical.Find(id);
            if (castMusical == null)
            {
                return HttpNotFound();
            }
            ViewBag.CastFK = new SelectList(db.Actor, "ID_Actor", "Name", castMusical.CastFK);
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", castMusical.MusicalFK);
            return View(castMusical);
        }

        // POST: CastMusicals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MusicalFK,CastFK,Character")] CastMusical castMusical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castMusical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CastFK = new SelectList(db.Actor, "ID_Actor", "Name", castMusical.CastFK);
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", castMusical.MusicalFK);
            return View(castMusical);
        }

        // GET: CastMusicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMusical castMusical = db.CastMusical.Find(id);
            if (castMusical == null)
            {
                return HttpNotFound();
            }
            return View(castMusical);
        }

        // POST: CastMusicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastMusical castMusical = db.CastMusical.Find(id);
            db.CastMusical.Remove(castMusical);
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
