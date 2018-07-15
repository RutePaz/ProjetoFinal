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
    public class MusicalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Musicals
        /// <summary>
        /// listagem de todos os musicais
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {


            var listOfMusicals = db.Musical.ToList();
            return View(listOfMusicals);
        }

        // GET: Musicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Musical musical = db.Musical.Find(id);
            if (musical == null)
            {
                //se o musical nao for encontrado, é redirecionado para o "Index" 
                return RedirectToAction("Index");

            }
            
            return View(musical);
        }

        // GET: Musicals/Create
        public ActionResult Create()
        {
            //apresenta a view para inserir um novo Musical
            return View();
        }

        // POST: Musicals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //anotador para proteção por roubo de identidade 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Musical,Title,Synopsis,Director,Duration,OpeningNight,Ticket")] Musical musical, HttpPostedFileBase uploadPoster)
        {
            int idNewMusical = 0;
            try
            {
                idNewMusical = db.Musical.Max(m => m.ID_Musical) + 1;

            }
            catch (Exception)
            {
                idNewMusical = 1;
            }
            //guarda o ID do novo Musical
            musical.ID_Musical = idNewMusical;
            string imageName = "Musical_" + idNewMusical + ".jpg";
            string path = "";
            //validar se a imagem foi fornecida 
            if (uploadPoster != null)
            {
                //verificar o tipo de ficheiro inserido
                path = Path.Combine(Server.MapPath("~/images/"), imageName);
                musical.Poster = imageName;
            }
            else
            {
                //quando não foi fornecida nenhuma imagem, gera um erro 
                ModelState.AddModelError("", "Please, upload an image for the Musical");
                return View(musical);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //adiciona um novo musical
                    db.Musical.Add(musical);
                    //faz commit ás alterações
                    db.SaveChanges();
                    //escrever o ficheiro com a fotografia no disco rígido, na pasta "images"
                    uploadPoster.SaveAs(path);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An Error occurred with the addition of the new Musical");
                }
            }

            return View(musical);
        }

        // GET: Musicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //procura na BD, o Musical cujo ID foi fornecido
            Musical musical = db.Musical.Find(id);
            //proteção para o caso de nao ter sido encontrado
            if (musical == null)
            {
                return RedirectToAction("Index");
            }
            return View(musical);
        }

        // POST: Musicals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Musical,Title,Synopsis,Director,Duration,OpeningNight,Ticket,Poster")] Musical musical, HttpPostedFileBase uploadPoster)
        {
            string newName = "";
            string oldName = "";
            if (ModelState.IsValid)
            {
                try
                {
                    //se foi fornecida uma nova imagem, preparam-se os dados para efetuar a alteração
                    if (uploadPoster != null)
                    {
                        //preservar o nome antigo, para depois remover do disco do servidor
                        oldName = musical.Poster;
                        //para o novo nome do ficheiro, adiciona-se o termo gerado pelo timestamp
                        //e a extensão do ficheiro é obtida automaticamente em vez de ser escrita de forma explícita
                        newName = "Musical_" + musical.ID_Musical + DateTime.Now.ToString("yyyyMMdd_hhmmss") + Path.GetExtension(uploadPoster.FileName).ToLower();
                        //atualizar os dados do Musical com o novo nome
                        musical.Poster = newName;
                        //guardar a nova imagem no disco rígido
                        uploadPoster.SaveAs(Path.Combine(Server.MapPath("~/images/"), newName));
                    }
                    else
                    {
                        //QUANDDO NAO SE ATUALIZA A IMAGEM MANTÉM-SE A MESMA QUE ESTAVA 
                        string path = Path.Combine(Server.MapPath("~/images/"), oldName);
                        oldName = musical.Poster;
                    }
                    //guardar os dados do Musical
                    db.Entry(musical).State = EntityState.Modified;
                    //efetuar 'Commit'
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    //caso haja um erro deve ser enviada uma mensagem para o utilizador 
                    ModelState.AddModelError("", string.Format("An error occurred with the addition of the musical {0}", musical.Title));
                }


            }
            return View(musical);
        }

        // GET: Musicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //pesquisa do ID que foi fornecido
            Musical musical = db.Musical.Find(id);
            //caso o musical não tenha sido encontrado
            if (musical == null)
            {
                return RedirectToAction("Index");
            }
            return View(musical);
        }

        // POST: Musicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musical musical = db.Musical.Find(id);
            try
            {
                db.Musical.Remove(musical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", string.Format("It's not possible to remove the Musical nº {0}-{1}", id, musical.Title));
            }
            return View(musical);


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
