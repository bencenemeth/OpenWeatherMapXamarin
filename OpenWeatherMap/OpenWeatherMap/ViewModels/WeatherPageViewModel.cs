using OpenWeatherMap.Models;
using OpenWeatherMap.Services;
using OpenWeatherMapTest.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenWeatherMap.ViewModels
{
	public class WeatherPageViewModel : ViewModelBase
	{
        /// <summary>
        /// WeatherData object
        /// </summary>
        private WeatherData _weatherData;
        public WeatherData WeatherData
        {
            get => _weatherData;
            set => SetProperty(ref _weatherData, value);
        }

        /// <summary>
        /// Forecast object
        /// </summary>
        private Forecast _forecast;
        public Forecast Forecast
        {
            get => _forecast;
            set => SetProperty(ref _forecast, value);
        }

        /// <summary>
        /// IsBusy is true while the data is being downloaded
        /// Binded to an activity indicator
        /// </summary>
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<WeatherData> ForecastList { get; set; } = new ObservableCollection<WeatherData>();

        private INavigationService _navigationService;

        public WeatherPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Weather";
            _navigationService = navigationService;
            // True on start
            IsBusy = true;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            // City name from parameter values
            string city = parameters.GetValue<string>("city");
            var service = new OpenWeatherMapService();
            //service.SetCredentials();
            try
            {
                GetWeather(service, city);
                GetForecast(service, city);
                // If nothing returned, go back to previous page
                /*if (WeatherData == null || Forecast == null)
                {
                    IsBusy = false;
                    _navigationService.GoBackAsync();
                }*/
            }
            // TODO: Better exception handling
            catch (Exception e)
            {
                _navigationService.GoBackAsync();
            }
        }

        /// <summary>
        /// Getting weather data for the chosen city
        /// </summary>
        /// <param name="service"></param>
        /// <param name="city"></param>
        private async void GetWeather(OpenWeatherMapService service, string city) => WeatherData = await service.GetWeatherForCityAsync(city);

        /// <summary>
        /// Getting forecast for the chosen city
        /// </summary>
        /// <param name="service"></param>
        /// <param name="city"></param>
        private async void GetForecast(OpenWeatherMapService service, string city)
        {
            Forecast = await service.GetForecastForCityAsync(city);
            if(Forecast.Cnt != 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    ForecastList.Add(Forecast.List[i]);
                }
            }
            // False when call returned
            IsBusy = false;
        }
    }
}
