using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;
using Umbrella_Theaters_backend.Models;
using System.Threading;
using System.Security.Principal;
using System.Web.Http.Cors;

namespace Umbrella_Theaters_backend
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

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

                string firstName = null;
                var userId = 0;

                try
                {
                    userId = db.Users.Where(un => un.Email == userName)
                    .Where(pw => pw.Password == userPassword)
                    .FirstOrDefault().UserId;
                    firstName = db.Users.Find(userId).FirstName;
                }
                catch
                {
                    userId = -1;
                }

                if (userId > 0)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(db.Users.Find(userId).Email), null);
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }




            }
        }

    }
}