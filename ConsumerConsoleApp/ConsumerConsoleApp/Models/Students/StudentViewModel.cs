using Commons.ViewModel;

namespace ConsumerConsoleApp.Models.Students
{
    public class StudentViewModel : BaseViewModel<Student>
    {
        public StudentViewModel(Student x) : base(x)
        {
            Name = x.Name;
            Phone = x.Phone;
        }

        public string Phone { get; set; }

        public string Name { get; set; }
    }
}