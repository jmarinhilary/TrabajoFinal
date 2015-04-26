using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
