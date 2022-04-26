using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Application.Dtos.Order.GotGroupByCustomer
{
    public class GroupByCustomerDto
    {
        public Dictionary<Guid, OrderDto> Groups { get; set; }
    }
}
