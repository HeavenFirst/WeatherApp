using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.StaticVariables;
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
                var weatherPage = new CurrentWeatherPage(/*TownName*/);
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
                OnPropertyChanged(TownName);
            }
        }
    }
}
