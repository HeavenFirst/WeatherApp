using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Actions;
using WeatherApp.Models;
using WeatherApp.StaticVariables;
using WeatherApp.WPF_2.Commands;
using WeatherApp.WPF_2.Helper;

namespace WeatherApp.WPF_2.ViewModels
{
    public class EnteringPageViewModel : BaseViewModel, IPageViewModel
    {
        public EnteringPageViewModel()
        {
            if (TownName != null)
            CurrentWeatherConst.Location = TownName;

        }
        private ICommand _getCityWeatherCommand;
        public  ICommand GetCityWeatherCommand
        {
            get
            {               
                return _getCityWeatherCommand ?? (_getCityWeatherCommand = new RelayCommand(x =>
                {
                    if (TownName != null)
                    {
                        Helper();
                        CurrentWeatherConst.Location = TownName;
                    }
                    else Mediator.Notify("GetCityWeatherScreen", TownName);
                }));
            }
        }

        private async Task<WeatherInfo> Helper()
        {
            var currentWeather = new WeatherCore(TownName);
            var weatherInfo = await currentWeather.GetWetherInfo();
            Mediator.Notify("GetCityWeatherScreen", TownName);
            return weatherInfo;
        }

        private ICommand _onClickedBackCommand;
        public ICommand OnClickedBackCommand
        {
            get
            {
                return _onClickedBackCommand ?? (_onClickedBackCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("OnClickedBackScreen", "");
                }));
            }
        }


        string townName;
        public string TownName
        {
            get => townName;
            set
            {
                townName = value;
                CurrentWeatherConst.Location = townName;
                OnPropertyChanged(TownName);
            }
        }
    }    
}
