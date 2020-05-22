using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeatherApp.WPF_2.Commands;
using WeatherApp.WPF_2.Helper;

namespace WeatherApp.WPF_2.ViewModels
{
    public class EnteringPageViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _getCityWeatherCommand;
        public ICommand GetCityWeatherCommand
        {
            get
            {
                return _getCityWeatherCommand ?? (_getCityWeatherCommand = new RelayCommand(x =>
                {
                    Mediator.Notify("GetCityWeatherScreen", "");
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
                OnPropertyChanged(TownName);
            }
        }
    }    
}
