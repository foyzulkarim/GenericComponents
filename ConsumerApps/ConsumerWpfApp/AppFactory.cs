using ApplicationLibrary;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Model;
using Commons.Repository;
using Commons.Service;

namespace ConsumerWpfApp
{
    public static class AppFactory
    {
        static AppFactory()
        {
            StudentService = new BaseService<Student, StudentRequestModel, StudentViewModel>(CreateRepository<Student>());
            DepartmentService = new BaseService<Department, DepartmentRequestModel, DepartmetnViewModel>(CreateRepository<Department>());
        }

        public static BaseRepository<T> CreateRepository<T>() where T : Entity
        {
            return new BaseRepository<T>(BusinessDbContext.CreateInstance());
        }

        public static BaseService<Student, StudentRequestModel, StudentViewModel> StudentService { get; set; }
        public static BaseService<Department, DepartmentRequestModel, DepartmetnViewModel> DepartmentService { get; set; }
    }
}