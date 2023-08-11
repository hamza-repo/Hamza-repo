using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace appww1
{
    public static class webservices
    {

        public static async Task<List<Employee>> Get_api(string URL)
        {
            using (var httpClient = new HttpClient())
            {

                string responseString2 = await httpClient.GetStringAsync(URL);


                var t = JsonConvert.DeserializeObject<List<Employee>>(responseString2);
                return t;
            }
        }


        public static async Task<HttpResponseMessage> post_To_api(string url, StringContent data)
        {
            using var client = new HttpClient();
            {


                var response = await client.PostAsync(url, data);
                return response;

            }
        }

        public static async void Delete (string url,string id)
            {
            string uri = url + "/" + id;
            var client = new HttpClient();
            var response = await client.DeleteAsync(uri);
            




        }
    }


    }

