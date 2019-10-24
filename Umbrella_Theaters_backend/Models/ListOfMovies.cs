using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class ListOfMovies
    {
        public List<Movie> UpcomingMovies { get; set; }
        public List<Movie> CurrentMovies { get; set; }

    }
}