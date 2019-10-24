using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class UserBookings
    {
        public int BookingId { get; set; }
        public int SeatId { get; set; }
        public bool Paid { get; set; }
        public int State { get; set; }
        public int ScreeningId { get; set; }
        public string MovieName { get; set; }
        public string PosterPath { get; set; }
    }
}