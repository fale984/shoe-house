using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeHouse.Web.Filters
{
    /// <summary>
    /// Custom exception class for HTTP errors with messages according to the requirements
    /// </summary>
    public class CustomHttpException : Exception
    {
        public int ErrorCode { get; private set; }

        public override string Message
        {
            get
            {
                if (ErrorCode == 400) return "Bad request";

                if (ErrorCode == 401) return "Not authorized";

                if (ErrorCode == 404) return "Record not found";

                return "Server Error";
            }
        }

        /// <summary>
        /// Default custom exception is 500 - Server Error
        /// </summary>
        public CustomHttpException()
        {
            this.ErrorCode = 500;
        }

        public CustomHttpException(int errorCode)
        {
            this.ErrorCode = errorCode;
        }
    }
}