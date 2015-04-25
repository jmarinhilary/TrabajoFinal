namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pedido_Producto : EntityBase
    {

        public int? IdPedido { get; set; }

        public int? IdProducto { get; set; }

        public int? Item { get; set; }

        public int? Cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal? Descuento { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        [Column(TypeName = "money")]
        public decimal? Igv { get; set; }

        [Column(TypeName = "money")]
        public decimal? PTotal { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
