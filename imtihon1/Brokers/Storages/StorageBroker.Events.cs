using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data.SqlClient;
using System.Data;
using imtihon1.Brokers.Exceptions;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertEventAsync(Event @event)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertCompany;
            command.Parameters.Add(new SqlParameter("@id_company_to_order", @event.Id_Company_To_Order));
            command.Parameters.Add(new SqlParameter("@id_room", @event.Id_Room));
            command.Parameters.Add(new SqlParameter("@status", @event.Status));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }
        public async Task<List<Event>> SelectAllEventsAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllEvent;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReaderEvent(dataReader);
        }
        public async Task<Event> SelectEventByIdAsync(int id_event)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectEventById;
            command.Parameters.Add(new SqlParameter("@id_event", id_event));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var orders = await ParseDataFromDataReaderEvent(dataReader);

            return orders.FirstOrDefault();
        }

        private async Task<List<Event>> ParseDataFromDataReaderEvent(SqlDataReader dataReader)
        {
            List<Event> events = new List<Event>();

            try
            {
                while (await dataReader.ReadAsync())
                {
                    var @event = new Event(
                        id_Event: dataReader.GetInt32(0),
                        id_Company_To_Order: dataReader.GetInt32(1),
                        id_Room: dataReader.GetInt32(2),
                        status: (StatusOfEvent)dataReader.GetInt32(3));

                    events.Add(@event);
                }
            }
            catch (NotFoundEventException)
            {
                throw;
            }

            return events;
        }
    }
}
