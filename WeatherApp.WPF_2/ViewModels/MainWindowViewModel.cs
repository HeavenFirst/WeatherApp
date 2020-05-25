using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Actions;
using WeatherApp.StaticVariables;
using WeatherApp.WPF_2.Helper;

namespace WeatherApp.WPF_2.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
       

        private void GoToCityEnteringScreen(object obj)
        {
            //ChangeViewModel(PageViewModels[0]);
            CurrentWeatherConst.Location = null;
            CurrentPageViewModel = new EnteringPageViewModel();
        }

        private void GoToDetailsScreen(object obj)
        {
            //ChangeViewModel(PageViewModels[2]);
            CurrentPageViewModel = new ViewDitailsViewModel(DetailsPage.rain, DetailsPage.wind, DetailsPage.clouds, DetailsPage.weather, DetailsPage.main);
        }

        private void GoToDetails2Screen(object obj)
        {
            //ChangeViewModel(PageViewModels[2]);
            CurrentPageViewModel = new ViewDitailsViewModel(DetailsPage.rain2, DetailsPage.wind2, DetailsPage.clouds2, DetailsPage.weather2, DetailsPage.main2);
        }

        private void GetCityWeatherScreen(object obj)
        {
            //ChangeViewModel(PageViewModels[1]/*("Kiyv")*/);
           
            //var currentWeather = new WeatherCore(CurrentWeatherConst.Location);
            //var weatherInfo = /*await */currentWeather.GetWetherInfo();
            CurrentPageViewModel = new CurrentWeatherViewModel(CurrentWeatherConst.Location);
        }

        private void OnClickedBackScreen(object obj)
        {
            //ChangeViewModel(PageViewModels[1]);
            CurrentPageViewModel = new CurrentWeatherViewModel(CurrentWeatherConst.Location);
        }

        private void OnClickedBack2Screen(object obj)
        {
           // ChangeViewModel(PageViewModels[1]);
            CurrentPageViewModel = new CurrentWeatherViewModel(CurrentWeatherConst.Location);
        }

        public MainWindowViewModel()
        {            
            PageViewModels.Add(new EnteringPageViewModel());
            PageViewModels.Add(new CurrentWeatherViewModel(CurrentWeatherConst.Location));
            PageViewModels.Add(new ViewDitailsViewModel(/*DetailsPage.rain, DetailsPage.wind, DetailsPage.clouds, DetailsPage.weather, DetailsPage.main*/));

            CurrentPageViewModel = PageViewModels[0]; 

            Mediator.Subscribe("GoToCityEnteringScreen", GoToCityEnteringScreen);
            Mediator.Subscribe("GoToDetailsScreen", GoToDetailsScreen);
            Mediator.Subscribe("GoToDetails2Screen", GoToDetails2Screen);
            Mediator.Subscribe("GetCityWeatherScreen", GetCityWeatherScreen);
            Mediator.Subscribe("OnClickedBackScreen", OnClickedBackScreen);
            Mediator.Subscribe("OnClickedBack2Screen", OnClickedBack2Screen);
        }
    }
}
