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
    public class ExtrasPorAutomovilesController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        // GET: ExtrasPorAutomoviles
        public ActionResult Index()
        {
            var extrasPorAutomovil = db.ExtrasPorAutomovil.Include(e => e.Automovil).Include(e => e.Extra);
            return View(extrasPorAutomovil.ToList());
        }

        // GET: ExtrasPorAutomoviles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtrasPorAutomovil extrasPorAutomovil = db.ExtrasPorAutomovil.Find(id);
            if (extrasPorAutomovil == null)
            {
                return HttpNotFound();
            }
            return View(extrasPorAutomovil);
        }

        // GET: ExtrasPorAutomoviles/Create
        public ActionResult Create()
        {
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil");
            ViewBag.IdExtra = new SelectList(db.Extra, "IdExtra", "Nombre");
            return View();
        }

        // POST: ExtrasPorAutomoviles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdExtraAutomovil,IdAutomovil,IdExtra,Cantidad")] ExtrasPorAutomovil extrasPorAutomovil)
        {
            if (ModelState.IsValid)
            {
                db.ExtrasPorAutomovil.Add(extrasPorAutomovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", extrasPorAutomovil.IdAutomovil);
            ViewBag.IdExtra = new SelectList(db.Extra, "IdExtra", "Nombre", extrasPorAutomovil.IdExtra);
            return View(extrasPorAutomovil);
        }

        // GET: ExtrasPorAutomoviles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtrasPorAutomovil extrasPorAutomovil = db.ExtrasPorAutomovil.Find(id);
            if (extrasPorAutomovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", extrasPorAutomovil.IdAutomovil);
            ViewBag.IdExtra = new SelectList(db.Extra, "IdExtra", "Nombre", extrasPorAutomovil.IdExtra);
            return View(extrasPorAutomovil);
        }

        // POST: ExtrasPorAutomoviles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdExtraAutomovil,IdAutomovil,IdExtra,Cantidad")] ExtrasPorAutomovil extrasPorAutomovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extrasPorAutomovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", extrasPorAutomovil.IdAutomovil);
            ViewBag.IdExtra = new SelectList(db.Extra, "IdExtra", "Nombre", extrasPorAutomovil.IdExtra);
            return View(extrasPorAutomovil);
        }

        // GET: ExtrasPorAutomoviles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtrasPorAutomovil extrasPorAutomovil = db.ExtrasPorAutomovil.Find(id);
            if (extrasPorAutomovil == null)
            {
                return HttpNotFound();
            }
            return View(extrasPorAutomovil);
        }

        // POST: ExtrasPorAutomoviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtrasPorAutomovil extrasPorAutomovil = db.ExtrasPorAutomovil.Find(id);
            db.ExtrasPorAutomovil.Remove(extrasPorAutomovil);
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
