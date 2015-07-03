using AutoMapper;
using OnlineShop.Common.ViewModels;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CreateProductoViewModel, Producto>();
            Mapper.CreateMap<EditProductoViewModel, Producto>();
            Mapper.CreateMap<MarcaViewModel, Marca>();
        }
    }
}