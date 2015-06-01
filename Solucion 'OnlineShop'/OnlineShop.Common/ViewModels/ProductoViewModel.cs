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

        public bool Descontinuado { get; set; }

        public string Sku { get; set; }

        public string Ruta { get; set; }

        public int Cantidad { get; set; }

        public IEnumerable<ImagenesViewModel> Imagenes { get; set; }

    }

    public class ProductoIndexViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sku { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioCosto { get; set; }
        public string Ruta { get; set; }

    }    

}
