using KFHService.Data;
using KFHService.Infrastructure;
using KFHService.Models;
using Microsoft.EntityFrameworkCore;

namespace KFHService.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger , ICustomerRepository customerRepository )
        {
            _logger = logger;
            _customerRepository= customerRepository;
        }


        public async Task<CustomerAccountsModle> GetCustomerByName(string name)
        {
            try
            {

            return await _customerRepository.GetCustomerByName(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;

            }

        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;

            }

        }

        public async Task<string> GetCustomerBalance(int id)
        {
            try
            {
             return  await _customerRepository.GetCustomerBalance(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;

            }

        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            IEnumerable<Customer> customers = new List<Customer>();
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();

            try
            {
                customers =  await _customerRepository.GetAllCustomers();


                foreach (var item in customers)
                {
                    customerViewModels.Add(new CustomerViewModel() { Id = item.Id, Email = item.Email, Name = item.Email, Status = item.Status });

                }
                return customerViewModels;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return customerViewModels;
            }
        }





    }
}
