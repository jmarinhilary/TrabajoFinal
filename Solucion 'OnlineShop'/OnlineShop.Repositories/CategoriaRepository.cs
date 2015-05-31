using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, ShopContext>
    {
        public CategoriaRepository(ShopContext _context)
            : base(_context)
        {

        }
    }
}
