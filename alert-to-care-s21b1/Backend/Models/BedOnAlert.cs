﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class BedOnAlert
    {
        public string BedId { get; set; }
        public float Value { get; set; }

        public string Message { get; set; }


    }
}
