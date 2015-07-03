using OnlineShop.Common.ViewModels;
using OnlineShop.Fx;
using OnlineShop.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Telerik.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MarcaController : Controller
    {
        private MarcaService _marcaService;
        public MarcaController(MarcaService marcaService)
        {
            this._marcaService = marcaService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMarcas()
        {
            var marcasList = _marcaService.GetMarcas();
            return Json(marcasList, JsonRequestBehavior.AllowGet);
        }

        public string Update(MarcaViewModel marcaViewModel)
        {
            if (marcaViewModel != null)
            {
                _marcaService.ActualizarMarca(marcaViewModel);
                return Messages.MensajeActualizarSatisf;
            }
            else
            {
                return Messages.MensajeActualzarError;
            }
        }

        public string Add(MarcaViewModel marcaViewModel)
        {
            try
            {
                if (marcaViewModel != null)
                {
                    _marcaService.InsertarMarca(marcaViewModel);
                    return Messages.InsercionCorrecta;
                }
                else
                {
                    return Messages.InsercionIncorrecta ;
                }
            }

            catch
            {
                return Messages.InsercionIncorrecta;
            }
        }
    }
}