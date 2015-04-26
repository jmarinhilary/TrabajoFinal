using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, ShopContext>
    {
        public ClienteRepository(ShopContext context) 
            : base(context)
        {

        }

           
    }
}
