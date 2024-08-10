using KFHService.Data;
using KFHService.Models;
using Microsoft.EntityFrameworkCore;

namespace KFHService.Infrastructure
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(ILogger<CustomerRepository> logger , IDbContextFactory<ApplicationDbContext> dbContext)
        { 
            _logger = logger;
        _dbContext = dbContext;
        }

        public async Task<CustomerAccountsModle> GetCustomerByName(string name)
        {
            CustomerAccountsModle customerAccountsModle = new CustomerAccountsModle();

            try
            {

                using (var context = _dbContext.CreateDbContext())
                {
                    var     customer  =  await context.Customers.FirstAsync(x => x.Name.ToLower().Contains(name.ToLower()));

                    if (customer != null)
                    {
                        var accounts = context.Accounts.Where(x => x.Customer.Id == customer.Id).ToList();

                        customerAccountsModle.customer= customer;
                        customerAccountsModle.accounts = accounts;
                    }


                }
                return customerAccountsModle;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return customerAccountsModle;

            }

        }

        public async Task<Customer> GetCustomerById(int id )
        {
            try
            {
                using (var context = _dbContext.CreateDbContext())
                {
                    return await context.Customers.Where(x=>x.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return   null;

            }

        }
        public async Task<string> GetCustomerBalance(int id)
        {
            try
            {
                using (var context = _dbContext.CreateDbContext())
                {
                    return  context.Accounts.Where(x => x.Customer.Id == id).Sum(i => i.Balance).ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;

            }

        }

    public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                using (var context = _dbContext.CreateDbContext())
                {
                    return await context.Customers.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Customer>();
            }
        }







    }
}
