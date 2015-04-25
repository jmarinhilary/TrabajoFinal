using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class ImagenesRepository : RepositoryBase<Imagenes, ShopContext>
    {
        public ImagenesRepository(ShopContext context)
            : base(context)
        {

        }
    }
}
