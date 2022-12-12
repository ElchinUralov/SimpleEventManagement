using imtihon1.Brokers.Exceptions;
using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data;
using System.Data.SqlClient;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertUserAsync(User user)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertUser;
            command.Parameters.Add(new SqlParameter("@name", user.Name));
            command.Parameters.Add(new SqlParameter("@role", user.Role));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }

        public async Task<List<User>> SelectAllUsersAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllUsers;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReader(dataReader);
        }

        public async Task<User> SelectUserByIdAsync(int id_user)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectUserById;
            command.Parameters.Add(new SqlParameter("@id_user", id_user));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var users = await ParseDataFromDataReader(dataReader);
            
            return users.FirstOrDefault();
        }


        private async Task<List<User>> ParseDataFromDataReader(SqlDataReader dataReader)
        {
            List<User> users = new List<User>();

            try
            {
                while (await dataReader.ReadAsync())
                {
                    var user = new User(
                        id_User: dataReader.GetInt32(0),
                        name: dataReader.GetString(1),
                        role: (Role_User)dataReader.GetInt32(2));

                    users.Add(user);
                }
            }
            catch (NotFaundUserExceptions ex)
            {

                throw;
            }

            return users;
        }
    }
}
