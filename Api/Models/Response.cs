using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Api.Models
{
    public class Response
    {
        //public string Token { get; set; }
        //public HttpResponseMessage responseMsg { get; set; }

        public Boolean Status { get; set; }
        public object Data { get; set; }
        public String Message { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}