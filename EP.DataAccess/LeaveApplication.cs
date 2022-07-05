using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DataAccess
{
    public class LeaveApplication : BaseProperty
    {
        [Required]
        [StringLength(50)]
        public string ApplicationId { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public Employee? Applicant { get; set; }

        public int LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType? LeaveType { get; set; }

        public DateTime LeaveFrom { get; set; }

        public DateTime LeaveTo { get; set; }
        
        public double LeaveDays { get; set; }

        [StringLength(255)]
        public string LeaveReason { get; set; } = string.Empty;

        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public Employee? Manager { get; set; }

        [StringLength(255)]
        public string ManagerName { get; set; } = string.Empty;

        [StringLength(255)]
        public string ManagerComment { get; set; } = string.Empty;

        [StringLength(50)]
        public string ApplicationStatus { get; set; } = string.Empty;
    }
}
