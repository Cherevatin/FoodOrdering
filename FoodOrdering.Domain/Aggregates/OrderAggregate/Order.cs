using FoodOrdering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Domain.Aggregates.OrderAggregate
{
    public enum StatusCode { Pending, Cancelled, Accepted, Completed }

    public class Order : BaseEntity
    {
        public Guid CustomerId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime ExecutionDate { get; private set; }

        public StatusCode Status { get; private set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order(Guid customerId, DateTime executionDate)
        {
            CustomerId = customerId;
            CreatedAt = DateTime.Now;
            ExecutionDate = executionDate;
            Status = StatusCode.Pending;
        }

        public void AddItem(Guid dishId, string dishTitle, double dishPrice, int units)
        {
            OrderItems.Add(new OrderItem(dishId, dishTitle, dishPrice, units));
        }

        public void Cancel()
        {
            Status = StatusCode.Cancelled;
        }

        public void Complete()
        {
            Status = StatusCode.Completed;
        }

        public void Accept()
        {
            Status = StatusCode.Accepted;
        }

    }
}
