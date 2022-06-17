﻿using CatalogService.Core.Domain.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Commands.Products
{
    public class PatchProductAvailabilityCommand : IRequest<Product>
    {
        public Guid ProductId { get; set; }
        public bool IsAvailable { get; set; }
    }
}