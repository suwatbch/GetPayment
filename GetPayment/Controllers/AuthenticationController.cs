using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetPayment.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [Route("Authentication")]
        public JObject authenticationService([FromBody] JObject authenticationJson)
        {
            JObject retJson = new JObject();
            string username = authenticationJson["username"].ToString();
            string password = authenticationJson["password"].ToString();
            if (username == "user" && password == "user")
            {
                retJson.Add(new JProperty("authentication ", "successful"));
            }
            else
            {
                retJson.Add(new JProperty("authentication ", "unsuccessful"));
            }
            return retJson;
        }
    }
}
