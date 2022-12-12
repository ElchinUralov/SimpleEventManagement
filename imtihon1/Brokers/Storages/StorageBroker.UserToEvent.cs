using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data.SqlClient;
using System.Data;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertUserToEventAsync(User_To_Event user_To_Event)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertUserToEvent;
            command.Parameters.Add(new SqlParameter("@id_user", user_To_Event.Id_User));
            command.Parameters.Add(new SqlParameter("@id_event", user_To_Event.Id_Event));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }
        public async Task<List<User_To_Event>> SelectAllUserToEventAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllUserToEvent;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReaderUserToEvent(dataReader);
        }
        public async Task<User_To_Event> SelectUserToEventByIdAsync(int id_User_To_Event)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectUserToEventById;
            command.Parameters.Add(new SqlParameter("@id_user_to_event", id_User_To_Event));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var userToEvents = await ParseDataFromDataReaderUserToEvent(dataReader);

            return userToEvents.FirstOrDefault();
        }

        private async Task<List<User_To_Event>> ParseDataFromDataReaderUserToEvent(SqlDataReader dataReader)
        {
            List<User_To_Event> user_To_Events = new List<User_To_Event>();

            while (await dataReader.ReadAsync())
            {
                var user_To_Event = new User_To_Event(
                    id_User_Event: dataReader.GetInt32(0),
                    id_User: dataReader.GetInt32(1),
                    id_Event: dataReader.GetInt32(2));

                user_To_Events.Add(user_To_Event);
            }

            return user_To_Events;
        }
    }
}