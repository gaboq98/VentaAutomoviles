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
    public class DireccionsController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        // GET: Direccions
        public ActionResult Index()
        {
            var direccion = db.Direccion.Include(d => d.Canton).Include(d => d.Pais).Include(d => d.Provincia);
            return View(direccion.ToList());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre");
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Iso");
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDireccion,IdPais,IdProvincia,IdCanton,Señas")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", direccion.IdCanton);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Iso", direccion.IdPais);
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre", direccion.IdProvincia);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", direccion.IdCanton);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Iso", direccion.IdPais);
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre", direccion.IdProvincia);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDireccion,IdPais,IdProvincia,IdCanton,Señas")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", direccion.IdCanton);
            ViewBag.IdPais = new SelectList(db.Pais, "IdPais", "Iso", direccion.IdPais);
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre", direccion.IdProvincia);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.Direccion.Find(id);
            db.Direccion.Remove(direccion);
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
