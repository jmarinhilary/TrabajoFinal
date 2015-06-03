﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Services;
using OnlineShop.Services.Entities;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OnlineShop.Common.ViewModels;


namespace OnlineShop.Web.Telerik.Controllers
{
    public class AdminProductoController : Controller
    {
        private ProductoService  _productoService;
        private MarcaService _marcaService;
        private CategoriaService _categoriaService;
        public AdminProductoController(ProductoService productoService, MarcaService marcaService,CategoriaService categoriaService)
        {
            this._productoService = productoService;
            this._marcaService = marcaService;
            this._categoriaService = categoriaService;
        }
        public ActionResult Index()
        {
            var productos = _productoService.ProductoAdminInit();
            return View(productos);
        }

        public ActionResult productoRead([DataSourceRequest]DataSourceRequest request)
        {
            var productos = _productoService.GetProductsAdmin();
            DataSourceResult result = productos.ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult createProductoModal() 
        { 
            CreateProductoViewModel viewModel = new CreateProductoViewModel();
            ViewData["Marcas"] = _marcaService.GetMarcas();
            ViewData["Categorias"] = _categoriaService.GetCategoria();
            return PartialView("createProductoModal", viewModel);
        }

        [HttpPost]
        public JsonResult createRegistroProducto(CreateProductoViewModel viewModel)
        {
            return null;
        }

        
        public ActionResult editProductoModal(int id = 0)
        {
            EditProductoViewModel viewModel = new EditProductoViewModel();
            viewModel = _productoService.ProductoAdminEditInit(id);
            ViewData["Marcas"] = _marcaService.GetMarcas();
            ViewData["Categorias"] = _categoriaService.GetCategoria();
            return PartialView("editProductoModal", viewModel);
        }

        [HttpPost]
        public ActionResult EditRegistroProducto(EditProductoViewModel viewModel) 
        {
            return null;
        }
    }
}