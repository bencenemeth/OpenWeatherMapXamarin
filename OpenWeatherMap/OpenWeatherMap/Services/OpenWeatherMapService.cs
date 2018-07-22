using Newtonsoft.Json;
using OpenWeatherMap.Models;
using OpenWeatherMapTest.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Services
{
    public class OpenWeatherMapService
    {
        //private readonly Uri Uri = new Uri("http://api.openweathermap.org/data/2.5/");

        //private readonly string ApiKey = "APPID=4ea98f74622072acddf2f67deb259125";

        public void SetCredentials()
        {
            SettingsService.Uri = "http://api.openweathermap.org/data/2.5/";
            SettingsService.ApiKey = "4ea98f74622072acddf2f67deb259125";
            SettingsService.Units = "metric";
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                // Ignoring null values and missing members from response
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                // Getting the response
                var response = await client.GetAsync(uri);

                // Reading response as string
                var json = await response.Content.ReadAsStringAsync();

                // Deserializing to the appropriate object
                T result = JsonConvert.DeserializeObject<T>(json, settings);
                return result;
            }
        }

        public async Task<WeatherData> GetWeatherForCityAsync(string query)
        {
            return await GetAsync<WeatherData>(new Uri(SettingsService.Uri + $"weather?q={query}&units={SettingsService.Units}&APPID={SettingsService.ApiKey}"));
        }

        public async Task<Forecast> GetForecastForCityAsync(string query)
        {
            return await GetAsync<Forecast>(new Uri(SettingsService.Uri + $"forecast?q={query}&units={SettingsService.Units}&APPID={SettingsService.ApiKey}"));
        }
    }
}
