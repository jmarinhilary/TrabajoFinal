using OnlineShop.Common.ViewModels;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OnlineShop.Services.Entities
{
    public class CategoriaService : IDisposable
    {
        private IRepository<Categoria> _categoriaRepository;
        private ShopContext _context;

        public CategoriaService()
        {
            this._context = new ShopContext();
            this._categoriaRepository = new CategoriaRepository(_context);
        }

        public IEnumerable<CategoriaViewModel> GetCategoria() 
        {
            var Categorias = _categoriaRepository.Get();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(Categorias);            
        }



        public void Dispose()
        {
            this._categoriaRepository = null;
            this._context = null;
        }
    }
}
