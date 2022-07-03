using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DataAccess
{
    public class EmployeeLeave
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        public int LeaveId { get; set; }
        [ForeignKey("LeaveId")]
        public LeaveType? LeaveType { get; set; }

        public double TotalLeaveDays { get; set; }
        public double EnjoyLeaveDays { get; set; }
        public double BalanceLeaveDays { get; set; }

    }
}
