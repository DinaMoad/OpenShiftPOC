using KFH.Models;

namespace KFH.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomers();
         Task<CustomerModel> GetCustomerByName(string name);
        Task<string> GetCustomerBalance(int id);

    }
}
