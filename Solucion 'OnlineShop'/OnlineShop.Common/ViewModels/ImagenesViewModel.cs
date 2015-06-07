using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OnlineShop.Common.ViewModels
{
    public class ImagenesViewModel
    {
        public int Id { get; set; }
        public string Ruta { get; set; }

        public int? IdProducto { get; set; }

        public string Estado { get; set; }

        public string Tipo { get; set; }

    }

    public class ImagenesPreviewViewModel 
    {
        public int IdProducto { get; set; }

        [AllowHtml]
        public string[] Ruta { get; set; }
        public List<OptionImages> ListaImagenes { get; set; }

    }

    public class OptionImages 
    {
        public string caption { get; set; }
        public string width { get; set; }
        public string url { get; set; }
        public int key { get; set; }
    }
}
