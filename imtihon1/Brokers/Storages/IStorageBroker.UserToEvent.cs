using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertUserToEventAsync(User_To_Event user_To_Event);
        Task<List<User_To_Event>> SelectAllUserToEventAsync();
        Task<User_To_Event> SelectUserToEventByIdAsync(int id_User_To_Event);
    }
}
