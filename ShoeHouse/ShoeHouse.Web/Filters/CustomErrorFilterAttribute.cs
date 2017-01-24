using ShoeHouse.Web.Models;
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

            //If the error was thrown by custom code, the exception can be casted
            var customError = context.Exception as CustomHttpException;
            if (customError == null)
            {
                //If could not be casted, create a default server error
                customError = new CustomHttpException(500);
            }

            //Convert te exception to custom object
            var response = new CustomErrorResponse(customError.ErrorCode, customError.Message);

            //Return custom object
            var request = context.ActionContext.Request;
            context.Response = context.Request.CreateResponse((HttpStatusCode)customError.ErrorCode, response);
        }

    }
}