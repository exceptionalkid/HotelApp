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
    public class HotelController : ControllerBase
    {
        readonly IHotelRepository hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        // GET: api/Hotel
        [HttpGet(Name ="GetHotels")]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            var hotels =  hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        // GET: api/Hotel/1
        [HttpGet("{id}", Name = "GetHotel")]
        public ActionResult Get(int id)
        {
            Hotel hotel = hotelRepository.GetHotel(id);
            if (hotel == null)
                return NotFound();
            else
                return Ok(hotel);
        }

        // GET: api/Hotel/Search
        [Route("[action]/{name}")]
        [HttpGet]
        public ActionResult Search(string name)
        {
            var hotels = hotelRepository.GetAllHotels(name);
            if (hotels == null || hotels.Count == 0)
                return NotFound();
            else
                return Ok(hotels);
        }

        
    }
}
