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

        public event PropertyChangedEventHandler PropertyChanged;

        public CurrentWeatherViewModel()
        {
            GoToCityEnteringCommand = new Command(async () =>
            {
                var enteringPageVM = new EnteringPageViewModel();
                var enteringPage = new EnteringPage();
                enteringPage.BindingContext = enteringPageVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(enteringPage);
            });
        }

        public Command GoToCityEnteringCommand { get;}
    }
}
