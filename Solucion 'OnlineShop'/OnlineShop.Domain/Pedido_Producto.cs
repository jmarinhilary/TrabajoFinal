using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain
{
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