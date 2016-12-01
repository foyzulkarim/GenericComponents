using Commons.Model;

namespace ApplicationLibrary.Models.Students
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public Student()
        {
            
        }
    }
}
