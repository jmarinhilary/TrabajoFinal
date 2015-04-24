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
        private ShopContext _shopContext;

        public ProductoService()
        {
            this._shopContext = new ShopContext();
            this._productoRepository = new ProductoRepository(_shopContext);
        }

        public IEnumerable<ProductoViewModel> GetProducts()
        {
            var productos = _productoRepository.Get().AsEnumerable();
            Mapper.CreateMap<Producto, ProductoViewModel>();
            //Mapper.CreateMap<Producto,ProductoViewModel>();

            IEnumerable<ProductoViewModel> productoViewModel = Mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoViewModel>>(productos);
            //productoViewModel = Mapper.Map<IEnumerable<Producto>, List<ProductoViewModel>(productos);
            return productoViewModel;
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
