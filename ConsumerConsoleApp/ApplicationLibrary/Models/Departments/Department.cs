using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationLibrary.Models.Students;
using Commons.Model;

namespace ApplicationLibrary.Models.Departments
{
    public class Department : Entity
    {
        [Required]
        [Index]
        [StringLength(128)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
