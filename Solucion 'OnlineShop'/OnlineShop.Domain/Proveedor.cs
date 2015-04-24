using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.Domain
{
    [Table("Proveedor")]
    public partial class Proveedor : EntityBase
    {
        public Proveedor()
        {
            Producto_Proveedor = new HashSet<Producto_Proveedor>();
        }


        [StringLength(100)]
        public string NombreCompania { get; set; }

        [StringLength(100)]
        public string NombreContacto { get; set; }

        [StringLength(100)]
        public string Dirección { get; set; }

        [StringLength(100)]
        public string Ubigeo { get; set; }

        [StringLength(100)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Web { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public virtual ICollection<Producto_Proveedor> Producto_Proveedor { get; set; }
    }
}
