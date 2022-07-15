using Order.Application.Repository;

namespace Order.Infastructure.Repository;

public class OrderRepository : IOrderRepository
{
    public Task<int> SaveChangeASync()
    {
        return Task.FromResult(1);
    }
}