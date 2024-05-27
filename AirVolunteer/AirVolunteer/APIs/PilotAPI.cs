using AirVolunteer.Definitions;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AirVolunteer.APIs
{
    internal static class PilotAPI
    {
        public static async Task<PilotMOD> GetPilotAsync()
        {
            string url = Parameters.BaseUrl;

            using (HttpClient client = new HttpClient())
            {
                string requestUri = string.Format("{0}/Pilot/GetPilotInfo?pilotID={1}", url, Parameters.PilotID);

                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON content into a list of OrderMOD objects (replace with your actual deserialization logic)
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PilotMOD>(data); 
                }
                else
                {
                    // Handle API errors
                    throw new Exception();
                }
            }
        }

        public static async Task<PilotMOD> PostPilotAsync(PilotMOD pilot)
        {
            string url = Parameters.BaseUrl;

            using (HttpClient client = new HttpClient())
            {
                string requestUri = string.Format("{0}/Pilot/PostPilotInfo", url);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(pilot));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON content into a list of OrderMOD objects (replace with your actual deserialization logic)
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PilotMOD>(data);
                }
                else
                {
                    // Handle API errors
                    throw new Exception();
                }
            }
        }
    }
}
