using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Services;
using OnlineShop.Services.Entities;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using OnlineShop.Common.ViewModels;
using OnlineShop.Fx.Util;
using System.IO;
using OnlineShop.Fx;


namespace OnlineShop.Web.Telerik.Controllers
{
    
    [Authorize(Roles="Admin")]
    public class AdminProductoController : Controller
    {
        private ProductoService  _productoService;
        private MarcaService _marcaService;
        private CategoriaService _categoriaService;
        private ImagenService _imagenService;

        public AdminProductoController(ProductoService productoService, MarcaService marcaService, CategoriaService categoriaService, ImagenService imagenService)
        {
            this._productoService = productoService;
            this._marcaService = marcaService;
            this._categoriaService = categoriaService;
            this._imagenService = imagenService;
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
        public ActionResult createRegistroProducto(CreateProductoViewModel viewModel)
        {
            var result =  _productoService.createProducto(viewModel);
            return Json(new JSResultView(result));
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
        public ActionResult editRegistroProducto(EditProductoViewModel viewModel) 
        {
            var result = _productoService.updateProducto(viewModel);
            return null;
        }

        public ActionResult imagenProductoModal(int id = 0)
        {
            var imagenes = _productoService.getImagesbyProduct(id);
            return PartialView(imagenes);
        }

        public ActionResult GrabarImagen(int Id) 
        {
            bool isSavedSuccessfully = true;
            string fileName = "";
            try
            {
                foreach (string item in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[item];
                    fileName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        ImagenesViewModel viewModel = new ImagenesViewModel();                        
                        var originalDirectory = new DirectoryInfo(Server.MapPath(@"\"));
                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), Constants.CarpetaImagenes);
                        var fileName1 = Path.GetFileName(file.FileName);
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);

                        viewModel.IdProducto = Id;
                        viewModel.Ruta = file.FileName;

                        var path = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(path);
                        _imagenService.GrabarImagenesProducto(viewModel);
                        
                    }
                }
            }
            catch (Exception ex) 
            {
                isSavedSuccessfully = false;

            }       
            if (isSavedSuccessfully)
            {
                return Json(new { Message = fileName, parametro = fileName });
            }
            else
            {
                return Json(new { Message = "Error en grabar el Parametro" });
            }            
        }

        [HttpPost]
        public ActionResult DeleteImage(int key = 0) 
        {
            return View();
        }
    }
}