using KFHService.Models;

namespace KFHService.Infrastructure
{
    public interface ICustomerRepository
    {
        Task<CustomerAccountsModle> GetCustomerByName(string name);
       Task<string> GetCustomerBalance(int id);

        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
