using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.StaticVariables;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewModel /*: INotifyPropertyChanged*/
    {

       // public event PropertyChangedEventHandler PropertyChanged;

        public CurrentWeatherViewModel()
        {
            GoToCityEnteringCommand = new Command(async () =>
            {
                var enteringPageVM = new EnteringPageViewModel();
                var enteringPage = new EnteringPage();
                enteringPage.BindingContext = enteringPageVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(enteringPage);
            });

            GoToDetailsCommand = new Command(async () =>
            {
                var viewDitailsVM = new ViewDitailsViewModel(DetailsPage.rain, DetailsPage.wind, DetailsPage.clouds, DetailsPage.weather, DetailsPage.main);
                var viewDitails = new ViewDitails();
                viewDitails.BindingContext = viewDitailsVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(viewDitails);
            });

            GoToDetails2Command = new Command(async () =>
            {
                var viewDitailsVM = new ViewDitailsViewModel(DetailsPage.rain2, DetailsPage.wind2, DetailsPage.clouds2, DetailsPage.weather2, DetailsPage.main2);
                var viewDitails = new ViewDitails();
                viewDitails.BindingContext = viewDitailsVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(viewDitails);
            });

        }

        public Command GoToCityEnteringCommand { get;}
        public Command GoToDetailsCommand { get; }
        public Command GoToDetails2Command { get; }
    }
}
