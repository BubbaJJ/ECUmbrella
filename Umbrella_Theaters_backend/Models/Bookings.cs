//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Umbrella_Theaters_backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public int ScreeningId { get; set; }
        public int SeatId { get; set; }
        public Nullable<int> BookedById { get; set; }
        public string Email { get; set; }
        public bool Paid { get; set; }
    
        public virtual Screenings Screenings { get; set; }
        public virtual Seats Seats { get; set; }
        public virtual Users Users { get; set; }
    }
}
