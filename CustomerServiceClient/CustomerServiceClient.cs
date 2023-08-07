using Microsoft.Extensions.Configuration;
using ModelDto;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CustomerServiceClient
{
    public class CustomerClient :ICustomerClient
    {
        protected IConfiguration _configuration { get; set; }
        protected HttpClient _httpClient { get; set; }
        public CustomerClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<CustomerDto> AddCustomer(CustomerDto customer)
        {
            try
            {
                string key = "ServiceClients:CustomerService:API:AddCustomer:Url";
                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
                var url = _configuration[key];
                HttpResponseMessage response = await _httpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<CustomerDto>(await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteCustomer(int customerId)
        {
            try
            {
                string key = "ServiceClients:CustomerService:API:RemoveCustomersById:Url";
                var url = string.Format(_configuration[key], customerId);
                HttpResponseMessage response = await _httpClient.DeleteAsync(url).ConfigureAwait(continueOnCapturedContext: false);
                return await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerDto> GetCustomer(int customerId)
        {
            try
            {
                string key = "ServiceClients:CustomerService:API:GetCustomersById:Url";
                var url = string.Format(_configuration[key], customerId);
                HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(continueOnCapturedContext: false);
                return JsonConvert.DeserializeObject<CustomerDto>(await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            try
            {
                string key = "ServiceClients:CustomerService:API:GetCustomers:Url";
                var url = _configuration[key];
                HttpResponseMessage response = await _httpClient.GetAsync(url).ConfigureAwait(continueOnCapturedContext: false);
                return JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<CustomerDto> UpdateCustomer(string customerId, CustomerDto customer)
        {
            try
            {
                string key = "ServiceClients:CustomerService:API:UpdateCustomer:Url";
                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
                var url = string.Format(_configuration[key], customerId);
                HttpResponseMessage response = await _httpClient.PostAsync(url, content).ConfigureAwait(continueOnCapturedContext: false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<CustomerDto>(await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}