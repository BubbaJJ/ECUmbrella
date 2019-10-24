using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Umbrella_Theaters_backend.Models
{
    public class Movie
    {
        public string MovieName { get; set; }
        public int Id { get; set; }
        public int Runtime { get; set; }
        public bool AdultMovie { get; set; }
        public List<object> GenreName { get; set; }
        public string PosterPath { get; set; }
        public double VoteAverage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Overview { get; set; }
        public DateTime StartDate { get; set; }
        public string BackdropPath { get; set; }
        public string TrailerPath { get; set; }
    }
}