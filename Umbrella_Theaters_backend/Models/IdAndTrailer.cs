using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class IdAndTrailer
    {
        public int Id { get; set; }
        public List<Trailers> Results { get; set; }
    }
}