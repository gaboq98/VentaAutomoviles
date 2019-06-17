using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaAutomoviles.Models;

namespace VentaAutomoviles.Controllers
{
    public class AutomovilesController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        // GET: Automoviles
        public ActionResult Index()
        {
            var automovil = db.Automovil.Include(a => a.Modelo).Include(a => a.TipoAutomovil).Include(a => a.TipoCombustible);
            return View(automovil.ToList());
        }

        // GET: Automoviles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: Automoviles/Create
        public ActionResult Create()
        {
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Nombre");
            ViewBag.IdTipoAutomovil = new SelectList(db.TipoAutomovil, "IdTipoAutomovil", "Descripcion");
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible, "IdTipoCombustible", "Descripcion");
            return View();
        }

        // POST: Automoviles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAutomovil,IdTipoAutomovil,IdModelo,IdTipoCombustible,Precio,Nombre")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Automovil.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Nombre", automovil.IdModelo);
            ViewBag.IdTipoAutomovil = new SelectList(db.TipoAutomovil, "IdTipoAutomovil", "Descripcion", automovil.IdTipoAutomovil);
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible, "IdTipoCombustible", "Descripcion", automovil.IdTipoCombustible);
            return View(automovil);
        }

        // GET: Automoviles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Nombre", automovil.IdModelo);
            ViewBag.IdTipoAutomovil = new SelectList(db.TipoAutomovil, "IdTipoAutomovil", "Descripcion", automovil.IdTipoAutomovil);
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible, "IdTipoCombustible", "Descripcion", automovil.IdTipoCombustible);
            return View(automovil);
        }

        // POST: Automoviles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAutomovil,IdTipoAutomovil,IdModelo,IdTipoCombustible,Precio,Nombre")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdModelo = new SelectList(db.Modelo, "IdModelo", "Nombre", automovil.IdModelo);
            ViewBag.IdTipoAutomovil = new SelectList(db.TipoAutomovil, "IdTipoAutomovil", "Descripcion", automovil.IdTipoAutomovil);
            ViewBag.IdTipoCombustible = new SelectList(db.TipoCombustible, "IdTipoCombustible", "Descripcion", automovil.IdTipoCombustible);
            return View(automovil);
        }

        // GET: Automoviles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automoviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.Automovil.Find(id);
            db.Automovil.Remove(automovil);
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
