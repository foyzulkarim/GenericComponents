using Commons.ViewModel;

namespace ApplicationLibrary.Models.Departments
{
    public class DepartmetnViewModel : BaseViewModel<Department>
    {
        public DepartmetnViewModel(Department x) : base(x)
        {
            Name = x.Name;
        }

        [IsViewable(Value = true)]
        public string Name { get; set; }
    }
}