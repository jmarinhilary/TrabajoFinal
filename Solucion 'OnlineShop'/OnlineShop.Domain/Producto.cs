namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto : EntityBase
    {
        public Producto()
        {
            Imagenes = new HashSet<Imagenes>();
            Pedido_Producto = new HashSet<Pedido_Producto>();
            Producto_Proveedor = new HashSet<Producto_Proveedor>();
        }

        [StringLength(400)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public int? Stock { get; set; }

        public int? IdMarca { get; set; }

        public int? IdCategoria { get; set; }

        [Column(TypeName = "money")]
        public decimal? PrecioCosto { get; set; }

        public bool Descontinuado { get; set; }

        [StringLength(10)]
        public string Sku { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Imagenes> Imagenes { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual ICollection<Pedido_Producto> Pedido_Producto { get; set; }

        public virtual ICollection<Producto_Proveedor> Producto_Proveedor { get; set; }
    }
}
