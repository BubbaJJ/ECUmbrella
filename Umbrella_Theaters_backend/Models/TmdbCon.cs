using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Umbrella_Theaters_backend.Models
{
    public class TmdbCon
    {
        public static string PersonUrl = "https://api.themoviedb.org/3/person/";
        public static string MovieUrl = "https://api.themoviedb.org/3/movie/";
        public static string SearchMovieUrl = "https://api.themoviedb.org/3/search/movie";
        public static string SearchPersonUrl = "https://api.themoviedb.org/3/search/person";
        public static string Poster500Url = "https://image.tmdb.org/t/p/w500/";
        public static string PosterOrigUrl = "https://image.tmdb.org/t/p/original/";
        public static string APIkey = ConfigurationManager.AppSettings["PersonalAPIkey"].ToString();
        public static string LangUS = "&language=en-US";
        public static string LangSE = "&language=sv-SE";
    }
}