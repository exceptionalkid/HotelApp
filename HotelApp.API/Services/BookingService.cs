using System;
using System.Linq;
using HotelApp.API.Model;
using HotelApp.API.Repositories;

namespace HotelApp.API.Services
{
    public interface IBookingService
    {
        public void Book(int HotelId, int RoomId, int CustomerId, DateTime BookingFrom, DateTime BookingTo);
    }

    public class BookingService :IBookingService
    {
        readonly IHotelRepository hotelRepository;
        readonly ICustomerRepository customerRepository;
        readonly IBookingRepository bookingRepository;

        public BookingService(IHotelRepository hotelRepository, ICustomerRepository customerRepository, IBookingRepository bookingRepository)
        {
            this.hotelRepository = hotelRepository;
            this.customerRepository = customerRepository;
            this.bookingRepository = bookingRepository;
        }

        public void Book(int HotelId, int RoomId, int CustomerId, DateTime BookingFrom, DateTime BookingTo)
        {
            Hotel hotel = hotelRepository.GetHotel(HotelId);
            Room room = hotel.Rooms.Where(x => x.Id == RoomId).FirstOrDefault();
            Customer customer = customerRepository.GetCustomer(CustomerId);
            bookingRepository.AddBooking(hotel, room, customer, BookingFrom, BookingTo);
        }
    }
}
