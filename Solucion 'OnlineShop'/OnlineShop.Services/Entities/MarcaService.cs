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
    public class MarcaService : IDisposable
    {
        private IRepository<Marca> _marcaRepository;
        private ShopContext _context;
        public MarcaService()
        {
            this._context = new ShopContext();
            this._marcaRepository = new MarcaRepository(_context);
        }

        public IEnumerable<MarcaViewModel> GetMarcas()
        {
            var Marcas = _marcaRepository.Get();
            Mapper.CreateMap<Marca, MarcaViewModel>();
            return Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(Marcas);
        }

        public void Dispose()
        {
            this._context = null;
            this._marcaRepository = null;
        }
    }
}