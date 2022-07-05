using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DataAccess
{
    public class Status : BaseProperty
    {
        [StringLength(50)]
        public string StatusName { get; set; } = string.Empty;
    }
}
