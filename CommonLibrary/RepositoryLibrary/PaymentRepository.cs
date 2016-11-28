using System.Data.Entity;
using Model.Expenses;
using Model;

namespace RepositoryLibrary
{
    public class PaymentRepository : BaseRepository<Expense>
    {
        public PaymentRepository(BusinessDbContext db) : base(db)
        {
        }
    }
}
