using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Orders.Commands
{
    public class DeleteOrderRequest : IRequest
    {
        public Guid OrderId { get; set;}
    }
}
