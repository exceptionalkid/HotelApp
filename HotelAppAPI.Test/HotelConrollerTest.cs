using System;
using System.Collections.Generic;
using HotelApp.API.Controllers;
using HotelApp.API.Model;
using HotelApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HotelAppAPI.Test
{
    public class HotelConrollerTest
    {
        HotelController hotelController;
        IHotelRepository hotelRepository;

        public HotelConrollerTest()
        {
            hotelRepository = new HotelRepository();
            hotelController = new HotelController(hotelRepository);
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = hotelController.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Hotel>>(list.Value);



            var listHotels = list.Value as List<Hotel>;

            Assert.Equal(2, listHotels.Count);
        }
    }
}
