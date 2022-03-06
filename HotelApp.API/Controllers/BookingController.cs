using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApp.API.Model;
using HotelApp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // POST: api/Booking
        [HttpPost]
        public ActionResult Post([FromBody] Register register)
        {
            try
            {
                bookingService.Book(register.HotelId, register.RoomId, register.CustomerId, register.FromDate, register.ToDate);
                return Ok("Booking Successfull");
            }
            catch 
            {
                return BadRequest();
            }
        }

    }
}
