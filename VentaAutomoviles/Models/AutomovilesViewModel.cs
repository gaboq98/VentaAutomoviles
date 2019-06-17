using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentaAutomoviles.Models
{
    public class AutomovilesViewModel
    {
        private VentaAutomovilesEntities db = new VentaAutomovilesEntities();

        public AutomovilesViewModel(Automovil automovil)
        {
            this.IdAutomovil = automovil.IdAutomovil;
            this.IdTipoAutomovil = automovil.IdTipoAutomovil;
            this.TipoAutomovil = automovil.TipoAutomovil;
            this.IdModelo = automovil.IdModelo;
            this.Modelo = automovil.Modelo;
            this.Precio = automovil.Precio;
            this.IdTipoCombustible = automovil.IdTipoCombustible;
            this.TipoCombustible = automovil.TipoCombustible;
            this.Marca = db.Marca.Find(automovil.Modelo.IdMarca);
            var paquete =
                    from F in db.Fotografia
                    from FXA in db.FotografiaPorAutomovil
                    where FXA.IdFotografia == F.IdFotografia
                    where FXA.IdAutomovil == automovil.IdAutomovil
                    select F.IdFotografia;
            this.Fotos = paquete.ToList();
        }

        [Key]
        public int IdAutomovil { get; set; }

        [Required]
        [Display(Name = "Tipo de automovil")]
        public int IdTipoAutomovil { get; set; }

        public int IdModelo { get; set; }

        public int IdTipoCombustible { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual TipoAutomovil TipoAutomovil { get; set; }

        public virtual TipoCombustible TipoCombustible { get; set; }
        public Marca Marca { get; set; }
        public List<int> Fotos { get; set; }
    }
}