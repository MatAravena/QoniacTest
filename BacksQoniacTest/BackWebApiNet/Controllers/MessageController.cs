using Common.Logic;
using Common.Model;
using Newtonsoft.Json;
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
                Content = new StringContent(JsonConvert.SerializeObject("RESPT OK!"))
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return result;
        }

        public HttpResponseMessage Response(object obj)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(obj))
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return result;
        }

        [Route("api/ChangevalueServ")]
        [HttpPost]
        public HttpResponseMessage ChangeValueServ(DataMessage value)
        {
            Logic lgc = new Logic();
            return Response(lgc.GetValue(value));
        }
    }
}
