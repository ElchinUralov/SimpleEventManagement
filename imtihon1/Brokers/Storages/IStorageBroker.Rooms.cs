using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertRoomAsync(Room room);
        Task<List<Room>> SelectAllRoomAsync();
        Task<Room> SelectRoomByIdAsync(int id_room);
    }
}
