﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class ScreeningsTable
    {
        public int ScreeningId { get; set; }
        public string MovieName { get; set; }
        public string Auditorium { get; set; }
        public System.DateTime ViewingDate { get; set; }
        public string StartTime { get; set; }
        public int Price { get; set; }
        
        public int NumberOfSeatsRemaining { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}