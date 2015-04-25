using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using AutoMapper;
using OnlineShop.Common.ViewModels;

namespace OnlineShop.Services.Entities
{
    public class ProductoService : IDisposable
    {
        private IRepository<Producto> _productoRepository;
        private IRepository<Imagenes> _imagenesRepository;
        private ShopContext _shopContext;

        public ProductoService()
        {
            this._shopContext = new ShopContext();
            this._productoRepository = new ProductoRepository(_shopContext);
            this._imagenesRepository = new ImagenesRepository(_shopContext);
        }

        public IEnumerable<ProductoViewModel> GetProducts()
        {
            var productos = (from P in _productoRepository.Get()
                             join F in _imagenesRepository.Get() on P.Id equals F.IdProducto
                             where F.Tipo == "P"
                             select new ProductoViewModel{ Id = P.Id, Sku = P.Sku, Nombre = P.Nombre, Descripcion = P.Descripcion, PrecioCosto = P.PrecioCosto, Ruta = F.Ruta }).ToList();
            //Mapper.CreateMap<Producto, ProductoViewModel>();
            ////Mapper.CreateMap<Producto,ProductoViewModel>();
            //IEnumerable<ProductoViewModel> productoViewModel = Mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoViewModel>>(productos);
            ////productoViewModel = Mapper.Map<IEnumerable<Producto>, List<ProductoViewModel>(productos);
            return productos;
        }



        public void Dispose()
        {
            this._productoRepository = null;
            this._shopContext = null;
        }
    }
}
