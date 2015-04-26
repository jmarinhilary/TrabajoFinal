using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido,ShopContext>
    {
        public PedidoRepository(ShopContext context) 
            : base(context)
        {

        }
    }
}
