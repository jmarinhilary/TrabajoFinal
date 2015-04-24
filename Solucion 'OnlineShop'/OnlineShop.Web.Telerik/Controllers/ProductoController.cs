using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Services.Entities;

namespace OnlineShop.Web.Telerik.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            this._productoService = productoService;
        }
        // GET: Producto
        public ActionResult Index()
        {
            var productos = _productoService.GetProducts();
            return View();
        }
    }
}