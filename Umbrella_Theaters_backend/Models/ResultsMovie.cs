using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella_Theaters_backend.Models
{
    public class ResultsMovie
    {
        public double Popularity { get; set; }
        public int Vote_count { get; set; }
        public bool Trailer { get; set; }
        public string PosterPath { get; set; }
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public string Original_language { get; set; }
        public string MovieName { get; set; }
        public List<object> Genre_ids { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
    }
}