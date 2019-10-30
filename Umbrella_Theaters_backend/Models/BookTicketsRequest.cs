using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
	public class BookTicketsRequest
	{
        public int BookedById { get; set; }
        public string Email { get; set; }
        public bool Paid { get; set; }
        public int ScreeningId { get; set; }
        public int SeatId { get; set; }
        public int NumberOfTickets { get; set; }

    }
}