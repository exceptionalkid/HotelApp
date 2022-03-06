using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.Model
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public Customer Customer { get; set; }
        public DateTime BookingFromDate { get; set; }
        public DateTime BookingToDate { get; set; }
    }
}
