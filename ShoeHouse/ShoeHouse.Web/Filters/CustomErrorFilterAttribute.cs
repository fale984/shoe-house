using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ShoeHouse.Web.Filters
{
    public class CustomErrorFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Filter to convert normal exceptions in custom formated exceptions for the service
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            //By default the response will be server error
            int error_code = 500;
            string error_msg = "Server Error";

            //If the error was thrown by custom code, the exception can be casted
            var customError = context.Exception as CustomHttpException;
            if (customError != null)
            {
                error_code = customError.ErrorCode;
                error_msg = customError.Message;
            }

            //Convert te exception to custom object
            var response = new
            {
                success = false,
                error_code,
                error_msg
            };

            //Return custom object
            var request = context.ActionContext.Request;
            context.Response = context.Request.CreateResponse((HttpStatusCode)error_code, response);
        }

    }
}