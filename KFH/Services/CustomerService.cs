
using KFH.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace KFH.Services
{
    public class CustomerService: ICustomerService
    {

        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            try
            {
                List<CustomerModel> customers = new List<CustomerModel>();
                var response = await this._httpClient.GetAsync("api/Customers");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return customers;
                    }



                    return await response.Content.ReadFromJsonAsync<List<CustomerModel>>();

                    //var data = await response.Content.ReadFromJsonAsync<JObject>();
                    return customers;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw ex;
            }

        }

        public async Task<CustomerModel> GetCustomerByName(string name)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel(); 
                var response = await this._httpClient.GetAsync("api/GetCustomerByName?name="+name);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return  customerModel;
                    }



                    return await response.Content.ReadFromJsonAsync<CustomerModel>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw ex;
            }

        }

        public async Task<string> GetCustomerBalance(int id)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                var response = await this._httpClient.GetAsync("api/GetCustomerBalance?id="+id);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return string.Empty;
                    }



                    return await response.Content.ReadFromJsonAsync<String>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw ex;
            }

        }

    }
}
