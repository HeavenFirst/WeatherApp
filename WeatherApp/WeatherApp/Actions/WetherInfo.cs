using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherApp.Models;



using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using WeatherApp.Actions;
using WeatherApp.StaticVariables;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace WeatherApp.Actions
{
    public class WetherInfo
    {
        private string Location { get; set; }
        public WeatherInfo WeatherInfo { get; set; }
        public ForecastInfo forecastInfo { get; set; }

        public WetherInfo(string location)
        {
            Location = location;
        }

        public async Task<WeatherInfo> GetWetherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid=c276e11cf8bfc48f24c61bd35615ca70&units=metric";

            var result = await ApiColler.Get(url);

            if (result.Succsessful)
            {
                try
                {
                    WeatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response);
                }
                catch /*(Exception ex)*/
                {
                    //await DisplayAlert("Weather Info", "Weather Info", ex.Message, "ok");
                }
                return WeatherInfo;
            }
            else return null;
        }

        public async Task<ForecastInfo> GetForecast()
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={Location}&appid=c276e11cf8bfc48f24c61bd35615ca70&units=metric";
            var result = await ApiColler.Get(url);

            if (result.Succsessful)
            {
                try
                {
                    forecastInfo = JsonConvert.DeserializeObject<ForecastInfo>(result.Response);
                }
                catch /*(Exception ex)*/
                {
                    //await DisplayAlert("Weather Info", "Weather Info", ex.Message, "ok");
                }
                return forecastInfo;
            }
            else return null;
        }
    }
}
