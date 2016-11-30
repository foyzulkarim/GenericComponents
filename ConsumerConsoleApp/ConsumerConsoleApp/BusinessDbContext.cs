using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Model;
using ConsumerConsoleApp.Models;
using ConsumerConsoleApp.Models.Departments;
using ConsumerConsoleApp.Models.Students;

namespace ConsumerConsoleApp
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
