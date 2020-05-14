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
                var weatherPageVM = new CurrentWeatherViewModel();
                var weatherPage = new CurrentWeatherPage(TownName);
                weatherPage.BindingContext = weatherPageVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(weatherPage);
            });

            OnClickedBackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }
        public Command GetCityWeatherCommand { get; }
        public Command OnClickedBackCommand { get; }

        string townName;
        public string TownName
        {
            get => townName;
            set
            {
                townName = value;
                var args = new PropertyChangedEventArgs(nameof(TownName));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}
