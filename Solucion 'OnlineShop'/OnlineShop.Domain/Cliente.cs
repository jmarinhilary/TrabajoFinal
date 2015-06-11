namespace OnlineShop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente : EntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }


        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string ApellidoP { get; set; }

        [StringLength(50)]
        public string ApellidoM { get; set; }

        [StringLength(8)]
        public string DNI { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string Ubigeo { get; set; }

        [StringLength(24)]
        public string Telefono { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        public DateTime? FechaNac { get; set; }

        [StringLength(100)]
        public string NroTarjeta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
