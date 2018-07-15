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
    public class SoundtracksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Soundtracks
        public ActionResult Index()
        {
            var song = db.Song.Include(s => s.Musical);
            return View(song.ToList());
        }

        // GET: Soundtracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Soundtrack soundtrack = db.Song.Find(id);
            if (soundtrack == null)
            {
                return RedirectToAction("Index");
            }
            return View(soundtrack);
        }

        // GET: Soundtracks/Create
        public ActionResult Create()
        {
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title");
            return View();
        }

        // POST: Soundtracks/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Song,SongName,Duration,MusicalFK")] Soundtrack soundtrack)
        {
            int idnewSong;
            try
            {
                idnewSong = db.Song.Max(s => s.ID_Song) + 1;
            }
            catch (Exception)
            {

                idnewSong = 1;
            }
            soundtrack.ID_Song = idnewSong;

            if (ModelState.IsValid)
            {
                try
                {
                    db.Song.Add(soundtrack);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An Error occurred with the addition of the new Song");

                }
            }
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", soundtrack.MusicalFK);
            return View(soundtrack);
        }

        // GET: Soundtracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Soundtrack soundtrack = db.Song.Find(id);
            if (soundtrack == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", soundtrack.MusicalFK);
            return View(soundtrack);
        }

        // POST: Soundtracks/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Song,SongName,Duration,MusicalFK")] Soundtrack soundtrack)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(soundtrack).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", string.Format("An error occurred with the addition of the song {0}", soundtrack.SongName));

            }
            ViewBag.MusicalFK = new SelectList(db.Musical, "ID_Musical", "Title", soundtrack.MusicalFK);
            return View(soundtrack);
        }

        // GET: Soundtracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Soundtrack soundtrack = db.Song.Find(id);
            if (soundtrack == null)
            {
                return RedirectToAction("Index");
            }
            return View(soundtrack);
        }

        // POST: Soundtracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soundtrack soundtrack = db.Song.Find(id);

            try
            {
                db.Song.Remove(soundtrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", string.Format("It's not possible to remove the Song nº {0}-{1}", id, soundtrack.SongName));

            }
            return View(soundtrack);
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
