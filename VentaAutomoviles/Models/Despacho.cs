//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaAutomoviles.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Despacho
    {
        public int IdDespacho { get; set; }
        public int IdFabrica { get; set; }
        public int IdSucursal { get; set; }
        public int IdAutomovil { get; set; }
        public int IdPedido { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual Automovil Automovil { get; set; }
        public virtual Fabrica Fabrica { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
