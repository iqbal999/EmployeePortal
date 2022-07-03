using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class EmployeeDTO : BaseProperty
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
        [Range(1, int.MaxValue, ErrorMessage = "Please select a designation")]
        public int DesignationId { get; set; }
        public Designation? Designation { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        public DateTime JoiningDate { get; set; }

        public string PresentAddress { get; set; } = string.Empty;

        public string PermanentAddress { get; set; } = string.Empty;

        [StringLength(10)]
        public string ImageFileExtension { get; set; } = string.Empty;
        
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;
    }
}
