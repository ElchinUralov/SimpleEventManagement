using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertUserAsync(User user);
        Task<List<User>> SelectAllUsersAsync();
        Task<User> SelectUserByIdAsync(int userId);
    }
}
