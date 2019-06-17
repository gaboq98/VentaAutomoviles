using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentaAutomoviles.Models
{
    public class FacturaViewModel
    {
        [Key]
        [Display(Name = "Automovil")]
        public int IdAutomovil { get; set; }

        [Required]
        [Display(Name = "Identificacion de Cliente")]
        public int IdCliente { get; set; }

        [Required]
        [Display(Name = "Tipo de pago")]
        public int IdTipoPago { get; set; }

        [Required]
        [Display(Name = "Sucursal")]
        public int IdSucursal { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public int IdEmpleado { get; set; }
    }
}