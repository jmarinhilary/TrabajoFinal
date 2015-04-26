using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.ViewModels
{
    public class PedidoViewModel
    {
        public int? IdCliente { get; set; }

        public string UserName { get; set; }

        public DateTime? FechaPedido { get; set; }

        public DateTime? FechaExpira { get; set; }

        public int? IdEstadoPed { get; set; }

        public int? IdMedioDePago { get; set; }

        public int? IdEmpleado { get; set; }
    }
}
