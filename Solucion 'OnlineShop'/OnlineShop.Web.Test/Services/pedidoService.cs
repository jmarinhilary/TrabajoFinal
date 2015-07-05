using NUnit.Framework;
using OnlineShop.Common.ViewModels;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using OnlineShop.Services.Entities;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace OnlineShop.Web.Test.Services
{
    [TestFixture]
    public class pedidoService
    {
        
        private IRepository<Pedido> PedidoRepositoryStub;
        private IRepository<Pedido_Producto> PedidoproductoRepositoryStub;
        private IRepository<Cliente> ClienteRepositoryStub;
        private IRepository<Producto> ProductsRepositoryStub;
        private PedidoService PedidoService;

        [SetUp]
        public void Setup()
        {            
            PedidoRepositoryStub = MockRepository.GenerateMock<IRepository<Pedido>>();
            PedidoproductoRepositoryStub = MockRepository.GenerateMock<IRepository<Pedido_Producto>>();
            ClienteRepositoryStub = MockRepository.GenerateMock<IRepository<Cliente>>();
            ProductsRepositoryStub = MockRepository.GenerateMock<IRepository<Producto>>();
            PedidoService = new PedidoService(PedidoRepositoryStub, PedidoproductoRepositoryStub, ClienteRepositoryStub, ProductsRepositoryStub);
        }


        [TearDown]
        public void TearDown()
        {
            PedidoRepositoryStub = null;
            PedidoproductoRepositoryStub = null;
            ClienteRepositoryStub = null;
            ProductsRepositoryStub = null;
            PedidoService = null;
        }


        [Test]
        public void CreateErrorPedido() 
        {
            PedidoViewModel Pedido = new PedidoViewModel { UserName = "jmarinhilary@gmail.com" };
            ClienteRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Cliente>(
                new List<Cliente>(){
                    new Cliente {Id = 1,Email = "jmarinhilary@gmail.com" }
                }));
            ProductsRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Producto>(
               new List<Producto>(){
                    new Producto {Id = 1,Nombre = "Laptop HP", IdCategoria = 2 }
                }));
            PedidoRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Pedido>(
               new List<Pedido>(){
                    new Pedido {Id = 1}
                }));
            List<ProductoViewModel> Carrito = new List<ProductoViewModel>() { new ProductoViewModel { Id = 1, Cantidad = 3, PrecioCosto = 3000} };
            var pedidoId = PedidoService.Create(Pedido, Carrito);
            pedidoId.Should().Be(0, "Debe ser  0");
        }

    }
}
