using ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerServiceClient
{
    public interface ICustomerClient
    {
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto> GetCustomer(int customerID);
        Task<CustomerDto> AddCustomer(CustomerDto customer);
        Task<CustomerDto> UpdateCustomer(string customerId, CustomerDto customer);
        Task<string> DeleteCustomer(int customerID);
    }
}
