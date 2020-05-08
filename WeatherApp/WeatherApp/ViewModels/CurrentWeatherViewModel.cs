using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewModel : INotifyPropertyChanged
    {
        public Command GoToCityEnteringCommand { get; }
        string city;
        public string City
        {
            get => city;
            set
            {
                city = value;
                var args = new PropertyChangedEventArgs(nameof(City));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public CurrentWeatherViewModel(string town)
        {
            City = town;
            //GoToCityEnteringCommand = new Command(async () =>
            //{
            //    var enteringPageVM = new EnteringPageViewModel();
            //    var currentweatherVM = new CurrentWeatherPage();
            //    currentweatherVM.BindingContext = enteringPageVM;
            //    await Application.Current.MainPage.Navigation.PushModalAsync(currentweatherVM);
            //});
        }
        public CurrentWeatherViewModel()
        { 
        }
    }
}
