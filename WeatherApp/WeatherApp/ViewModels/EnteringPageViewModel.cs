using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class EnteringPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public EnteringPageViewModel()
        {
            GetCityWeatherCommand = new Command(async () =>
            {
               // var weatherPageVM = new CurrentWeatherViewModel();
                var weatherPage = new CurrentWeatherPage(TheTown);
                //weatherPage.BindingContext = weatherPageVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(weatherPage);
            });
        }
        public Command GetCityWeatherCommand { get; }

        string theTown;
        public string TheTown
        {
            get => theTown;
            set
            {
                theTown = value;
                var args = new PropertyChangedEventArgs(nameof(TheTown));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}
