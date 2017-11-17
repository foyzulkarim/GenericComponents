using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public abstract class Entity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
		 [Required]
		public string CreatedFrom { get; set; }
    }

}