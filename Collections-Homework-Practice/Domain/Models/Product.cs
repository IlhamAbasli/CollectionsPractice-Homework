﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
