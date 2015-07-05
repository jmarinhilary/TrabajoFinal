using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Common.ViewModels
{
    public class PedidoAdminViewModel
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public string UserName { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaExpira { get; set; }
        public decimal? Total { get; set; }
        public int? IdEstadoPed { get; set; }
        public int? IdMedioDePago { get; set; }
        public int? IdEmpleado { get; set; }
    }

    public class PedidoDetalleViewModel 
    {

        public int? IdPedido { get; set; }
        public int? IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Imagen { get; set; }
        public int? Item { get; set; }
        public int? Cantidad { get; set; }        
        public decimal? Precio { get; set; }        
        public decimal? Igv { get; set; }        
        public decimal? PTotal { get; set; }

        public int? idEstado { get; set; }
    }
}
