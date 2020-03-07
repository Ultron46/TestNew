using CsharpAssginment.Data.Interfaces;
using CsharpAssginment.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssginment.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                List<Customer> customers = db.Customers.ToList() ?? new List<Customer>();
                return customers;
            }
        }

        public Customer GetCustomer(int id)
        {
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                Customer customer = db.Customers.Find(id) ?? new Customer();
                return customer;
            }
        }

        public bool InsertCustomer(Customer customer)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                db.Customers.Add(customer);
                if(db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                db.Entry(customer).State = EntityState.Modified;
                if(db.SaveChanges() > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool DeleteCustomer(int id)
        {
            bool status = false;
            using (CustomerDetailsEntities db = new CustomerDetailsEntities())
            {
                Customer customer = db.Customers.Find(id) ?? new Customer();
                if(customer != null)
                {
                    db.Customers.Remove(customer);
                    if(db.SaveChanges() > 0)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }
    }
}
