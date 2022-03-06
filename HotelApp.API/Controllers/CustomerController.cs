using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApp.API.Model;
using HotelApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET: api/Customer
        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            return customerRepository.GetAllCustomers();
        }

        // GET: api/Customer/1
        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult Get(int id)
        {
            Customer customer = customerRepository.GetCustomer(id);
            if (customer == null)
                return NotFound();
            else
                return Ok(customer);
        }

        // GET: api/Customer/Search/Thoufeer
        [Route("[action]/{name}")]
        [HttpGet]
        public ActionResult Search(string name)
        {
            var customers = customerRepository.GetAllCustomers(name);
            if (customers == null || customers.Count == 0)
                return NotFound();
            else
                return Ok(customers);
        }


    }
}