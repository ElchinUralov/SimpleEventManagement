using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertCompanyAsync(Company company);
        Task<List<Company>> SelectAllCompanyAsync();
        Task<Company> SelectCompanyByIdAsync(int id_company);
    }
}
