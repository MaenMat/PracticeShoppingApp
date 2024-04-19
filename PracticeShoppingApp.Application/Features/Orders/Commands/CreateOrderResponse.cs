using PracticeShoppingApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Orders.Commands
{
    public class CreateOrderResponse : BaseResponse
    {
        public Guid orderId { get; set; }
    }
}
