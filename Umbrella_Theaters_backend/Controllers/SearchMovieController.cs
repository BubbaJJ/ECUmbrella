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
        public SearchMovie Get(string id)
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.SearchMovieUrl + TmdbCon.APIkey + TmdbCon.LangUS + "&query=" + id) as HttpWebRequest;
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
