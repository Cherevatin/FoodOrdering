using System;
using System.Collections.Generic;
using System.Linq;

using FoodOrdering.Domain.Common;
using FoodOrdering.Domain.Exception;

namespace FoodOrdering.Domain.Aggregates.OrderAggregate
{
    public enum StatusCode { Pending, Cancelled, Accepted, Completed }

    public class Order : BaseEntity, IAggregateRoot
    {
        private List<OrderItem> _orderItems = new();

        public Guid CustomerId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime ExecutionDate { get; private set; }

        public StatusCode Status { get; private set; }

        public IReadOnlyList<OrderItem> OrderItems => _orderItems;

        public Order(Guid customerId, DateTime executionDate)
        {
            CustomerId = customerId;
            CreatedAt = DateTime.Now;
            ExecutionDate = executionDate;
            Status = StatusCode.Pending;
        }

        public Order AddItem(Guid dishId, string dishTitle, double dishPrice, int units)
        {
            _orderItems.Add(new OrderItem(dishId, dishTitle, dishPrice, units));
            return this;
        }

        public Order DeleteItem(Guid itemId)
        {
            var item = _orderItems.FirstOrDefault(item => item.Id == itemId);
            if (item == null)
            {
                throw new DomainNotFoundException("Item not found");
            }
            _orderItems.Remove(item);
            return this;
        }

        public Order Cancel()
        {
            Status = StatusCode.Cancelled;
            return this;
        }

        public Order Complete()
        {
            Status = StatusCode.Completed;
            return this;
        }

        public Order Accept()
        {
            Status = StatusCode.Accepted;
            return this;
        }

    }
}
