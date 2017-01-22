using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ShoeHouse.Web.Controllers
{
    /// <summary>
    /// Base class for services, allows custom model response
    /// </summary>
    public abstract class ExtendedResponseController : ApiController
    {
        /// <summary>
        /// Wraps single object in custom model
        /// </summary>
        /// <param name="modelName">Singular model name</param>
        /// <param name="model">Single object</param>
        /// <returns>Custom model</returns>
        protected IHttpActionResult Success(string modelName, object model)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            result.Add(modelName, model);

            return Ok(result);
        }

        /// <summary>
        /// Wraps enumerable object in custom model
        /// </summary>
        /// <typeparam name="T">Enumerable type</typeparam>
        /// <param name="modelName">Plural model name</param>
        /// <param name="model">Object array</param>
        /// <returns>Custom model with lenght attribute</returns>
        protected IHttpActionResult Success<T>(string modelName, IEnumerable<T> model)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            result.Add(modelName, model);
            result.Add("total_elements", model == null ? 0 : model.Count());

            return Ok(result);
        }
    }
}