using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class MarcaRepository : RepositoryBase<Marca, ShopContext>
    {
        public MarcaRepository(ShopContext _context)
            : base(_context)
        {

        }
    }
}
