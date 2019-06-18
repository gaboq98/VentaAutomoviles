using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaAutomoviles.Models;

namespace VentaAutomoviles.Controllers
{
    public class HomeController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        public ActionResult Index()
        {
            /*
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.ID = currentUser.PhoneNumber;
            */
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult IndexFacturador()
        {
            
            return View();
        }

        public ActionResult IndexCliente()
        {

            return View();
        }


        public ActionResult Ventas()
        {
            var spRes = db.sp_consultar_ventas2(null,null,null,null,null);
            return View(spRes);
        }
        
        public ActionResult VentasTipoPago()
        {
            var spRes = db.sp_consultar_ventasPorTipoPago1( null, null, null, null);
            return View(spRes);
        }

        public ActionResult RegistrarEmpleado()
        {

            return View();
        }


    }
}