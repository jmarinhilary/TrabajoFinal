using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Services.Entities;
using OnlineShop.Common.ViewModels;
using System.Net;
using System.Net.Http;

namespace OnlineShop.Web.Telerik.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoService _productoService;
        private PedidoService _pedidoService;

        public ProductoController(ProductoService productoService, PedidoService pedidoService)
        {
            this._productoService = productoService;
            this._pedidoService = pedidoService;
        }
        // GET: Producto
        public ActionResult Index()
        {
            var productos = _productoService.GetProducts();
            return View(productos);
        }

        public ActionResult ProductoDetalle(int id = 0)
        {
            var producto = _productoService.GetProduct(id);
            return View(producto);
        }

        public ActionResult Carrito(int id = 0)
        {
            List<ProductoViewModel> Carrito = new List<ProductoViewModel>();
            if (Session["Carrito"] != null)
            {
                Carrito = (List<ProductoViewModel>)Session["Carrito"];
            }
            if (id != 0)
            {
                if (Carrito.Any(x => x.Id == id))
                {
                    Carrito.Where(x => x.Id == id).Select(e => { e.Cantidad += 1; return e; }).ToList();
                }
                else
                {
                    var producto = _productoService.GetProduct(id);
                    producto.Cantidad += 1;
                    Carrito.Add(producto);
                }
                TempData["Mensaje"] = Carrito.LastOrDefault().Nombre + "se agrego a la cesta";
                Session["Carrito"] = Carrito;
            }
            return View(Carrito.AsEnumerable());
        }

        public ActionResult EliminaProd(int id = 0) 
        {
            if (id != 0) 
            {
                List<ProductoViewModel> Carrito = new List<ProductoViewModel>();
                Carrito = (List<ProductoViewModel>)Session["Carrito"];
                Carrito.RemoveAll(x => x.Id == id);
                Session["Carrito"] = Carrito;
            }
            return RedirectToAction("Carrito", new { id = 0 });
        }

        [Authorize]
        public ActionResult RegistroPedido()
        {
            List<ProductoViewModel> Carrito = new List<ProductoViewModel>();
            Carrito = (List<ProductoViewModel>) Session["Carrito"];
            PedidoViewModel pedidoViewModel = new PedidoViewModel();
            pedidoViewModel.UserName = User.Identity.Name;
            pedidoViewModel.FechaPedido = DateTime.Now;
            pedidoViewModel.FechaExpira = DateTime.Now.AddDays(5);
            var Pedido = _pedidoService.Create(pedidoViewModel, Carrito);
            ViewBag.Pedido = Pedido;
            Session["Carrito"] = null;
            return View();
        }


    }
}