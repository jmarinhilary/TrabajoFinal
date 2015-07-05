using NUnit.Framework;
using OnlineShop.Domain;
using OnlineShop.Repositories;
using OnlineShop.Services.Entities;
using Rhino.Mocks;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Web.Test.Services
{

    [TestFixture]
    public class productoService
    {

        private IRepository<Producto> playlistRepositoryStub;
        private IRepository<Imagenes> customerRepositoryStub;
        private IRepository<ImagesRepositoryStub> trackRepositoryStub;
        private ProductoService ProductsService;

        [SetUp]
        public void Setup()
        {
            ProductsRepositoryStub = MockRepository.GenerateMock<IRepository<Producto>>();
            ImagesRepositoryStub = MockRepository.GenerateMock<IRepository<Imagenes>>();
            ProductsService = new ProductoService(ProductsRepositoryStub, ImagesRepositoryStub);            
        }

        [TearDown]
        public void TearDown()
        {
            ProductsRepositoryStub = null;
            ImagesRepositoryStub = null;
            ProductsService = null;            
        }
        

        [Test]
        public void GetProducts_WithImages() 
        {           
            ProductsRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Producto>(
                new List<Producto>(){
                    new Producto {Id = 1,Nombre = "Laptop HP", IdCategoria = 2 }
                }));

            ImagesRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Imagenes>(
                new List<Imagenes>(){
                    new Imagenes{ Id =1, Ruta = "~/Imagenes/jgh_1.jpg", IdProducto=1, Estado = "A", Tipo = "P" }
            }));
            var productsList = ProductsService.GetProducts();
            productsList.Should().NotBeEmpty();
        }

        [Test]
        public void GetProducts_Initial() 
        {
            var ProductsRepositoryStub = MockRepository.GenerateMock<IRepository<Producto>>();
            var ImagesRepositoryStub = MockRepository.GenerateMock<IRepository<Imagenes>>();
            var ProductsService = new ProductoService(ProductsRepositoryStub, ImagesRepositoryStub); 
        }


    }
}
