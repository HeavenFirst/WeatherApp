using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Actions;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class CurrentWeatherPage : ContentPage
    {       
        private string Location { get; set; } = "France";
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static Rain rain { get; set; }
        public static Wind wind { get; set; }
        public static Clouds clouds { get; set; }
        public static Weather[] weather { get; set; }
        public static Main main { get; set; }

        public static Rain rain2 { get; set; }
        public static Wind wind2 { get; set; }
        public static Clouds clouds2 { get; set; }
        public static Weather[] weather2 { get; set; }
        public static Main main2 { get; set; }

        public CurrentWeatherPage(string city)
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
               // GetCoordinates();
            }
        }
        

        private async void OnClicked(object sender, System.EventArgs e)
        {
            ImageButton but = (ImageButton)sender;
            but.BackgroundColor = Color.Red;
            await Navigation.PushModalAsync(new EnteringPage());
        }

        private async void GoToDetails(object sender, System.EventArgs e)
        {
            //ImageButton but = (ImageButton)sender;
            //but.BackgroundColor = Color.Gray;
            await Navigation.PushModalAsync(new ViewDitails(rain, wind, clouds, weather, main));            
        }
        private async void GoToDetails2(object sender, System.EventArgs e)
        {
            //ImageButton but = (ImageButton)sender;
            //but.BackgroundColor = Color.Gray;
            await Navigation.PushModalAsync(new ViewDitails(rain2, wind2, clouds2, weather2, main2));
        }
        private async void GetCoordinates()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if(location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    Location = await GetCity(location);

                    GetWetherInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        private async Task<string> GetCity(Location location)
        {
            var places = await Geocoding.GetPlacemarksAsync(location);
            var currentPlace = places?.FirstOrDefault();

            if(currentPlace != null)
            {
                return $"{currentPlace.Locality},{currentPlace.CountryName}";
            }
            return null;
        }

        private async void GetWetherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid=c276e11cf8bfc48f24c61bd35615ca70&units=metric";

            var result = await ApiColler.Get(url);

            if (result.Succsessful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response);
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
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={Location}&appid=c276e11cf8bfc48f24c61bd35615ca70&units=metric";
            var result = await ApiColler.Get(url);

            if (result.Succsessful)
            {
                try
                {
                    var forecastInfo = JsonConvert.DeserializeObject<ForecastInfo>(result.Response);

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
                    rain = allList[0].rain;
                    wind = allList[0].wind;
                    weather = allList[0].weather;
                    clouds = allList[0].clouds;
                    main = allList[0].main;

                    dayTwoTxt.Text = DateTime.Parse(allList[1].dt_txt).ToString("dddd");
                    dateTwoTxt.Text = DateTime.Parse(allList[1].dt_txt).ToString("dd MMM");
                    iconTwoImg.Source = $"w{ allList[1].weather[0].icon}";
                    tempTwoTxt.Text = allList[1].main.temp.ToString("0");
                    rain2 = allList[1].rain;
                    wind2 = allList[1].wind;
                    weather2 = allList[1].weather;
                    clouds2 = allList[1].clouds;
                    main2 = allList[1].main;
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