using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int? Stock { get; set; }

        public int? IdMarca { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? PrecioCosto { get; set; }

        public string Descontinuado { get; set; }

        public string Sku { get; set; }

        //public Categoria Categoria { get; set; }

        //public virtual Marca Marca { get; set; }

        //public virtual ICollection<Pedido_Producto> Pedido_Producto { get; set; }

        //public virtual ICollection<Producto_Proveedor> Producto_Proveedor { get; set; }
    }
}
