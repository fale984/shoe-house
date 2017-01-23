using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ShoeHouse.Web.Filters
{
    /// <summary>
    /// Filter to validate Basic Authentication using hardcoded credentials
    /// Taken from https://stevescodingblog.co.uk/basic-authentication-with-asp-net-webapi/
    /// </summary>
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        private string adminUser = "my_user";
        private string adminPassword = "my_password";

        /// <summary>
        /// Verify authorization header befor execute action
        /// </summary>
        /// <param name="actionContext">Context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                //Authorization header not found, block request
                throw new CustomHttpException(401);
            }
            else
            {
                //Read user credentials
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] httpRequestHeaderValues = decodedToken.Split(':');
                string username = httpRequestHeaderValues[0];
                string password = httpRequestHeaderValues[1];

                //Validate user credentials
                if (username == adminUser && password == adminPassword)
                {
                    //Valid user, continue
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    //Invalid user, block request
                    throw new CustomHttpException(401);
                }
            }
        }
    }
}