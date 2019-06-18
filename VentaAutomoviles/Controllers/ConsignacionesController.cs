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
    public class ConsignacionesController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        // GET: Consignaciones
        public ActionResult Index()
        {
            var consignacion = db.Consignacion.Include(c => c.Automovil).Include(c => c.Sucursal);
            return View(consignacion.ToList());
        }

        // GET: Consignaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consignacion consignacion = db.Consignacion.Find(id);
            if (consignacion == null)
            {
                return HttpNotFound();
            }
            return View(consignacion);
        }

        // GET: Consignaciones/Create
        public ActionResult Create()
        {
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil");
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
            return View();
        }

        // POST: Consignaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConsignacion,IdSucursal,IdAutomovil,Comision")] Consignacion consignacion)
        {
            if (ModelState.IsValid)
            {
                db.Consignacion.Add(consignacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", consignacion.IdAutomovil);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", consignacion.IdSucursal);
            return View(consignacion);
        }

        // GET: Consignaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consignacion consignacion = db.Consignacion.Find(id);
            if (consignacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", consignacion.IdAutomovil);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", consignacion.IdSucursal);
            return View(consignacion);
        }

        // POST: Consignaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConsignacion,IdSucursal,IdAutomovil,Comision")] Consignacion consignacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consignacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutomovil = new SelectList(db.Automovil, "IdAutomovil", "IdAutomovil", consignacion.IdAutomovil);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", consignacion.IdSucursal);
            return View(consignacion);
        }

        // GET: Consignaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consignacion consignacion = db.Consignacion.Find(id);
            if (consignacion == null)
            {
                return HttpNotFound();
            }
            return View(consignacion);
        }

        // POST: Consignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consignacion consignacion = db.Consignacion.Find(id);
            db.Consignacion.Remove(consignacion);
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
