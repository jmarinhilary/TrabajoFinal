using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Services.Entities;

namespace OnlineShop.Web.Telerik.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminPedidoController : Controller
    {

        private PedidoService _pedidoService;

        public AdminPedidoController(PedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPedido() 
        {
            var pedidosList = _pedidoService.GetPedidosAdmin();
            return Json(pedidosList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetalle(int idPedido = 0) 
        {
            var pedidosDetalle = _pedidoService.GetPedidoDetalle(idPedido);
            return Json(pedidosDetalle, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string ConfirmarPedido(int idPedido = 0) {
            var result = _pedidoService.ConfirmarPedido(idPedido);
            return result;
        }
    }
}