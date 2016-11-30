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
using ConsumerConsoleApp.Models.Students;

namespace ConsumerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BusinessDbContext();
            var repo = new BaseRepository<Student>(db);
            var studentService = new BaseService<Student,StudentRequestModel, StudentViewModel>(repo);
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
            //service.Add(student);

            try
            {
                Console.WriteLine("Input your keyword and press Enter: ");
                var keyword = Console.ReadLine();
              //  List<StudentViewModel> list = studentService.GetAllAsync().GetAwaiter().GetResult();
                StudentRequestModel request=new StudentRequestModel(keyword);
                var searchResult = studentService.SearchAsync(request).GetAwaiter().GetResult();
                Console.WriteLine("Result found: "+searchResult.Item2);
                foreach (var vm in searchResult.Item1)
                {
                    Console.WriteLine(vm.Name + "\t"+ vm.Phone);
                }
            }
            catch (Exception exception)
            {                
                throw;
            }
            Console.Read();
        }
    }
}
