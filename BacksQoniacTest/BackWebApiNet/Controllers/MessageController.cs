using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace BackWebApiNet.Controllers
{
    public class MessageController : ApiController
    {
        [Route("api/Test")]
        [HttpGet]
        public HttpResponseMessage Test()
        {
            return Response();
        }

        public HttpResponseMessage Response()
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject("RESPT OK!" ))
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return result;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
            string valueasd = string.Empty;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}