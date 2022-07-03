using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class LeaveTypeDTO : BaseProperty
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Leave Type Name")]
        public string LeaveTypeName { get; set; } = string.Empty;

    }
}
