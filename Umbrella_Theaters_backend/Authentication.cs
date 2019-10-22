using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;
using Umbrella_Theaters_backend.Models;

namespace Umbrella_Theaters_backend
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            UmbrellaTheatersEntities db = new UmbrellaTheatersEntities();

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string userPassword = decodedToken.Substring(decodedToken.IndexOf(":") + 1);


                var userId = 0;

                try
                {
                    userId = db.Users.Where(un => un.Email == userName)
                    .Where(pw => pw.Password == userPassword)
                    .FirstOrDefault().UserId;
                }
                catch
                {
                    userId = -1;
                }
 
                if (userId < 1)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }

    }
}