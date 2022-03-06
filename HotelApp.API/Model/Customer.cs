using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.API.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{ FirstName} {LastName}"; } }
        public DateTime DateOfJoin { get; set; }

    }
}
