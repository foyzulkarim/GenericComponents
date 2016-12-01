using Commons.ViewModel;

namespace ApplicationLibrary.Models.Departments
{
    public class DepartmetnViewModel : BaseViewModel<Department>
    {
        public DepartmetnViewModel(Department x) : base(x)
        {
            Name = x.Name;
        }

        public string Name { get; set; }
    }
}