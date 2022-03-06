using System;
using System.Collections.Generic;
using HotelApp.API.Controllers;
using HotelApp.API.Model;
using HotelApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HotelAppAPI.Test
{
    public class CustomerControllerTest
    {
       
        CustomerController _controller;
        ICustomerRepository _repository;

        public CustomerControllerTest()
        {
            _repository = new CustomerRepository();
            _controller = new CustomerController(_repository);
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Customer>>(list.Value);

            var listCustomer = list.Value as List<Customer>;

            Assert.Equal(2, listCustomer.Count);
        }
    }
}
