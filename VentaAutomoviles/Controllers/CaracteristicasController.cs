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
    public class CaracteristicasController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        // GET: Caracteristicas
        public ActionResult Index()
        {
            var caracteristicasPorAutomovil = db.CaracteristicasPorAutomovil.Include(c => c.Automovil);
            return View(caracteristicasPorAutomovil.ToList());
        }

        // GET: Caracteristicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaracteristicasPorAutomovil caracteristicasPorAutomovil = db.CaracteristicasPorAutomovil.Find(id);
            if (caracteristicasPorAutomovil == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicasPorAutomovil);
        }

        // GET: Caracteristicas/Create
        public ActionResult Create()
        {
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil");
            return View();
        }

        // POST: Caracteristicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCaracteristicaAutomovil,IdAutomovil,Color,Puertas,Pasajeros")] CaracteristicasPorAutomovil caracteristicasPorAutomovil)
        {
            if (ModelState.IsValid)
            {
                db.CaracteristicasPorAutomovil.Add(caracteristicasPorAutomovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", caracteristicasPorAutomovil.IdAutomovil);
            return View(caracteristicasPorAutomovil);
        }

        // GET: Caracteristicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaracteristicasPorAutomovil caracteristicasPorAutomovil = db.CaracteristicasPorAutomovil.Find(id);
            if (caracteristicasPorAutomovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", caracteristicasPorAutomovil.IdAutomovil);
            return View(caracteristicasPorAutomovil);
        }

        // POST: Caracteristicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCaracteristicaAutomovil,IdAutomovil,Color,Puertas,Pasajeros")] CaracteristicasPorAutomovil caracteristicasPorAutomovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caracteristicasPorAutomovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", caracteristicasPorAutomovil.IdAutomovil);
            return View(caracteristicasPorAutomovil);
        }

        // GET: Caracteristicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaracteristicasPorAutomovil caracteristicasPorAutomovil = db.CaracteristicasPorAutomovil.Find(id);
            if (caracteristicasPorAutomovil == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicasPorAutomovil);
        }

        // POST: Caracteristicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaracteristicasPorAutomovil caracteristicasPorAutomovil = db.CaracteristicasPorAutomovil.Find(id);
            db.CaracteristicasPorAutomovil.Remove(caracteristicasPorAutomovil);
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
