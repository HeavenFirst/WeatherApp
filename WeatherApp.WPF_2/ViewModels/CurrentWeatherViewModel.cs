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
                iconImg = CurrentWeatherConst.ImageFullPath + value + CurrentWeatherConst.FileType; 
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
                iconOneImg = CurrentWeatherConst.ImageFullPath + value + CurrentWeatherConst.FileType;
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
                iconTwoImg = CurrentWeatherConst.ImageFullPath + value + CurrentWeatherConst.FileType;
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
            if(Location != null)
            GetWetherInfo();
        }

        public CurrentWeatherViewModel(string location)
        {
            Location = location;    
            if(location != null)
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
                DescriptionTxt = CurrentWeatherConst.DescriptionTxt;
                IconImg = CurrentWeatherConst.IconImg;
                CityTxt = CurrentWeatherConst.CityTxt;
                TemperatureTxt = CurrentWeatherConst.TemperatureTxt;
                DateTxt = CurrentWeatherConst.DateTxt;

                GetForecast();            
        }

        private async void GetForecast()
        {
                DayOneTxt = CurrentWeatherConst.DayOneTxt;
                DateOneTxt = CurrentWeatherConst.DateOneTxt;
                IconOneImg = CurrentWeatherConst.IconOneImg;
                TempOneTxt = CurrentWeatherConst.TempOneTxt;


                DayTwoTxt = CurrentWeatherConst.DayTwoTxt;
                DateTwoTxt = CurrentWeatherConst.DateTwoTxt;
                IconTwoImg = CurrentWeatherConst.IconTwoImg;
                TempTwoTxt = CurrentWeatherConst.TempTwoTxt;        
        }
    }
}
