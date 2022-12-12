using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data.SqlClient;
using System.Data;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertOrderAsync(Order order)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertOrder;
            command.Parameters.Add(new SqlParameter("@topic", order.Topic));
            command.Parameters.Add(new SqlParameter("@room", order.Room));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }
        public async Task<List<Order>> SelectAllOrdersAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllOrders;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReaderOrder(dataReader);
        }
        public async Task<Order> SelectOrderByIdAsync(int id_order)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectOrderById;
            command.Parameters.Add(new SqlParameter("@id_order", id_order));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var orders = await ParseDataFromDataReaderOrder(dataReader);

            return orders.FirstOrDefault();
        }

        private async Task<List<Order>> ParseDataFromDataReaderOrder(SqlDataReader dataReader)
        {
            List<Order> orders = new List<Order>();

            while (await dataReader.ReadAsync())
            {
                var order = new Order(
                    id_Order: dataReader.GetInt32(0),
                    topic: dataReader.GetString(1),
                    room: dataReader.GetInt32(2));

                orders.Add(order);
            }

            return orders;
        }
    }
}
