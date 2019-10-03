using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    // Klassen används vid skapandet av bokning.
    public class Booking
    {
        public int screeningId { get; set; }
        public int seatId { get; set; }
        public int bookedById { get; set; }
        public string email { get; set; }
        public bool paid { get; set; }
        public int state { get; set; }
    }
}