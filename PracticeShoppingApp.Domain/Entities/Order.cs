using PracticeShoppingApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }


    }
}
