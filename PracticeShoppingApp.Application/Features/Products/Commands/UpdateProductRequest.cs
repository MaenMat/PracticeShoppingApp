using MediatR;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Products.Commands
{
    public class UpdateProductRequest : IRequest
    {
        public Guid ProdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
