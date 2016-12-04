using System;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Model;
using Commons.Repository;
using Commons.Service;

namespace ApplicationLibrary.Factory
{
    public abstract class Factory
    {
        public static BaseRepository<T> CreateRepository<T>() where T : Entity
        {
            var repository = new BaseRepository<T>(BusinessDbContext.CreateInstance());
            return repository;
        }
        
        public static void CreateService(out BaseService<Department, DepartmentRequestModel, DepartmetnViewModel> departmentService)
        {
            departmentService = new BaseService<Department, DepartmentRequestModel, DepartmetnViewModel>(CreateRepository<Department>());          
        }

        public static void CreateService(out BaseService<Student, StudentRequestModel, StudentViewModel> studentService)
        {
            studentService =new BaseService<Student, StudentRequestModel, StudentViewModel>(CreateRepository<Student>());
        }
    }
}