using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Model;
using ConsumerConsoleApp.Models;

namespace ConsumerConsoleApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
