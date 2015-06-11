namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Imagenes : EntityBase
    {

        [StringLength(400)]
        public string Ruta { get; set; }

        public int? IdProducto { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        [StringLength(1)]
        public string Tipo { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
