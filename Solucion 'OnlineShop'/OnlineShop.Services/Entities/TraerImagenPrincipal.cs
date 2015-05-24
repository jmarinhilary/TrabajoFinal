using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using OnlineShop.Domain;

namespace OnlineShop.Services.Entities
{
    public class TraerImagenPrincipal : ITypeConverter<List<Imagenes>,string>
    {
        public string Convert(ResolutionContext context)
        {
            var lista = (List<Imagenes>)context.SourceValue;
            var imagen = lista.FirstOrDefault(x => x.Tipo == "P");
            return imagen.Ruta;
        }
    }
}
