using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.Model
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public bool IsSpaAvailable { get; set; }
        public bool IsWifiAvailable { get; set; }
        public bool IsParkingAvailable { get; set; }
        public bool IsBreakfastAvailable { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
