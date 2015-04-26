using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class PedidoProductoRepository : RepositoryBase<Pedido_Producto,ShopContext>
    {
        public PedidoProductoRepository(ShopContext context)
            :base(context)
        {

        }
    }
}
