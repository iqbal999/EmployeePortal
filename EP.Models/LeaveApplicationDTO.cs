using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class LeaveApplicationDTO : BaseProperty
    {
        [StringLength(50)]
        public string ApplicationId { get; set; } = string.Empty;

        [Required]
        public DateTime ApplicationDate { get; set; }

        //[Required]
        public int ApplicantId { get; set; }
        public Employee? Applicant { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }

        [Required]
        public DateTime LeaveFrom { get; set; }

        [Required]
        public DateTime LeaveTo { get; set; }

        [Range(0.5, int.MaxValue, ErrorMessage = "Leave days must be greater than 0.5")]
        public double LeaveDays { get; set; }

        [Required]
        [StringLength(255)]
        public string LeaveReason { get; set; } = string.Empty;

        //[Required]
        public int ManagerId { get; set; }
        public Employee? Manager { get; set; }

        [StringLength(255)]
        public string ManagerName { get; set; } = string.Empty;

        [StringLength(255)]
        public string ManagerComment { get; set; } = string.Empty;

        //[Required]
        [StringLength(50)]
        public string ApplicationStatus { get; set; } = string.Empty;
    }
}
