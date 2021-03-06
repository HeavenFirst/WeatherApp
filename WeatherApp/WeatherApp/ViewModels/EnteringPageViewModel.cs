﻿using WeatherApp.StaticVariables;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class EnteringPageViewModel : BaseViewModel
    {
        public EnteringPageViewModel()
        {
            GetCityWeatherCommand = new Command(async () =>
            {
                CurrentWeatherConst.Location = TownName;
                var weatherPageVM = new CurrentWeatherViewModel(/*TownName*/);
                var weatherPage = new CurrentWeatherPage();
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
                OnPropertyChanged();
            }
        }
    }
}
