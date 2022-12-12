using imtihon1.Models;

namespace imtihon1.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Task<string> InsertCompanyToOrderAsync(CompanyToOrder companyToOrder);
        Task<List<CompanyToOrder>> SelectAllCompanyToOrdersAsync();
        Task<CompanyToOrder> SelectCompanyToOrderByIdAsync(int id_Company_To_Order);
    }
}
