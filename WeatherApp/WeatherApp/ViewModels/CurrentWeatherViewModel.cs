using System;
using System.Collections.Generic;
using WeatherApp.Actions;
using WeatherApp.Models;
using WeatherApp.StaticVariables;
using WeatherApp.Views;
using Xamarin.Forms;


using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewModel : INotifyPropertyChanged //: BaseViewModel
    {
        #region Values
        string descriptionTxt;
        string iconImg;
        string cityTxt;
        string temperatureTxt;
        string dateTxt;
        string dayOneTxt;
        string dateOneTxt;
        string iconOneImg;
        string tempOneTxt;
        string dayTwoTxt;
        string dateTwoTxt;
        string iconTwoImg;
        string tempTwoTxt;
        #endregion   
        

        #region Properties
        public string DescriptionTxt
        {
            get => descriptionTxt;
            set
            {
                descriptionTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DescriptionTxt)));// OnPropertyChanged(DescriptionTxt);
            }
        }

        public string IconImg
        {
            get => iconImg;
            set
            {
                iconImg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconImg)));//OnPropertyChanged(IconImg);
            }
        }

        public string CityTxt
        {
            get => cityTxt;
            set
            {
                cityTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityTxt)));//OnPropertyChanged(CityTxt);
            }
        }

        public string TemperatureTxt
        {
            get => temperatureTxt;
            set
            {
                temperatureTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureTxt)));//OnPropertyChanged(TemperatureTxt);
            }
        }

        public string DateTxt
        {
            get => dateTxt;
            set
            {
                dateTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateTxt)));// OnPropertyChanged(DateTxt);
            }
        }

        public string DayOneTxt
        {
            get => dayOneTxt;
            set
            {
                dayOneTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayOneTxt)));// OnPropertyChanged(DayOneTxt);
            }
        }

        public string DateOneTxt
        {
            get => dateOneTxt;
            set
            {
                dateOneTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconOneImg)));// OnPropertyChanged(IconOneImg);
            }
        }

        public string IconOneImg
        {
            get => iconOneImg;
            set
            {
                iconOneImg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconOneImg)));//OnPropertyChanged(IconOneImg);
            }
        }

        public string TempOneTxt
        {
            get => tempOneTxt;
            set
            {
                tempOneTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TempOneTxt)));// OnPropertyChanged(TempOneTxt);
            }
        }

        public string DayTwoTxt
        {
            get => dayTwoTxt;
            set
            {
                dayTwoTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayTwoTxt)));// OnPropertyChanged(DayTwoTxt);
            }
        }

        public string DateTwoTxt
        {
            get => dateTwoTxt;
            set
            {
                dateTwoTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateTwoTxt)));// OnPropertyChanged(DateTwoTxt);
            }
        }

        public string IconTwoImg
        {
            get => iconTwoImg;
            set
            {
                iconTwoImg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconTwoImg)));// OnPropertyChanged(IconTwoImg);
            }
        }

        public string TempTwoTxt
        {
            get => tempTwoTxt;
            set
            {
                tempTwoTxt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TempTwoTxt)));// OnPropertyChanged(TempTwoTxt);
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private string Location { get; set; } 

        public Command GoToCityEnteringCommand { get; }
        public Command GoToDetailsCommand { get; }
        public Command GoToDetails2Command { get; }

        
        public CurrentWeatherViewModel(/*string townName*/)
        {
            Location = CurrentWeatherConst.Location;  //townName;
            if (Location == null) Coordinates();
            else  GetWetherInfo(); 
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

        

        private async void Coordinates()
        {
            var coord = new Coordinates();
            Location = await coord.GetCoordinates();
            GetWetherInfo();
        }

        private async void GetWetherInfo()
        {
            var currentWeather = new WetherInfo(Location);
            var weatherInfo = await currentWeather.GetWetherInfo();
            if (weatherInfo != null)
            {
                    DescriptionTxt = weatherInfo.weather[0].description.ToUpper();
                    IconImg = $"w{weatherInfo.weather[0].icon}";
                    CityTxt = weatherInfo.name.ToUpper();
                    TemperatureTxt = weatherInfo.main.temp.ToString("0");
                    DateTxt = DateTime.Now.ToString("dddd,  MMM dd").ToUpper();

                    GetForecast();               
            }
            else
            {
                //await DisplayAlert("Weather Info", "The name of town was entered with grammar mistake!", "ok");
                var enteringPageVM = new EnteringPageViewModel();
                var enteringPage = new EnteringPage();
                enteringPage.BindingContext = enteringPageVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(enteringPage);                
            }
        }

        private async void GetForecast()
        {
            var forecast = new WetherInfo(Location);
            var allList = await forecast.GetForecast();

            if (allList != null)
            {
                DayOneTxt = DateTime.Parse(allList[0].dt_txt).ToString("dddd");
                DateOneTxt = DateTime.Parse(allList[0].dt_txt).ToString("dd MMM");
                IconOneImg = $"w{ allList[0].weather[0].icon}";
                TempOneTxt = allList[0].main.temp.ToString("0");


                DayTwoTxt = DateTime.Parse(allList[1].dt_txt).ToString("dddd");
                DateTwoTxt = DateTime.Parse(allList[1].dt_txt).ToString("dd MMM");
                IconTwoImg = $"w{ allList[1].weather[0].icon}";
                TempTwoTxt = allList[1].main.temp.ToString("0");
            }
            else
            {
                //await DisplayAlert("Weather Info", "The name of town was entered with grammar mistake!", "ok");
                var enteringPageVM = new EnteringPageViewModel();
                var enteringPage = new EnteringPage();
                enteringPage.BindingContext = enteringPageVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(enteringPage);
            }
        }

    }
}
