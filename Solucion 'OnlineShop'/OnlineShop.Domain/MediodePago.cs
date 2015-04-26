namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediodePago")]
    public partial class MediodePago : EntityBase
    {
        public MediodePago()
        {
            Pedido = new HashSet<Pedido>();
        }


        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
