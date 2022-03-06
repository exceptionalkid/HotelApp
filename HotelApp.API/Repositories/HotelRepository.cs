using System;
using System.Collections.Generic;
using System.Linq;
using HotelApp.API.Model;

namespace HotelApp.API.Repositories
{
    public interface IHotelRepository
    {
        public List<Hotel> GetAllHotels(string Name = "");
        public Hotel GetHotel(int HotelId);

    }
    public class HotelRepository : IHotelRepository
    {
        List<Hotel> Hotels;

        public HotelRepository()
        {
            // I'm using temporary collecions instead of database values to reduce complexity
            // In realtime projects i prefer Entity framework DbContext for database operations using DI through constructor.
            // Lets Init a mock hotel repo for now.
            
            Hotels = new List<Hotel>()
            {
                new Hotel()
                {
                    Id = 1,
                    Name = "Burj Khalifa",
                    Description = "Down Town, Dubai",
                    Rating = 10,
                    Price = 1500,
                    IsBreakfastAvailable = true,
                    IsParkingAvailable = true,
                    IsSpaAvailable = true,
                    IsWifiAvailable = true,
                    Rooms = new List<Room>()
                    {
                        new Room(){ Id = 1, Name = "Room 1", RoomNo = 101, IsBooked = false },
                        new Room(){ Id = 2, Name = "Room 2", RoomNo = 102, IsBooked = false },
                    }
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Burj Al Arab",
                    Description = "Jumeirah, Dubai",
                    Rating = 10,
                    Price = 1800,
                    IsBreakfastAvailable = true,
                    IsParkingAvailable = true,
                    IsSpaAvailable = true,
                    IsWifiAvailable = true,
                    Rooms = new List<Room>()
                    {
                        new Room(){ Id = 1, Name = "Room 1", RoomNo = 101, IsBooked = false },
                        new Room(){ Id = 2, Name = "Room 2", RoomNo = 102, IsBooked = false },
                    }
                }
            };
        }


        public Hotel GetHotel(int HotelId)
        {
            return Hotels.Where(x => x.Id == HotelId).FirstOrDefault();
        }
        public List<Hotel> GetAllHotels(string Name = "")
        {
            return string.IsNullOrEmpty(Name) ? Hotels : Hotels.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();
        }

    }
}
