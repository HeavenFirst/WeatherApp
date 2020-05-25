using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.WPF_2.Commands;
using WeatherApp.WPF_2.Helper;

namespace WeatherApp.WPF_2.ViewModels
{
    public class ViewDitailsViewModel : BaseViewModel, IPageViewModel
    {
        string humidityTxt;
        string windSpeed;
        string pressure;
        string rainfall;

        #region Properties
        public string HumidityTxt
        {
            get => humidityTxt;
            set
            {
                humidityTxt = value;
                OnPropertyChanged(HumidityTxt);
            }
        }

        public string WindSpeed
        {
            get => windSpeed;
            set
            {
                windSpeed = value;
                OnPropertyChanged(WindSpeed);
            }
        }

        public string Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                OnPropertyChanged(Pressure);
            }
        }

        public string Rainfall
        {
            get => rainfall;
            set
            {
                rainfall = value;
                OnPropertyChanged(Rainfall);
            }
        }
        #endregion

        public ViewDitailsViewModel()
        {         
        }

        public ViewDitailsViewModel(Rain rain, Wind wind, Clouds clouds, Weather[] weather, Main main)
        {
            if (wind != null)
            {
                WindSpeed = wind.speed.ToString();
                Pressure = main.pressure.ToString();
                HumidityTxt = main.humidity.ToString();
                Rainfall = (rain == null) ? "No rain" : rain._3h.ToString();
            }
        }
        private ICommand _onClickedBack2Command;
        public ICommand OnClickedBack2Command
        {
            get
            {
                return _onClickedBack2Command ?? (_onClickedBack2Command = new RelayCommand(x =>
                {
                    Mediator.Notify("OnClickedBack2Screen", "");
                }));
            }
        }
    }
}
