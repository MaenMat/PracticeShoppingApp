using MediatR;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Orders.Commands
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse> 
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
