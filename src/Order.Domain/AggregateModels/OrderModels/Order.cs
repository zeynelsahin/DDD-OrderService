using MediatR;
using Order.Domain.Events;
using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels;

public class Order : BaseEntity, IAggregateRoot
{
    public DateTime OrderDate { get; }
    public string Description { get; }
    public string UserName { get; }
    public string OrderStatus { get; }
    public Address Address { get; }
    public ICollection<OrderItem> OrderItems { get; }

    public Order(ICollection<OrderItem> orderItems, Address address, string orderStatus, string userName, string description, DateTime orderDate)
    {
        if (orderDate < DateTime.Now.Date) throw new Exception("Orderdate must be greater than now");
        OrderItems = orderItems;
        Address = address;
        OrderStatus = orderStatus;
        UserName = userName;
        Description = description;
        OrderDate = orderDate;

        AddDomainEvents(new OrderStartedDomainEvent(userName, this));
    }

    public void AddOrderItem(int quantity, decimal price, int productId)
    {
        OrderItem item = new(quantity, price, productId);
        OrderItems.Add(item);
    }
}