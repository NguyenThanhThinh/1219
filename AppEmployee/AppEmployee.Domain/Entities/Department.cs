using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AppEmployee.Domain.Entities
{
    public class Department : Entity<int>, IDateTracking
    {
        [Required]

        public string Name { get; set; }


        public int TotalEmployee { get; set; } = 0;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public ICollection<Employee> Employeee { get; set; } = new HashSet<Employee>();
    }
}
