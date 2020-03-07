using CsharpAssginment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}
