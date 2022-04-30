﻿using EP.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Models
{
    public class DepartmentDTO : BaseProperty
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

    }
}
