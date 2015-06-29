using OnlineShop.Fx;
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

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        [Display(Name = "Nombre de Producto")]
        public string Nombre { get; set; }

        [AllowHtml]
        [Display(Name = "Descripción")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        public string Descripcion { get; set; }

        [StringLength(9, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoNumericoMaximoLongitud")]
        [RegularExpression(RegExp.OnlyNumbers)]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        public int? Stock { get; set; }

        [Display(Name = "Marca")]
        public int? IdMarca { get; set; }

        [Display(Name = "Categoría")]
        public int? IdCategoria { get; set; }
        public int? PrecioCostoIdCategoria { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        [Display(Name = "Precio al Público")]
        public decimal? PrecioCosto { get; set; }
        public bool Descontinuado { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        public string Sku { get; set; }

    }

    public class EditProductoViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        [Display(Name = "Nombre de Producto")]
        public string Nombre { get; set; }  

        [Display(Name="Descripción")]
        [AllowHtml]        
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        public string Descripcion { get; set; }

        [StringLength(9, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoNumericoMaximoLongitud")]
        [RegularExpression(RegExp.OnlyNumbers)]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        public int? Stock { get; set; }

        [Display(Name="Marca")]
        public int? IdMarca { get; set; }

        [Display(Name="Categoría")]
        public int? IdCategoria { get; set; }
        public int? PrecioCostoIdCategoria { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CampoRequeridoCustom")]
        [Display(Name = "Precio al Público")]
        public decimal? PrecioCosto { get; set; }
        public bool Descontinuado { get; set; }
        public string Sku { get; set; }
    }
}
