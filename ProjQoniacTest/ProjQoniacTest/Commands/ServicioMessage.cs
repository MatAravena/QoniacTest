using ProjQoniacTest.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjQoniacTest.Commands
{
    public class ServicioMessage
    {

        private static readonly HttpClient client = new HttpClient();

        public async Task<string> SendMessageAsync(string msj)
        {
            var content = new FormUrlEncodedContent(JsonConvert.SerializeObject((dynamic)new DataMessage(msj)));

            var response = await client.PostAsync("http://localhost:50525/api/", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return string.Empty;
        }
    }
}
