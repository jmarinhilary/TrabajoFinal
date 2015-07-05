using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using OnlineShop.Common.ViewModels;

namespace OnlineShop.Services.Entities
{
    
    public class ClienteService : IDisposable
    {
        private IRepository<Cliente> _clienteRepository;               

        public ClienteService(IRepository<Cliente> clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public void Create(ClienteViewModel ClienteViewModel) 
        {
            var Cliente = new Cliente
            {
                Nombre = ClienteViewModel.Nombre,
                ApellidoP = ClienteViewModel.ApellidoP,
                Email = ClienteViewModel.Email
            };
            _clienteRepository.Create(Cliente);
        }

        public void Dispose() 
        {            
            this._clienteRepository = null;
        }
    }
}
