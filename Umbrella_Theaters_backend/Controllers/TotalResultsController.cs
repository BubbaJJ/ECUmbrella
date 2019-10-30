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
    public class TotalResultsController : ApiController
    {
        // GET: api/TotalResults
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TotalResults/5
        public SearchMovie Get(string id)
        {
            HttpWebRequest apiRequest = WebRequest.Create(TmdbCon.SearchMovieUrl + TmdbCon.APIkey + TmdbCon.LangUS + "&query=" + id) as HttpWebRequest;
            string ApiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ApiResponse = reader.ReadToEnd();
            }
            ResponseSearchMovie TotalResults = JsonConvert.DeserializeObject<ResponseSearchMovie>(ApiResponse);

            SearchMovie SearchMovie = new SearchMovie();

            SearchMovie.Page = TotalResults.Page;
            SearchMovie.TotalResults = TotalResults.Total_results;
            SearchMovie.TotalPages = TotalResults.Total_pages;
            //SearchMovie.ListResults = TotalResults.Results;

            return SearchMovie;
        }

        // POST: api/TotalResults
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TotalResults/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TotalResults/5
        public void Delete(int id)
        {
        }
    }
}
