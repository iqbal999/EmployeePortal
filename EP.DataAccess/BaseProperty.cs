using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.DataAccess
{
    public class BaseProperty
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; } = string.Empty;

        [Required]
        public Guid AddBy { get; set; }

        [Required]
        public DateTime AddedDateTime { get; set; }

        public bool IsArchived { get; set; } = false;
    }
}
