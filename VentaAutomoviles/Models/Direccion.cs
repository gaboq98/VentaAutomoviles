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
    
    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            this.Cliente = new HashSet<Cliente>();
            this.Empleado = new HashSet<Empleado>();
            this.EmpleadoFabrica = new HashSet<EmpleadoFabrica>();
            this.Fabrica = new HashSet<Fabrica>();
            this.Sucursal = new HashSet<Sucursal>();
        }
    
        public int IdDireccion { get; set; }
        public int IdPais { get; set; }
        public int IdProvincia { get; set; }
        public int IdCanton { get; set; }
        public string Señas { get; set; }
    
        public virtual Canton Canton { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Provincia Provincia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpleadoFabrica> EmpleadoFabrica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fabrica> Fabrica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sucursal> Sucursal { get; set; }
    }
}