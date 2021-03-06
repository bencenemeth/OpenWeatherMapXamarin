﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWeatherMap.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// City object
        /// </summary>
        private string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public DelegateCommand NavigateToWeatherPageCommand { get; private set; }

        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            NavigateToWeatherPageCommand = new DelegateCommand(NavigateToWeatherPage);
        }

        /// <summary>
        /// Navigate to weather page with city name as parameter.
        /// </summary>
        private void NavigateToWeatherPage()
        {
            _navigationService.NavigateAsync("WeatherPage", new NavigationParameters
            {
                { "city", City }
            });
        }
    }
}
