using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Customers
{
    public class Customer : Entity
    {
        [Required]
        [StringLength(100)]
        [Index("IX_MembershipCardNo")]
        public string MembershipCardNo { get; set; }

        [Required]
        [Index("IX_CustomerName")]
        [StringLength(100)]
        public string Name { get; set; }

        public string HouseNo { get; set; }
        public string RoadNo { get; set; }
        public string Area { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }

        public string Country { get; set; }
        
        [Required]
        [Index("IX_CustomerPhone", IsUnique = true)]
        [StringLength(20)]
        public string Phone { get; set; }

        [Index("IX_CustomerEmail")]
        [StringLength(30)]
        public string Email { get; set; }
        public int Point { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }       
    }
}