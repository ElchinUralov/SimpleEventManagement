using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertEventAsync(Event @event);
        Task<List<Event>> SelectAllEventsAsync();
        Task<Event> SelectEventByIdAsync(int id_event);
    }
}
