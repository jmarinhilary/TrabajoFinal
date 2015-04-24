using OnlineShop.Domain;

namespace OnlineShop.Repositories
{
    public class ProductoRepository : RepositoryBase<Producto, ShopContext>
    {
        public ProductoRepository(ShopContext context)
            : base(context)
        {

        }
    }
}
