using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomNo { get; set; }
        public bool IsBooked { get; set; }
    }
}
