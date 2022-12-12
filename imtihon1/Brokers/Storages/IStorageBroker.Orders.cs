using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertOrderAsync(Order order);
        Task<List<Order>> SelectAllOrdersAsync();
        Task<Order> SelectOrderByIdAsync(int id_order);
    }
}
