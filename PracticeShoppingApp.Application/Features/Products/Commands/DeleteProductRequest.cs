using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Products.Commands
{
    public class DeleteProductRequest : IRequest
    {
        public Guid ProdId { get; set; }
    }
}
