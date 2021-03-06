﻿using AutoMapper;
using OnlineShop.Common.ViewModels;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services.Entities
{
    public class ImagenService : IDisposable
    {
        private IRepository<Imagenes> _imagenesRepository;        

        public ImagenService(IRepository<Imagenes> imagenesRepository)	
        {
            this._imagenesRepository = imagenesRepository;
        }

        public void GrabarImagenesProducto(ImagenesViewModel viewModel) 
        {
            viewModel.Ruta = string.Format("~/Imagenes/{0}", viewModel.Ruta);
            viewModel.Estado = "A";
            if (_imagenesRepository.Get().Where(x => x.IdProducto == viewModel.IdProducto && x.Tipo == "P").Any())
            {
                viewModel.Tipo = "C";
            }
            else
            {
                viewModel.Tipo = "P";
            }
            Mapper.CreateMap<ImagenesViewModel, Imagenes>();
            var Imagenes = Mapper.Map<Imagenes>(viewModel);
            var Id = _imagenesRepository.Create(Imagenes);                
        }

        public void Dispose()
        {            
            this._imagenesRepository = null;
        }
    }
}
