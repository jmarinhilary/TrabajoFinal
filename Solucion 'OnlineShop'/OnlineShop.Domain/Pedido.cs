namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido : EntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            Pedido_Producto = new HashSet<Pedido_Producto>();
        }


        public int? IdCliente { get; set; }

        public DateTime? FechaPedido { get; set; }

        public DateTime? FechaExpira { get; set; }

        public int? IdEstadoPed { get; set; }

        public int? IdMedioDePago { get; set; }

        public int? IdEmpleado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual EstadoPedido EstadoPedido { get; set; }

        public virtual MediodePago MediodePago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Producto> Pedido_Producto { get; set; }
    }
}
