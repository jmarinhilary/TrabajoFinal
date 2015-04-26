namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria : EntityBase
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }


        [StringLength(100)]
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
