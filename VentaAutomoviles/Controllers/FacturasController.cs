using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class FacturasController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.Cliente).Include(f => f.Empleado).Include(f => f.Sucursal);
            return View(factura.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create(int id)
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Cedula");

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var userId = currentUser.PhoneNumber;
            List<object> list = new List<object>
            {
                db.Empleado.Find(System.Convert.ToInt32(userId))
            };
            IEnumerable<object> enumList = list;
            ViewBag.IdEmpleado = new SelectList(enumList, "IdEmpleado", "Nombre");

            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre");
            ViewBag.IdTipoPago = new SelectList(db.TipoPago, "IdTipoPago", "Descripcion");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel factura)
        {
            if (ModelState.IsValid)
            {
                // TODO: Logica
                return RedirectToAction("IndexFacturador", "Home");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Cedula", factura.IdCliente);
            ViewBag.IdEmpleadoSucursal = new SelectList(db.Empleado, "IdEmpleado", "Nombre", factura.IdEmpleado);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", factura.IdSucursal);
            ViewBag.IdTipoPago = new SelectList(db.TipoPago, "IdTipoPago", "Descripcion");
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", factura.IdCliente);
            ViewBag.IdEmpleadoSucursal = new SelectList(db.Empleado, "IdEmpleado", "Nombre", factura.IdEmpleadoSucursal);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", factura.IdSucursal);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFactura,IdEmpleadoSucursal,IdSucursal,IdCliente,Monto,Descuento,Fecha")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", factura.IdCliente);
            ViewBag.IdEmpleadoSucursal = new SelectList(db.Empleado, "IdEmpleado", "Nombre", factura.IdEmpleadoSucursal);
            ViewBag.IdSucursal = new SelectList(db.Sucursal, "IdSucursal", "Nombre", factura.IdSucursal);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
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
