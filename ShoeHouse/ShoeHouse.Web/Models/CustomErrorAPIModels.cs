using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ShoeHouse.Web.Models
{
    [XmlRoot(ElementName = "error_response")]
    public class CustomErrorResponse
    {
        public bool success { get; set; }

        public int error_code { get; set; }

        public string error_msg { get; set; }

        public CustomErrorResponse()
        {
            success = false;
        }

        public CustomErrorResponse(int code, string msg)
        {
            success = false;
            error_code = code;
            error_msg = msg;
        }
    }
}