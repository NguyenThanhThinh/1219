using System;
using System.ComponentModel.DataAnnotations;

namespace AppEmployee.Domain.Entities
{
    public class Employee : Entity<int>, IDateTracking
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]

        public string LastName { get; set; }

        public bool Sex { get; set; }

        public DateTime? BirthDay { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; }
    }
}
