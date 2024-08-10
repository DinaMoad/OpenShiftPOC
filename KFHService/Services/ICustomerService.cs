using KFHService.Models;

namespace KFHService.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerAccountsModle> GetCustomerByName(string name);
         Task<string> GetCustomerBalance(int id);
    }
}
