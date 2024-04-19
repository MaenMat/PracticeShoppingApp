using MediatR;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Products.Queries
{
    public class GetProductDetailsRequest : IRequest<GetProductDetailDto>
    {
        public Guid Id { get; set; }
    }
}

