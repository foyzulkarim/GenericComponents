using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Repository;
using Commons.RequestModel;
using Commons.Service;
using Commons.ViewModel;
using ConsumerConsoleApp.Models;

namespace ConsumerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BusinessDbContext();
            var repo = new BaseRepository<Student>(db);
            var service = new BaseService<Student,RequestModel<Student>,BaseViewModel<Student>>(repo);
            Student student = new Student()
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "me",
                ModifiedBy = "me",
                Name = "temp-" + DateTime.Now.Ticks,
                Phone = DateTime.Now.Ticks.ToString()
            };
            service.Add(student);
            
            List<BaseViewModel<Student>> list = service.GetAllAsync().GetAwaiter().GetResult();

        }
    }
}
