using System;
using ApplicationLibrary.Models.Departments;
using Commons.ViewModel;

namespace ApplicationLibrary.Models.Students
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsViewable: Attribute
    {
        public bool Value { get; set; }
    }


    public class StudentViewModel : BaseViewModel<Student>
    {
        public StudentViewModel(Student x) : base(x)
        {
            Name = x.Name;
            Phone = x.Phone;
            if (x.Department!=null)
            {
                Department = new DepartmetnViewModel(x.Department);
                DepartmentName = this.Department.Name;
            }            
        }

        public string Phone { get; set; }

        [IsViewable(Value = true)]
        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public DepartmetnViewModel Department { get; set; }
    }
}