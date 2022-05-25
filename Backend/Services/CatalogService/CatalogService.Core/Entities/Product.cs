﻿using BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Entities
{
    public class Product : AggregateRoot
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
