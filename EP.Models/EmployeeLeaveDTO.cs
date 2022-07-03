using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class EmployeeLeaveDTO : BaseProperty
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select leave type")]
        public int LeaveId { get; set; }
        public LeaveType? LeaveType { get; set; }

        [Range(0.5, int.MaxValue, ErrorMessage = "Please input correct leave days")]
        public double TotalLeaveDays { get; set; }
        public double EnjoyLeaveDays { get; set; }
        public double BalanceLeaveDays { get; set; }
    }
}
