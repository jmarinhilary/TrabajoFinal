namespace OnlineShop.Domain
{
    public partial class Producto_Proveedor : EntityBase
    {
        public int? IdProducto { get; set; }

        public int? IdProveedor { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
