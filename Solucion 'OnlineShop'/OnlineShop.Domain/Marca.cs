using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Domain
{
    [Table("Marca")]
    public partial class Marca : EntityBase
    {
       public Marca()
        {
            Producto = new HashSet<Producto>();
        }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        [StringLength(100)]
        public string Imagen { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
