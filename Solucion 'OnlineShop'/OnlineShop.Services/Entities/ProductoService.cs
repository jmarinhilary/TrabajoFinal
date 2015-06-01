﻿using System;
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

        public IEnumerable<ProductoIndexViewModel> GetProducts()
        {
            var productos = (from p in _productoRepository.Get()
                             join f in _imagenesRepository.Get() on p.Id equals f.IdProducto
                             where f.Tipo == "P"
                             select new ProductoIndexViewModel
                             {
                                 Id = p.Id,
                                 Sku = p.Sku,
                                 Nombre = p.Nombre,
                                 Descripcion = p.Descripcion,
                                 PrecioCosto = p.PrecioCosto,
                                 Ruta = f.Ruta
                             }).ToList();
            //Mapper.CreateMap<Producto, ProductoViewModel>();
            ////Mapper.CreateMap<Producto,ProductoViewModel>();
            //IEnumerable<ProductoViewModel> productoViewModel = Mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoViewModel>>(productos);
            ////productoViewModel = Mapper.Map<IEnumerable<Producto>, List<ProductoViewModel>(productos);
            return productos;
        }

        public ProductoAdminViewModel ProductoAdminInit()
        {
            ProductoAdminViewModel viewModel = new ProductoAdminViewModel();
            viewModel.ListaProducto = GetProductsAdmin();
            return viewModel;
        }

        public List<ProductoViewModel> GetProductsAdmin()
        {
            var ListaProducto = _productoRepository.Get()
                                        .Select(x => new ProductoViewModel
                                        {
                                            Id = x.Id,
                                            Nombre = x.Nombre,
                                            Cantidad = 0
                                        }).ToList();
            return ListaProducto;
        }

        public ProductoViewModel GetProduct(int id)
        {
            ProductoViewModel productoViewModel = (from p in _productoRepository.Get()
                                                   where p.Id == id
                                                   select new ProductoViewModel
                                                   {
                                                       Id = p.Id,
                                                       Sku = p.Sku,
                                                       Nombre = p.Nombre,
                                                       Descripcion = p.Descripcion,
                                                       PrecioCosto = p.PrecioCosto,
                                                   }).FirstOrDefault();            
            productoViewModel.Imagenes = (from f in _imagenesRepository.Get()
                                          where f.IdProducto == id
                                          select new ImagenesViewModel
                                          {
                                              Id = f.Id,
                                              Ruta = f.Ruta,
                                              Tipo = f.Tipo
                                          }).ToList();
            return productoViewModel;
        }

        public EditProductoViewModel ProductoAdminEditInit(int id)
        {
            EditProductoViewModel viewModel = new EditProductoViewModel();
            var producto = _productoRepository.Get().Where(x => x.Id == id).FirstOrDefault();
            Mapper.CreateMap<Producto, EditProductoViewModel>();
            viewModel = Mapper.Map<EditProductoViewModel>(producto);
            return viewModel;
        }

        public void Dispose()
        {
            this._productoRepository = null;
            this._imagenesRepository = null;
            this._shopContext = null;
        }
        
    }
}
