using System;
using System.Collections.Generic;
using HotelApp.API.Controllers;
using HotelApp.API.Model;
using HotelApp.API.Repositories;
using HotelApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HotelAppAPI.Test
{
    public class BookingControllerTest
    {
        
        BookingController _controller;
        IBookingService _service;

        public BookingControllerTest()
        {
            IHotelRepository hotelRepository = new HotelRepository();
            ICustomerRepository customerRepository = new CustomerRepository();
            IBookingRepository bookingRepository = new BookingRepository();

            _service = new BookingService(hotelRepository, customerRepository, bookingRepository);
            _controller = new BookingController(_service);
        }

        [Fact]
        public void PostTest()
        {
            //Arrange
            var Reg = new Register()
            {
                HotelId = 1,
                CustomerId = 1,
                RoomId = 1,
                FromDate = DateTime.Now,
                ToDate = DateTime.Now.AddDays(5)
            };

            //Act
            var createdResponse = _controller.Post(Reg);

            //Assert
            Assert.IsType<OkObjectResult>(createdResponse);

            var OkRes = createdResponse as OkObjectResult;

            Assert.Equal("Booking Successfull", OkRes.Value.ToString());

        }
    }
}
