using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data.SqlClient;
using System.Data;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertCompanyToOrderAsync(CompanyToOrder companyToOrder)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertCompanyToOrder;
            command.Parameters.Add(new SqlParameter("@id_company", companyToOrder.Id_Company));
            command.Parameters.Add(new SqlParameter("@id_order", companyToOrder.Id_Order));
            command.Parameters.Add(new SqlParameter("@status", companyToOrder.Status));
            command.Parameters.Add(new SqlParameter("@start_time", companyToOrder.Start_Time));
            command.Parameters.Add(new SqlParameter("@end_time", companyToOrder.End_Time));
            command.Parameters.Add(new SqlParameter("@number_of_spaces", companyToOrder.Number_Of_Spaces));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }
        public async Task<List<CompanyToOrder>> SelectAllCompanyToOrdersAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllCompanyToOrder;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReaderCompanyToOrder(dataReader);
        }
        public async Task<CompanyToOrder> SelectCompanyToOrderByIdAsync(int id_Company_To_Order)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectCompanyToOrderById;
            command.Parameters.Add(new SqlParameter("@id_company_to_order", id_Company_To_Order));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var orders = await ParseDataFromDataReaderCompanyToOrder(dataReader);

            return orders.FirstOrDefault();
        }

        private async Task<List<CompanyToOrder>> ParseDataFromDataReaderCompanyToOrder(SqlDataReader dataReader)
        {
            List<CompanyToOrder> companyToOrders = new List<CompanyToOrder>();

            while (await dataReader.ReadAsync())
            {
                var companyToOrder = new CompanyToOrder(
                    id_Company_Order: dataReader.GetInt32(0),
                    id_Company: dataReader.GetInt32(1),
                    id_Order: dataReader.GetInt32(2),
                    status: (StatusOfOrder)dataReader.GetInt32(3),
                    start_Time: dataReader.GetDateTime(4),
                    end_Time: dataReader.GetDateTime(5),
                    number_Of_Spaces: dataReader.GetInt32(6));

                companyToOrders.Add(companyToOrder);
            }

            return companyToOrders;
        }
    }
}
