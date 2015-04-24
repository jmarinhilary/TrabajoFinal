using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Domain
{
    [Table("Producto")]
    public partial class Producto : EntityBase
    {
        public Producto()
        {
            Pedido_Producto = new HashSet<Pedido_Producto>();
            Producto_Proveedor = new HashSet<Producto_Proveedor>();
        }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public int? Stock { get; set; }

        public int? IdMarca { get; set; }

        public int? IdCategoria { get; set; }

        [Column(TypeName = "money")]
        public decimal? PrecioCosto { get; set; }

        [StringLength(1)]
        public string Descontinuado { get; set; }

        [StringLength(10)]
        public string Sku { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual ICollection<Pedido_Producto> Pedido_Producto { get; set; }

        public virtual ICollection<Producto_Proveedor> Producto_Proveedor { get; set; }
    }
}
