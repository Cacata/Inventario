//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSSPruebaInventario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductoUbicacion
    {
        public int ID { get; set; }
        public int IDProducto { get; set; }
        public int IDUbicacion { get; set; }
        public string Sucursal { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
    }
}
