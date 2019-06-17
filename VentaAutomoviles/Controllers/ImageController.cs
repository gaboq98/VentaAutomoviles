using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaAutomoviles.Models;

namespace VentaAutomoviles.Controllers
{
    public class ImageController : Controller
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();
        // GET: Image
        public ActionResult Show(int id)
        {
            var foto = db.Fotografia.Find(id);
            byte[] imageData = foto.Imagen;
            return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpg");
        }
    }
}