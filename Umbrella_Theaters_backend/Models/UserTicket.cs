using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
	public class UserTicket
	{
        public int ScreeningId { get; set; }
        public string PosterPath { get; set; }
        public string MovieName { get; set; }
        public DateTime ViewingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int AuditoriumId { get; set; }
        public int NumberOfTickets { get; set; }

    }
}