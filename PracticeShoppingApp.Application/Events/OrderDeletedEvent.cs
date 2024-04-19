using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Events
{
    public class OrderDeletedEvent : INotification
    {
        public Guid ProductId { get; set;}
        public int Quantity { get; set;}
    }
}
