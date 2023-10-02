namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _ctx;

        public EFStoreRepository(StoreDbContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Product> Products => _ctx.Products;
    }
}
