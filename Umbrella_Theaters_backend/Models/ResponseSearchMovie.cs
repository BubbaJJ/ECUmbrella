using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class ResponseSearchMovie
    {
            public int Page { get; set; }
            public int Total_results { get; set; }
            public int Total_pages { get; set; }
            public List<TmdbMovieResult> Results { get; set; }
    }
}