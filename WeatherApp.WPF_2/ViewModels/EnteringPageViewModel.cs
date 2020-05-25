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
    public class EnteringPageViewModel : BaseViewModel, IPageViewModel
    {
        public EnteringPageViewModel()
        {
            if (TownName != null)
            //TownName = "London";
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
                        CurrentWeatherConst.Location = TownName;
                        var currentWeather = new WeatherCore(TownName);
                        var weatherInfo =  currentWeather.GetWetherInfo();
                    }
                    Mediator.Notify("GetCityWeatherScreen", TownName);
                }));
            }
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
