using imtihon1.Models;
using System.Data.SqlClient;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public SqlConnection GetConnection()
        {
            string connectionString = @"Server=localhost; user id=sa; password=12345; Database=Event_Management";

            return new SqlConnection(connectionString);
        }
    }
}
