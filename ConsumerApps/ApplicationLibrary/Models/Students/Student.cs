using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationLibrary.Models.Departments;
using Commons.Model;

namespace ApplicationLibrary.Models.Students
{
    public class Student : Entity
    {
        [Required]
        [Index]
        [StringLength(128)]
        public string Name { get; set; }
        public string Phone { get; set; }

        [Required]
        public string DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }        
    }
}
