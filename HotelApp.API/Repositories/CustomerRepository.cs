using System;
using System.Collections.Generic;
using System.Linq;
using HotelApp.API.Model;

namespace HotelApp.API.Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers(string Name = "");
        public Customer GetCustomer(int CustomerId);
    }

    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> Customers;

        public CustomerRepository()
        {
            //Lets Init some dummy customers
            Customers = new List<Customer>()
            {
                new Customer()
                {
                     Id = 1,
                     FirstName = "Thoufeer",
                     LastName = "Mmv",
                     DateOfJoin = DateTime.Now.AddDays(-5)
                },
                new Customer()
                {
                     Id = 2,
                     FirstName = "James",
                     LastName = "Bond",
                     DateOfJoin = DateTime.Now.AddDays(-7)
                }
            };
        }

        public Customer GetCustomer(int CustomerId)
        {
            return Customers.Where(x => x.Id == CustomerId).FirstOrDefault();
        }
        public List<Customer> GetAllCustomers(string Name = "")
        {
            return string.IsNullOrEmpty(Name) ? Customers : Customers.Where(x => x.FullName.Contains(Name)).ToList();
        }
    }
}
