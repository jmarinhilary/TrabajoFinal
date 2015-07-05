using AutoMapper;
using OnlineShop.Common.ViewModels;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMapping";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Producto, EditProductoViewModel>();
            Mapper.CreateMap<Marca, MarcaViewModel>();
            Mapper.CreateMap<Pedido, PedidoViewModel>();
        }
    }
}