using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PracticeShoppingApp.Application.Events
{
    public class OrderPlacedEvent : INotification 
    {
        public Guid ProdId { get; set; }
        public int Qty { get; set; }
    }
}
