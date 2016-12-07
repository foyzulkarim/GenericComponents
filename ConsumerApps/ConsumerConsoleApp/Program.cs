using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLibrary;
using ApplicationLibrary.Models.Departments;
using Commons.Repository;
using Commons.RequestModel;
using Commons.Service;

namespace ConsumerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BusinessDbContext();
            var departmentRepo = new BaseRepository<Department>(db);
            var departmentService = new BaseService<Department,DepartmentRequestModel,DepartmetnViewModel>(departmentRepo);

            // we set the fake values here
            var department = new Department()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "department-" + DateTime.Now.Ticks,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "foyzulkarim@gmail.com",
                ModifiedBy = "foyzulkarim@gmail.com"
            };
            departmentService.Add(department);

            //now lets fetch those all
            //var departments = departmentService.GetAllAsync().GetAwaiter().GetResult();
            //foreach (var d in departments)
            //{
            //    Console.WriteLine(d.Name);
            //}

            // now lets search by keyword
            Console.WriteLine("Input your keyword and press Enter: ");
            var keyword = Console.ReadLine();

            DepartmentRequestModel request=new DepartmentRequestModel(keyword);
            var result = departmentService.SearchAsync(request).GetAwaiter().GetResult();
            Console.WriteLine("Search result : "+result.Item2);
            foreach (var viewModel in result.Item1)
            {
                Console.WriteLine(viewModel.Name);
            }
            Console.Read();
        }
    }
}
