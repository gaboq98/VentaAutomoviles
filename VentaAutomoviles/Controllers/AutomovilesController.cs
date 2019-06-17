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
        public ActionResult DetailsFactura(int? id)
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

            var viewModel = new AutomovilesViewModel(automovil);
            return View(viewModel);
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
