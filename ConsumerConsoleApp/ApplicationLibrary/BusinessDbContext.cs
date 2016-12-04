using System.Data.Entity;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;

namespace ApplicationLibrary
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }


        private static BusinessDbContext _db;
        public static BusinessDbContext CreateInstance()
        {
            return _db ?? (_db = new BusinessDbContext());
        }
    }
}
