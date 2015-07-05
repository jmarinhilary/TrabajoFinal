using AutoMapper;
using OnlineShop.Common.ViewModels;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Fx;

namespace OnlineShop.Services.Entities
{
    public class PedidoService : IDisposable
    {
        private IRepository<Pedido> _pedidoRepository;
        private IRepository<Pedido_Producto> _pedidoproductoRepository;
        private IRepository<Cliente> _clienteRepository;
        private IRepository<Producto> _productoRepository;

        public PedidoService( IRepository<Pedido> pedidoRepository,IRepository<Pedido_Producto> pedidoproductoRepository,IRepository<Cliente> clienteRepository,IRepository<Producto> productoRepository)
        {
            this._pedidoRepository = pedidoRepository;
            this._pedidoproductoRepository = pedidoproductoRepository;
            this._clienteRepository = clienteRepository;
            this._productoRepository = productoRepository;
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

        public List<PedidoAdminViewModel> GetPedidosAdmin() 
        {
            var pedidos = (from p in _pedidoRepository.Get()
                           join c in _clienteRepository.Get() on p.IdCliente equals c.Id
                           select new PedidoAdminViewModel { 
                               Id = p.Id,
                               IdCliente = c.Id,
                               IdEstadoPed = p.IdEstadoPed,
                               UserName = c.Nombre + " " + c.ApellidoP,
                               Total = p.Pedido_Producto.Sum(x => x.PTotal),
                               FechaPedido = p.FechaPedido,
                               FechaExpira = p.FechaExpira
                           }
            ).ToList();            
            return pedidos;
        }


        public List<PedidoDetalleViewModel> GetPedidoDetalle(int idPedido)
        {
            try 
            {
                var Detalle = _pedidoRepository.Get().Where(x => x.Id == idPedido).FirstOrDefault().Pedido_Producto;
                var Estado = _pedidoRepository.Get().Where(x => x.Id == idPedido).FirstOrDefault().IdEstadoPed;
                var result = (from d in Detalle
                              join p in _productoRepository.Get() on d.IdProducto equals p.Id
                              select new PedidoDetalleViewModel
                              {
                                  IdPedido = d.IdPedido,
                                  IdProducto = d.IdProducto,
                                  NombreProducto = p.Nombre,
                                  Imagen = p.Imagenes.Where(x => x.Tipo == "P").FirstOrDefault().Ruta.Substring(2, p.Imagenes.Where(x => x.Tipo == "P").FirstOrDefault().Ruta.Length - 2),
                                  Item = d.Item,
                                  Cantidad = d.Cantidad,
                                  Precio = d.Precio,
                                  Igv = d.Igv,
                                  PTotal = d.PTotal,
                                  idEstado = Estado
                              }).ToList();
                return result;
            }
            catch(Exception ex)
            {
                return new List<PedidoDetalleViewModel>();
            }
            
        }

        public string ConfirmarPedido(int idPedido)
        {
            var pedido = _pedidoRepository.Get().Where(x => x.Id == idPedido).FirstOrDefault();
            pedido.IdEstadoPed = Convert.ToInt16(Constants.EstadoAprobado);
            _pedidoRepository.Update(pedido);
            return string.Format(Messages.PedidoAceptado, idPedido);
        }

        public string AnularPedido(int idPedido)
        {
            var pedido = _pedidoRepository.Get().Where(x => x.Id == idPedido).FirstOrDefault();
            pedido.IdEstadoPed = Convert.ToInt16(Constants.EstadoAnulado);
            _pedidoRepository.Update(pedido);
            return string.Format(Messages.PedidoAnulado, idPedido);
        }

        public List<PedidoAdminViewModel> GetPedidosUser(string UserName)
        {
            var pedidos = (from p in _pedidoRepository.Get()
                           join c in _clienteRepository.Get() on p.IdCliente equals c.Id
                           where c.Email == UserName
                           select new PedidoAdminViewModel
                           {
                               Id = p.Id,
                               IdCliente = c.Id,
                               IdEstadoPed = p.IdEstadoPed,
                               UserName = c.Nombre + " " + c.ApellidoP,
                               Total = p.Pedido_Producto.Sum(x => x.PTotal),
                               FechaPedido = p.FechaPedido,
                               FechaExpira = p.FechaExpira
                           }
            ).ToList();
            return pedidos;
        }

        public void Dispose()
        {
            this._clienteRepository = null;
            this._pedidoproductoRepository = null;
            this._pedidoRepository = null;            
        }        
    }
}
