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
    public class SearchMovieController : ApiController
    {
        // GET: api/SearchMovie
        public SearchMovie Get()
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.SearchMovieUrl + TmdbCon.APIkey + TmdbCon.LangUS + "&query=Fight%20Club") as HttpWebRequest;
            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            ResponseSearchMovie ThisMovie = JsonConvert.DeserializeObject<ResponseSearchMovie>(ApiResponse);

            SearchMovie SearchMovie = new SearchMovie();

            SearchMovie.Page = ThisMovie.Page;
            SearchMovie.TotalResults = ThisMovie.Total_results;
            SearchMovie.TotalPages = ThisMovie.Total_pages;
            SearchMovie.ListResults = ThisMovie.Results;

            return SearchMovie;
        }

        // GET: api/SearchMovie/5
        public List<Movie> Get(string id)
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.SearchMovieUrl + TmdbCon.APIkey + TmdbCon.LangUS + "&query=" + id) as HttpWebRequest;
            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            ResponseSearchMovie ThisMovie = JsonConvert.DeserializeObject<ResponseSearchMovie>(ApiResponse);

            var searchResult = new List<Movie>();

            foreach (var movie in ThisMovie.Results)
            {
                searchResult.Add(new Movie
                {
                    Overview = movie.overview,
                    Id = movie.id,
                    PosterPath = movie.poster_path,
                    MovieName = movie.title,
                    VoteAverage = movie.vote_average,
                    ReleaseDate = movie.release_date,
                    TotalResults = ThisMovie.Total_results,
                    TotalPages = ThisMovie.Total_pages
                });
            }

            return searchResult.OrderByDescending(x => x.VoteAverage).ToList();
        }
        [Route("api/SearchMovie/{id}/{page}")]
        public List<Movie> Get(string id, int page) //Special för uppdatering av modal.
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.SearchMovieUrl + TmdbCon.APIkey + TmdbCon.LangUS + "&query=" + id + "&page=" + page) as HttpWebRequest;
            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            ResponseSearchMovie ThisMovie = JsonConvert.DeserializeObject<ResponseSearchMovie>(ApiResponse);

            var searchResult = new List<Movie>();

            foreach (var movie in ThisMovie.Results)
            {
                searchResult.Add(new Movie
                {
                    Overview = movie.overview,
                    Id = movie.id,
                    PosterPath = movie.poster_path,
                    MovieName = movie.title,
                    VoteAverage = movie.vote_average,
                    ReleaseDate = movie.release_date,
                    TotalResults = ThisMovie.Total_results,
                    TotalPages = ThisMovie.Total_pages
                });
            }

            return searchResult.OrderByDescending(x => x.VoteAverage).ToList();
        }

        // POST: api/SearchMovie
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SearchMovie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SearchMovie/5
        public void Delete(int id)
        {
        }
    }
}
