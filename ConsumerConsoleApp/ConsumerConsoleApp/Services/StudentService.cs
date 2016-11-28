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

namespace ConsumerConsoleApp.Services
{
    public class StudentService : BaseService<Student,RequestModel<Student>,BaseViewModel<Student>>
    {
        public StudentService(BaseRepository<Student> repository) : base(repository)
        {
        }
    }
}
