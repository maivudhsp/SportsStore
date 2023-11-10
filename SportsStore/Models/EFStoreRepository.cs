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

        public void CreateProduct(Product p)
        {
            _ctx.Add(p);
            _ctx.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            _ctx.Remove(p);
            _ctx.SaveChanges();
        }

        public void SaveProduct(Product p)
        {
            _ctx.SaveChanges();
        }
    }
}
