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
    public class PedidoService : IDisposable
    {
        private IRepository<Pedido> _pedidoRepository;
        private IRepository<Pedido_Producto> _pedidoproductoRepository;
        private IRepository<Cliente> _clienteRepository;
        private ShopContext _shopContext;

        public PedidoService()
        {
            this._shopContext = new ShopContext();
            this._pedidoRepository = new PedidoRepository(_shopContext);
            this._pedidoproductoRepository = new PedidoProductoRepository(_shopContext);
            this._clienteRepository = new ClienteRepository(_shopContext);
        }

        public int Create(PedidoViewModel pedidoViewModel, List<ProductoViewModel> Carrito) 
        {
            var cliente = _clienteRepository.Get().Where(m => m.Email == pedidoViewModel.UserName).FirstOrDefault();
            var pedido = new Pedido { 
                IdCliente = cliente.Id,
                FechaPedido = pedidoViewModel.FechaPedido,
                FechaExpira = pedidoViewModel.FechaExpira
            };
            var pedidoId = _pedidoRepository.Create(pedido);
            int Cont = 0;
            foreach (var item in Carrito)
            {
                var detalle = new Pedido_Producto
                {
                    IdPedido = pedidoId,
                    IdProducto = item.Id,
                    Item = Cont += 1,
                    Cantidad = item.Cantidad,
                    Precio = item.PrecioCosto,
                    Igv = (item.Cantidad * item.PrecioCosto) * 0.18m,
                    PTotal = (item.Cantidad * item.PrecioCosto) * 1.18m
                };
                _pedidoproductoRepository.Create(detalle);
            }
            return pedidoId;
        }



        public void Dispose()
        {
            this._clienteRepository = null;
            this._pedidoproductoRepository = null;
            this._pedidoRepository = null;
            this._shopContext = null;
        }
    }
}
