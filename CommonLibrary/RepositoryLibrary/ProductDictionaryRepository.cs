using Model;
using Model.Products;

namespace RepositoryLibrary
{
    public class ProductDictionaryRepository : BaseRepository<Product>
    {
        public ProductDictionaryRepository(BusinessDbContext db) : base(db)
        {
        }
    }
}
