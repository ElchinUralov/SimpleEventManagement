using imtihon1.Brokers.Storages.Helper;
using imtihon1.Models;
using System.Data.SqlClient;
using System.Data;
using imtihon1.Brokers.Exceptions;

namespace imtihon1.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public async Task<string> InsertCompanyAsync(Company company)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_InsertCompany;
            command.Parameters.Add(new SqlParameter("@name", company.Name));

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();

            return "Success";
        }
        public async Task<List<Company>> SelectAllCompanyAsync()
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectAllCompanies;

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            return await ParseDataFromDataReaderCompany(dataReader);
        }
        public async Task<Company> SelectCompanyByIdAsync(int id_company)
        {
            using var connection = GetConnection();
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StorageBrokerHelper.SP_SelectCompanyById;
            command.Parameters.Add(new SqlParameter("@id_company", id_company));

            await connection.OpenAsync();
            using var dataReader = await command.ExecuteReaderAsync();

            var companies = await ParseDataFromDataReaderCompany(dataReader);

            return companies.FirstOrDefault();
        }


        private async Task<List<Company>> ParseDataFromDataReaderCompany(SqlDataReader dataReader)
        {
            List<Company> companies = new List<Company>();

            try
            {
                while (await dataReader.ReadAsync())
                {
                    var company = new Company(
                        id_Company: dataReader.GetInt32(0),
                        name: dataReader.GetString(1));

                    companies.Add(company);
                }
            }
            catch (NotFoundCompanyExceptions ex)
            {

                throw;
            }

            return companies;
        }
    }
}
