using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GetMovieController : ApiController
    {
        // GET: api/GetMovie
        public IEnumerable<string> GetMovie()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetMovie/5
        public Movie GetMovie(int? id) // utan allow null så blir det fel i anropet i MoviesController på raderna 32 & 36 efter att ha uppdaterat db modellen.
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.MovieUrl + id + TmdbCon.APIkey + TmdbCon.LangUS) as HttpWebRequest;
            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            ResponseMovie ThisMovie = JsonConvert.DeserializeObject<ResponseMovie>(ApiResponse);
            Movie Movie = new Movie();
            var trailers = GetTrailer("550");

            Movie.MovieName = ThisMovie.original_title;
            Movie.Id = ThisMovie.Id;
            Movie.Runtime = ThisMovie.Runtime;
            Movie.GenreName = ThisMovie.Genres;
            Movie.PosterPath = ThisMovie.Poster_Path;
            Movie.AdultMovie = ThisMovie.AdultMovie;
            Movie.VoteAverage = ThisMovie.vote_average;
            Movie.ReleaseDate = ThisMovie.release_date;
            Movie.Overview = ThisMovie.Overview;
            Movie.TrailerPath = trailers.Results[0].Key;

            return Movie;
        }

        // GET: api/GetMovie/(id, datetime) //Skickar med datetime för att ta ut startdatum på kommande filmer.
        public Movie GetMovie(int id, DateTime startdate)
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.MovieUrl + id + TmdbCon.APIkey + TmdbCon.LangUS) as HttpWebRequest;
            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            ResponseMovie ThisMovie = JsonConvert.DeserializeObject<ResponseMovie>(ApiResponse);
            Movie Movie = new Movie();
            var trailers = GetTrailer("550");

            Movie.MovieName = ThisMovie.original_title;
            Movie.Id = ThisMovie.Id;
            Movie.Runtime = ThisMovie.Runtime;
            Movie.GenreName = ThisMovie.Genres;
            Movie.PosterPath = ThisMovie.Poster_Path;
            Movie.AdultMovie = ThisMovie.AdultMovie;
            Movie.VoteAverage = ThisMovie.vote_average;
            Movie.ReleaseDate = ThisMovie.release_date;
            Movie.Overview = ThisMovie.Overview;
            Movie.BackdropPath = ThisMovie.backdrop_path;
            Movie.StartDate = startdate;
            Movie.TrailerPath = trailers.Results[0].Key;

            return Movie;
        }

        [Route("thisisit")]
        public IdAndTrailer GetTrailer(string id)
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.MovieUrl + id + "/videos" + TmdbCon.APIkey + TmdbCon.LangUS) as HttpWebRequest;

            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            IdAndTrailer trailers = JsonConvert.DeserializeObject<IdAndTrailer>(ApiResponse);

            return trailers;
        }

        // POST: api/GetMovie
        public void PostMovie([FromBody]string value)
        {
        }

        // PUT: api/GetMovie/5
        public void PutMovie(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetMovie/5
        public void DeleteMovie(int id)
        {
        }
    }
}
