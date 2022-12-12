using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data.SqlClient;
using System.Data;
using imtihon1.Brokers.Exceptions;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertRoomAsync(Room room)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertRoom;
            command.Parameters.Add(new SqlParameter("@status", room.Status));
            command.Parameters.Add(new SqlParameter("@number_of_places", room.Number_Of_Places));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }
        public async Task<List<Room>> SelectAllRoomAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllRooms;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReaderRoom(dataReader);
        }
        public async Task<Room> SelectRoomByIdAsync(int id_room)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectRoomById;
            command.Parameters.Add(new SqlParameter("@id_room", id_room));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var rooms = await ParseDataFromDataReaderRoom(dataReader);

            return rooms.FirstOrDefault();
        }

        private async Task<List<Room>> ParseDataFromDataReaderRoom(SqlDataReader dataReader)
        {
            List<Room> rooms = new List<Room>();

            try
            {
                while (await dataReader.ReadAsync())
                {
                    var room = new Room(
                        id_Room: dataReader.GetInt32(0),
                        number_Of_Places: dataReader.GetInt32(1),
                        status: (StatusOfRoom)dataReader.GetInt32(2));

                    rooms.Add(room);
                }
            }
            catch (NotFoundRoomExceptions)
            {

                throw;
            }

            return rooms;
        }
    }
}
