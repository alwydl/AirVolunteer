using AirVolunteer.Definitions;
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
    internal static class FlightAPI
    {
        public static async Task<List<FlightMOD>> GetFlightsAsync()
        {
            string url = Parameters.BaseUrl;

            using (HttpClient client = new HttpClient())
            {
                string requestUri = string.Format("{0}/Flights/GetPilotFlightsInfo?pilotID={1}", url, Parameters.PilotID);
                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON content into a list of OrderMOD objects (replace with your actual deserialization logic)
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<FlightMOD>>(data);
                }
                else
                {
                    // Handle API errors
                    throw new Exception();
                }
            }
        }

        public static async Task<bool> PostFlightAsync(FlightMOD flight)
        {
            string url = Parameters.BaseUrl;

            using (HttpClient client = new HttpClient())
            {
                string requestUri = string.Format("{0}/Flights/PostFlightInfo", url);
                var temp = JsonConvert.SerializeObject(flight);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(flight));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON content into a list of OrderMOD objects (replace with your actual deserialization logic)
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bool>(data);
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
