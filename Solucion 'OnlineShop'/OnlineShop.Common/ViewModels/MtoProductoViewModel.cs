using OnlineShop.Fx.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace OnlineShop.Common.ViewModels
{
    public class MtoProductoViewModel
    {
    }

    public class ProductoAdminViewModel
    {
        [Display(Name="Busqueda")]
        public string SeachCriteria { set; get; }
        public List<ProductoViewModel> ListaProducto { get; set; }
    }

    public class CreateProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [AllowHtml]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [RegularExpression(RegExp.OnlyNumbers)]
        public int? Stock { get; set; }

        [Display(Name = "Marca")]
        public int? IdMarca { get; set; }

        [Display(Name = "Categoría")]
        public int? IdCategoria { get; set; }
        public int? PrecioCostoIdCategoria { get; set; }
        public decimal? PrecioCosto { get; set; }
        public bool Descontinuado { get; set; }
        public string Sku { get; set; }

    }

    public class EditProductoViewModel 
    {
        public int Id { get; set; }

        public string Nombre { get; set; }  

        [Display(Name="Descripción")]
        [AllowHtml]
        public string Descripcion { get; set; }
        public int? Stock { get; set; }

        [Display(Name="Marca")]
        public int? IdMarca { get; set; }

        [Display(Name="Categoría")]
        public int? IdCategoria { get; set; }
        public int? PrecioCostoIdCategoria { get; set; }
        public decimal? PrecioCosto { get; set; }
        public bool Descontinuado { get; set; }
        public string Sku { get; set; }
    }
}
