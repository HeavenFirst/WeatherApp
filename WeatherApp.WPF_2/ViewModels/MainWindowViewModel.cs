using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void OnGo1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGo2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }

        private void GoToCityEnteringScreen(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        private void GoToDetailsScreen(object obj)
        {
            ChangeViewModel(PageViewModels[4]);
        }

        private void GoToDetails2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[5]);
        }

        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new UserControl1ViewModel());
            PageViewModels.Add(new UserControl2ViewModel());

            CurrentPageViewModel = PageViewModels[1]; //   <------ <-------- START PAGE !!!!!!! <----------- <---------- <-------

            Mediator.Subscribe("GoTo1Screen", OnGo1Screen);
            Mediator.Subscribe("GoTo2Screen", OnGo2Screen);
            Mediator.Subscribe("GoToCityEnteringScreen", GoToCityEnteringScreen);
            Mediator.Subscribe("GoToDetailsScreen", GoToDetailsScreen);
            Mediator.Subscribe("GoToDetails2Screen", GoToDetails2Screen);
        }
    }
}
