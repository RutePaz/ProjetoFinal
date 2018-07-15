using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoFinal2.Models;
using TI2PFINAL.Models;

namespace ProjetoFinal2.Controllers
{
    public class CastsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Casts
        public ActionResult Index()
        {
            var listOActors = db.Actor.ToList();
            return View(listOActors);
        }

        // GET: Casts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Cast cast = db.Actor.Find(id);
            if (cast == null)
            {
                return RedirectToAction("Index");
            }
            return View(cast);
        }

        // GET: Casts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casts/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Actor,Name,Image")] Cast cast, HttpPostedFileBase uploadImage)
        {
            int idNewActor;
            try
            {
                idNewActor = db.Actor.Max(c => c.ID_Actor) + 1;

            }
            catch (Exception)
            {
                idNewActor = 1;
            }
            //guarda o ID do novo Ator
            cast.ID_Actor = idNewActor;
            string imageName = "Actor_" + idNewActor + ".jpg";
            string path = "";
            if (uploadImage != null)
            {
                //verificar o tipo de ficheiro inserido
                path = Path.Combine(Server.MapPath("~/images/"), imageName);
                cast.Image = imageName;
            }
            else
            {
                //quando não foi fornecida nenhuma imagem, gera um erro 
                ModelState.AddModelError("", "Please, upload an image for the Actor");
                return View(cast);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Actor.Add(cast);
                    db.SaveChanges();
                    uploadImage.SaveAs(path);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An Error occurred with the addition of the new Actor");

                }
            }

            return View(cast);
        }

        // GET: Casts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Cast cast = db.Actor.Find(id);
            if (cast == null)
            {
                return RedirectToAction("Index");
            }
            return View(cast);
        }

        // POST: Casts/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Actor,Name,Image")] Cast cast, HttpPostedFileBase uploadImage)
        {
            string newName = "";
            string oldName = "";
            if (ModelState.IsValid)
            {
                try
                {
                    //se foi fornecida uma nova imagem, preparam-se os dados para efetuar a alteração
                    if (uploadImage != null)
                    {
                        //preservar o nome antigo, para depois remover do disco do servidor
                        oldName = cast.Image;
                        //para o novo nome do ficheiro, adiciona-se o termo gerado pelo timestamp
                        //e a extensão do ficheiro é obtida automaticamente em vez de ser escrita de forma explícita
                        newName = "Actor_" + cast.ID_Actor + DateTime.Now.ToString("yyyyMMdd_hhmmss") + Path.GetExtension(uploadImage.FileName).ToLower();
                        //atualizar os dados do Musical com o novo nome
                        cast.Image = newName;
                        //guardar a nova imagem no disco rígido
                        uploadImage.SaveAs(Path.Combine(Server.MapPath("~/images/"), newName));
                    }
                    else
                    {
                        //QUANDDO NAO SE ATUALIZA A IMAGEM MANTÉM-SE A MESMA QUE ESTAVA 
                        string path = Path.Combine(Server.MapPath("~/images/"), oldName);
                        oldName = cast.Image;
                    }
                    //guardar os dados do Musical
                    db.Entry(cast).State = EntityState.Modified;
                    //efetuar 'Commit'
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    //caso haja um erro deve ser enviada uma mensagem para o utilizador 
                    ModelState.AddModelError("", string.Format("An error occurred with the addition of the musical {0}", cast.Name));
                }


            }
            return View(cast);
        }

        // GET: Casts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Cast cast = db.Actor.Find(id);
            if (cast == null)
            {
                return RedirectToAction("Index");
            }
            return View(cast);
        }

        // POST: Casts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cast cast = db.Actor.Find(id);
            try
            {
                db.Actor.Remove(cast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", string.Format("It's not possible to remove the Actor nº {0}-{1}", id, cast.Name));

            }
            return View(cast);
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
