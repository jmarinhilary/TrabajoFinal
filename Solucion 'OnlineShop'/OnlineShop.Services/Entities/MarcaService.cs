using AutoMapper;
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
        public MarcaService(IRepository<Marca> marcaRepository)
        {
            this._marcaRepository = marcaRepository;
        }

        public IEnumerable<MarcaViewModel> GetMarcas()
        {
            var Marcas = _marcaRepository.Get();            
            return Mapper.Map<IEnumerable<Marca>, IEnumerable<MarcaViewModel>>(Marcas);
        }

        

        public void ActualizarMarca(MarcaViewModel marcaViewModel)
        {
            var marca = Mapper.Map<MarcaViewModel, Marca>(marcaViewModel);
            _marcaRepository.Update(marca);
        }

        public void InsertarMarca(MarcaViewModel marcaViewModel)
        {
            var marca = Mapper.Map<MarcaViewModel, Marca>(marcaViewModel);
            _marcaRepository.Create(marca);
        }

        public void Dispose()
        {
            this._marcaRepository = null;
        }
    }
}
