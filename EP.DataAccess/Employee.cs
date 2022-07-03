using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DataAccess
{
    public class Employee : BaseProperty
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(100)]
        public string Phone2 { get; set; } = string.Empty;

        [Required]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designation? Designation { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Employee? Manager { get; set; }

        public DateTime JoiningDate { get; set; }

        public string PresentAddress { get; set; } = string.Empty;

        public string PermanentAddress { get; set; } = string.Empty;

        [StringLength(10)]
        public string ImageFileExtension { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

    }
}
