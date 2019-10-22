using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Umbrella_Theaters_backend.Models
{
    public class ResponseMovie
    {
        public string original_title { get; set; }
        public int Id { get; set; }
        public int Runtime { get; set; }
        public bool AdultMovie { get; set; }
        public string Poster_Path { get; set; }
        public string Overview { get; set; }
        public double vote_average { get; set; }
        public List<object> Genres { get; set; }
        public DateTime release_date { get; set; }
        public string backdrop_path { get; set; }
    }
}