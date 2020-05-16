using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherApp.Models;
using System;
using System.Collections.Generic;
using WeatherApp.StaticVariables;



namespace WeatherApp.Actions
{
    public class WeatherCore
    {
        private string Location { get; set; }
        public WeatherInfo WeatherInfo { get; set; }
        public ForecastInfo forecastInfo { get; set; }

        public WeatherCore(string location)
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

        public async Task<List<List>> GetForecast()
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={Location}&appid=c276e11cf8bfc48f24c61bd35615ca70&units=metric";
            var result = await ApiColler.Get(url);

            if (result.Succsessful)
            {
                List<List> allList = new List<List>();
                try
                {
                    forecastInfo = JsonConvert.DeserializeObject<ForecastInfo>(result.Response);
                    if (forecastInfo != null)
                    {
                        

                        foreach (var list in forecastInfo.list)
                        {
                            var date = DateTime.Parse(list.dt_txt);

                            if (date > DateTime.Now && date.Hour == 0 && date.Minute == 0 && date.Second == 0)
                                allList.Add(list);
                        }

                        DetailsPage.rain = allList[0].rain;
                        DetailsPage.wind = allList[0].wind;
                        DetailsPage.weather = allList[0].weather;
                        DetailsPage.clouds = allList[0].clouds;
                        DetailsPage.main = allList[0].main;

                        DetailsPage.rain2 = allList[1].rain;
                        DetailsPage.wind2 = allList[1].wind;
                        DetailsPage.weather2 = allList[1].weather;
                        DetailsPage.clouds2 = allList[1].clouds;
                        DetailsPage.main2 = allList[1].main;
                    }
                }
                catch /*(Exception ex)*/
                {
                    //await DisplayAlert("Weather Info", "Weather Info", ex.Message, "ok");
                }
                return allList;
            }
            else return null;
        }
    }
}
