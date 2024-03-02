﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentralProduct.Application.Products.Dtos
{
    public class GetProduct
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Stock { get; set; }
        public string? Category { get; set; }
    }
}
