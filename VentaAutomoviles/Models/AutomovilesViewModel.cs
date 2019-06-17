using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentaAutomoviles.Models
{
    public class AutomovilesViewModel
    {
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
    }
}