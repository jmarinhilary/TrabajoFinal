using OnlineShop.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Telerik.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        
        private PedidoService _pedidoService;
        public PedidoController(PedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPedido() 
        {
            var pedidosList = _pedidoService.GetPedidosUser(User.Identity.Name);
            return Json(pedidosList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetalle(int idPedido = 0) 
        {
            var pedidosDetalle = _pedidoService.GetPedidoDetalle(idPedido);
            return Json(pedidosDetalle, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string AnularPedido(int idPedido = 0) {
            var result = _pedidoService.AnularPedido(idPedido);
            return result;
        }
    }
}