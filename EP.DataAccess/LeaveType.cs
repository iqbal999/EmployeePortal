using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DataAccess
{
    public class LeaveType : BaseProperty
    {
        [StringLength(100)]
        public string LeaveTypeName { get; set; } = string.Empty;
    }
}
