using AutoMapper;
using CsharpAssginment.Data.Interfaces;
using CsharpAssginment.Data.Models;
using CsharpAssignment.Business.Interfaces;
using CsharpAssignment.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAssignment.Business.Managers
{
    public class CustomerManager : ICustomerManager, ICityManager
    {
        private ICustomerRepository _customerRepository;

        private ICityRepository _cityRepository;

        public CustomerManager(ICustomerRepository customerRepository, ICityRepository cityRepository)
        {
            _customerRepository = customerRepository;
            _cityRepository = cityRepository;
        }

        public List<CustomerViewModel> GetAllCustomers()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers();
            List<CustomerViewModel> customerViews = new List<CustomerViewModel>();
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Customer, CustomerViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();
            //List<CustomerViewModel> customerViewModels = mapper.Map<List<Customer>, List<CustomerViewModel>>(customers);
            foreach (Customer c in customers)
            {
                CustomerViewModel customer = new CustomerViewModel();
                customer.id = c.id;
                customer.Name = c.Name;
                customer.Address_1 = c.Address_1;
                customer.Address_2 = c.Address_2;
                customer.City = c.City1.Name;
                customer.Country = c.Country;
                customer.Post_Code = c.Post_Code;
                customer.Email = c.Email;
                customer.Mobile = c.Mobile;
                customer.Birth_Date = c.Birth_Date;
                customer.Active = c.Active;
                customer.Create_Date = c.Create_Date;
                customer.Update_Date = c.Update_Date;
                customerViews.Add(customer);
            }
            return customerViews;
        }

        public CustomerViewModel GetCustomer(int id)
        {
            Customer c = _customerRepository.GetCustomer(id);
            CustomerViewModel customer = new CustomerViewModel();
            customer.id = c.id;
            customer.Name = c.Name;
            customer.Address_1 = c.Address_1;
            customer.Address_2 = c.Address_2;
            customer.City = c.City1.Name;
            customer.Country = c.Country;
            customer.Post_Code = c.Post_Code;
            customer.Email = c.Email;
            customer.Mobile = c.Mobile;
            customer.Birth_Date = c.Birth_Date;
            customer.Active = c.Active;
            customer.Create_Date = c.Create_Date;
            customer.Update_Date = c.Update_Date;
            return customer;
        }

        public bool InsertCustomer(CustomerViewModel customerViewModel)
        {
            bool status = false;
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<CustomerViewModel, CustomerViewModel>();
            //});

            //IMapper mapper = config.CreateMapper();
            //Customer customer = mapper.Map<CustomerViewModel, Customer>(customerViewModel);

            Customer cust = new Customer();
            cust.Name = customerViewModel.Name;
            cust.Address_1 = customerViewModel.Address_1;
            cust.Address_2 = customerViewModel.Address_2;
            cust.City = Convert.ToInt32(customerViewModel.City);
            cust.Country = customerViewModel.Country;
            cust.Post_Code = customerViewModel.Post_Code;
            cust.Email = customerViewModel.Email;
            cust.Mobile = customerViewModel.Mobile;
            cust.Birth_Date = customerViewModel.Birth_Date ?? System.DateTime.Now;
            cust.Active = customerViewModel.Active;
            cust.Create_Date = System.DateTime.Now;
            cust.Update_Date = null;

            status = _customerRepository.InsertCustomer(cust);
            return status;
        }

        public bool UpdateCustomer(CustomerViewModel customerViewModel)
        {
            bool status = false;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerViewModel, CustomerViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            Customer customer = mapper.Map<CustomerViewModel, Customer>(customerViewModel);

            status = _customerRepository.UpdateCustomer(customer);
            return status;
        }

        public bool DeleteCustomer(int id)
        {
            bool status = false;
            status = _customerRepository.DeleteCustomer(id);
            return status;
        }

        public List<CityViewModel> GetAllCities()
        {
            List<City> cities = _cityRepository.GetAllCities();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<City, CityViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            List<CityViewModel> cityViewModels = mapper.Map<List<City>, List<CityViewModel>>(cities);
            return cityViewModels;
        }
    }
}
