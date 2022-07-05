using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class StatusDTO : BaseProperty
    {
        [StringLength(50)]
        public string StatusName { get; set; } = string.Empty;
    }
}
