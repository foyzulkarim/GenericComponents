using Model;
using Model.Shops;

namespace RepositoryLibrary
{
    public class SupplierRepository : BaseRepository<Partner>
    {
        public SupplierRepository(BusinessDbContext db) : base(db)
        {
        }
    }
}