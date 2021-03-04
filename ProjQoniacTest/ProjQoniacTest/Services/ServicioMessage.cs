using ProjQoniacTest.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers; 

namespace ProjQoniacTest.Services
{
    public class ServicioMessage
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> SendMessageAsync(string msj)
        {
            var data = new StringContent(JsonConvert.SerializeObject(new DataMessage(msj)), Encoding.UTF8, "application/json");
            DataMessage resultObj = new DataMessage();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.PostAsync("http://localhost:50525/api/ChangevalueServ", data);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    resultObj = JsonConvert.DeserializeObject<DataMessage>(result);
                    response.Dispose();
                }
                else
                {
                    return "problems to comunication with server";
                }
            }

            return resultObj.numbInWords;
        }
    }
}
