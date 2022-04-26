using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Order.GotGroupByCustomer
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
            
        public Guid CustomerId { get;  set; }

        public DateTime CreatedAt { get;  set; }

        public DateTime ExecutionDate { get;  set; }

        public String Status { get;  set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
