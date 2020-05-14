using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Actions;
using WeatherApp.Models;
using WeatherApp.StaticVariables;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [DesignTimeVisible(false)]
    public partial class CurrentWeatherPage : ContentPage
    {
        private string Location { get; set; } = "Berdyansk";


        public  CurrentWeatherPage(string city)
        {            
            if (city != string.Empty)
            {
                InitializeComponent();
                Location = city;
                GetWetherInfo();
            }
            else
            {
                InitializeComponent();
                Coordinates();                
                GetWetherInfo();               
            }
        }
        
        private async void Coordinates()
        {
            var coord = new Coordinates();
            Location = await coord.GetCoordinates();
        }

        private async void GetWetherInfo()
        {
            var currentWeather = new WetherInfo(Location);
            var weatherInfo = await currentWeather.GetWetherInfo();
            if (weatherInfo != null)
            {
                try
                {
                    descriptionTxt.Text = weatherInfo.weather[0].description.ToUpper();
                    iconImg.Source = $"w{weatherInfo.weather[0].icon}";
                    cityTxt.Text = weatherInfo.name.ToUpper();
                    temperatureTxt.Text = weatherInfo.main.temp.ToString("0");
                  
                    dateTxt.Text = DateTime.Now.ToString("dddd,  MMM dd").ToUpper();

                    GetForecast();
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Weather Info", "Weather Info", ex.Message, "ok");
                }
            }
            else
            {
                await DisplayAlert("Weather Info", "The name of town was entered with grammar mistake!", "ok" );
                await Navigation.PushModalAsync(new EnteringPage());
            }
        }

        private async void GetForecast()
        {
            var forecast = new WetherInfo(Location);
            var forecastInfo = await forecast.GetForecast();

            if(forecastInfo != null)
            {
                try
                {
                    List<List> allList = new List<List>();

                    foreach(var list in forecastInfo.list)
                    {
                        var date = DateTime.Parse(list.dt_txt);

                        if (date > DateTime.Now && date.Hour == 0 && date.Minute == 0 && date.Second == 0)
                            allList.Add(list);
                    }

                    dayOneTxt.Text = DateTime.Parse(allList[0].dt_txt).ToString("dddd");
                    dateOneTxt.Text = DateTime.Parse(allList[0].dt_txt).ToString("dd MMM");
                    iconOneImg.Source = $"w{ allList[0].weather[0].icon}";
                    tempOneTxt.Text = allList[0].main.temp.ToString("0");
                    DetailsPage.rain = allList[0].rain;
                    DetailsPage.wind = allList[0].wind;
                    DetailsPage.weather = allList[0].weather;
                    DetailsPage.clouds = allList[0].clouds;
                    DetailsPage.main = allList[0].main;

                    dayTwoTxt.Text = DateTime.Parse(allList[1].dt_txt).ToString("dddd");
                    dateTwoTxt.Text = DateTime.Parse(allList[1].dt_txt).ToString("dd MMM");
                    iconTwoImg.Source = $"w{ allList[1].weather[0].icon}";
                    tempTwoTxt.Text = allList[1].main.temp.ToString("0");
                    DetailsPage.rain2 = allList[1].rain;
                    DetailsPage.wind2 = allList[1].wind;
                    DetailsPage.weather2 = allList[1].weather;
                    DetailsPage.clouds2 = allList[1].clouds;
                    DetailsPage.main2 = allList[1].main;
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Weather Info", "Weather Info",ex.Message, "ok");
                }

            }
            else
            {
                await DisplayAlert("Weather Info", "The name of town was entered with grammar mistake!", "ok");
                await Navigation.PushModalAsync(new EnteringPage());
            }
        }
    }
}