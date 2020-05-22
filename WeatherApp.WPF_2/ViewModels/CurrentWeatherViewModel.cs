using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeatherApp.Actions;
using WeatherApp.StaticVariables;
using WeatherApp.WPF_2.Commands;
using WeatherApp.WPF_2.Helper;

namespace WeatherApp.WPF_2.ViewModels
{
    public class CurrentWeatherViewModel : BaseViewModel, IPageViewModel
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
                OnPropertyChanged(DescriptionTxt);
            }
        }

        public string IconImg
        {
            get => iconImg;
            set
            {
                iconImg = value;
                OnPropertyChanged(IconImg);
            }
        }

        public string CityTxt
        {
            get => cityTxt;
            set
            {
                cityTxt = value;
                OnPropertyChanged(CityTxt);
            }
        }

        public string TemperatureTxt
        {
            get => temperatureTxt;
            set
            {
                temperatureTxt = value;
                OnPropertyChanged(TemperatureTxt);
            }
        }

        public string DateTxt
        {
            get => dateTxt;
            set
            {
                dateTxt = value;
                OnPropertyChanged(DateTxt);
            }
        }

        public string DayOneTxt
        {
            get => dayOneTxt;
            set
            {
                dayOneTxt = value;
                OnPropertyChanged(DayOneTxt);
            }
        }

        public string DateOneTxt
        {
            get => dateOneTxt;
            set
            {
                dateOneTxt = value;
                OnPropertyChanged(DateOneTxt);
            }
        }

        public string IconOneImg
        {
            get => iconOneImg;
            set
            {
                iconOneImg = value;
                OnPropertyChanged(IconOneImg);
            }
        }

        public string TempOneTxt
        {
            get => tempOneTxt;
            set
            {
                tempOneTxt = value;
                OnPropertyChanged(TempOneTxt);
            }
        }

        public string DayTwoTxt
        {
            get => dayTwoTxt;
            set
            {
                dayTwoTxt = value;
                OnPropertyChanged(DayTwoTxt);
            }
        }

        public string DateTwoTxt
        {
            get => dateTwoTxt;
            set
            {
                dateTwoTxt = value;
                OnPropertyChanged(DateTwoTxt);
            }
        }

        public string IconTwoImg
        {
            get => iconTwoImg;
            set
            {
                iconTwoImg = value;
                OnPropertyChanged(IconTwoImg);
            }
        }

        public string TempTwoTxt
        {
            get => tempTwoTxt;
            set
            {
                tempTwoTxt = value;
                OnPropertyChanged(TempTwoTxt);
            }
        }
        #endregion
        private string Location { get; set; }

        public CurrentWeatherViewModel()
        {
            Location = CurrentWeatherConst.Location;
            GetWetherInfo();
        }

        private ICommand _goToCityEnteringCommand;
        public ICommand GoToCityEnteringCommand
        {
            get
            {
                return _goToCityEnteringCommand ?? (_goToCityEnteringCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToCityEnteringScreen", "");
                }));
            }
        }


        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand
        {
            get
            {
                return _goToDetailsCommand ?? (_goToDetailsCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToDetailsScreen", "");
                }));
            }
        }


        private ICommand _goToDetails2Command;
        public ICommand GoToDetails2Command
        {
            get
            {
                return _goToDetails2Command ?? (_goToDetails2Command = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToDetails2Screen", "");
                }));
            }
        }

        private async void GetWetherInfo()
        {
            var currentWeather = new WeatherCore(Location);
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
                //var enteringPageVM = new EnteringPageViewModel();
                //var enteringPage = new EnteringPage();
                //enteringPage.BindingContext = enteringPageVM;
                //await Application.Current.MainPage.Navigation.PushModalAsync(enteringPage);
            }
        }

        private async void GetForecast()
        {
            var weathCor = new WeatherCore(Location);
            var allList = await weathCor.GetForecast();

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
                //var enteringPageVM = new EnteringPageViewModel();
                //var enteringPage = new EnteringPage();
                //enteringPage.BindingContext = enteringPageVM;
                //await Application.Current.MainPage.Navigation.PushModalAsync(enteringPage);
            }
        }
    }
}
