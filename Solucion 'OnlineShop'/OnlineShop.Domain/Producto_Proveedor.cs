namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Producto_Proveedor : EntityBase
    {

        public int? IdProducto { get; set; }

        public int? IdProveedor { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
