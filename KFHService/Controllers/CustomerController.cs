using KFHService.Models;
using KFHService.Services;
using Microsoft.AspNetCore.Mvc;

namespace KFHService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        #region Constructor
        readonly ICustomerService _customerService;
        #endregion

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("/api/Customers/")]
        public async Task<ActionResult<IEnumerable<Customer>>> DispayCustomers()
        {
            try
            {
                var Customers = await _customerService.GetAllCustomers();

                if (Customers == null)
                {
                    return NotFound();
                }

                else
                {

                    return Ok(Customers.ToArray());

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }
        
        [HttpGet]

        [Route("/api/GetCustomerByName")]
        public async Task<ActionResult< CustomerAccountsModle>> GetCustomerByName(string name)
        {
            try
            {
                var Customers = await _customerService.GetCustomerByName(name);

                if (Customers == null)
                {
                    return NotFound();
                }

                else
                {

                    return Ok(Customers);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");

            }
        }


        [HttpGet]

        [Route("/api/GetCustomerBalance")]
        public async Task<string> GetCustomerBalance(int id)
        {
            try
            {
               return await _customerService.GetCustomerBalance(id);

              
            }
            catch (Exception)
            {
                return string.Empty;

            }
        }

        /*

        [HttpPost]
        public IEnumerable<Customer> GetBalanceByCustomerName()
        {
            return Enumerable.Empty<Customer>();
        }
        */
    }

}