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
using OnlineShop.Common.ViewModels;
using AutoMapper;

namespace OnlineShop.Web.Test.Services
{

    [TestFixture]
    public class productoService
    {

        private IRepository<Producto> ProductsRepositoryStub;
        private IRepository<Imagenes> ImagesRepositoryStub;       
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
            productsList.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void GetProduct_ForEdit()
        {
            ProductsRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Producto>(
                new List<Producto>(){
                    new Producto {Id = 1,Nombre = "Laptop HP", IdCategoria = 2 }
                }));
            Mapper.CreateMap<Producto, EditProductoViewModel>();
            var product = ProductsService.ProductoAdminEditInit(1);
            product.Should().NotBeNull();
        }

        [Test]
        public void CreateProductSuccess()
        {
            CreateProductoViewModel viewModel = new CreateProductoViewModel
            {
                Nombre = "Laptop hp ",
                Sku = "45552",
                PrecioCosto = 1500
            };
            Mapper.CreateMap<CreateProductoViewModel, Producto>();
            var product = ProductsService.createProducto(viewModel);
            Assert.AreEqual("Se registró el Producto", product);
        }

        [Test]
        public void ErrorCreateProduct()
        {
            CreateProductoViewModel viewModel = new CreateProductoViewModel
            {
                Nombre = "Laptop hp ",
                Sku = "45552",
                PrecioCosto = 1500
            };
            Mapper.CreateMap<CreateProductoViewModel, Producto>();
            var product = ProductsService.createProducto(viewModel);
            Assert.AreNotEqual("Error al registrar el Producto", product);
        }


    }
}
