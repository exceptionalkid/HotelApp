using System;
using System.Collections.Generic;
using System.Linq;
using HotelApp.API.Model;

namespace HotelApp.API.Repositories
{

    public interface IBookingRepository
    {
        public List<Bookings> GetAllBookings();
        public Bookings GetBooking(int BookingId);
        public void AddBooking(Hotel Hotel, Room Room, Customer Customer, DateTime BookingFrom, DateTime BookingTo);
    }

    public class BookingRepository :IBookingRepository
    {
        List<Bookings> Bookings;

        public BookingRepository()
        {
            //Lets init bookings, But no records for now.
            Bookings = new List<Bookings>();
        }

        public Bookings GetBooking(int BookingId)
        {
            return Bookings.Where(x => x.Id == BookingId).FirstOrDefault();
        }
        public List<Bookings> GetAllBookings()
        {
            return Bookings;
        }
        public void AddBooking(Hotel Hotel, Room Room, Customer Customer, DateTime BookingFrom, DateTime BookingTo)
        {
            int BookingId = Bookings.Any() ? Bookings.Max(x => x.Id) + 1 : 1;
            Room.IsBooked = true;
            Bookings.Add(new Bookings()
            {
                Id = BookingId,
                Customer = Customer,
                Hotel = Hotel,
                Room = Room,
                BookingFromDate = BookingFrom,
                BookingToDate = BookingTo
            });
        }
    }
}
