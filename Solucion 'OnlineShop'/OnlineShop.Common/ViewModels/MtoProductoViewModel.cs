using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace OnlineShop.Common.ViewModels
{
    public class MtoProductoViewModel
    {
    }

    public class CreateProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [AllowHtml]
        public string Descripcion { get; set; }
        public int? Stock { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCategoria { get; set; }
        public int? PrecioCostoIdCategoria { get; set; }
        public decimal? PrecioCosto { get; set; }
        public string Descontinuado { get; set; }
        public string Sku { get; set; }

    }

    public class EditProductoViewModel 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  

        [AllowHtml]
        public string Descripcion { get; set; }
        public int? Stock { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCategoria { get; set; }
        public int? PrecioCostoIdCategoria { get; set; }
        public decimal? PrecioCosto { get; set; }
        public string Descontinuado { get; set; }
        public string Sku { get; set; }
    }
}
