using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;

namespace Order.Application.DomainEventHandlers;

public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
{
    public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
    {
        _buyerRepository = buyerRepository;
    }

    private readonly IBuyerRepository _buyerRepository;

    public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
    {
        if (notification.UserName == "")
        {
            var buyer = new Buyer(notification.Order.UserName);
            //_buyerRepository.Add(buyer); create buyer and get new id
            //set orders buyerId
        }

        return Task.CompletedTask;
    }
}