using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class EmployeeLeaveDTO
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int LeaveId { get; set; }
        public LeaveType? LeaveType { get; set; }

        public double TotalLeaveDays { get; set; }
        public double EnjoyLeaveDays { get; set; }
        public double BalanceLeaveDays { get; set; }
    }
}
