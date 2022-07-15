using Order.Application.Repository;

namespace Order.Infastructure.Repository;

public class BuyerRepository : IOrderRepository
{
    public Task<int> SaveChangeASync()
    {
        return Task.FromResult(1);
    }
}