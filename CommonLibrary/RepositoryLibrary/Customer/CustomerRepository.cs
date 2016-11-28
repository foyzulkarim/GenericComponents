using Model;

namespace RepositoryLibrary.Customer
{
    public class CustomerRepository : BaseRepository<Model.Customers.Customer>
    {
        public CustomerRepository(BusinessDbContext db) : base(db)
        {
        }
    }
}