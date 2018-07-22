using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Services
{
    public class SettingsService
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string Uri
        {
            get => AppSettings.GetValueOrDefault(nameof(Uri), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Uri), value);
        }

        public static string ApiKey
        {
            get => AppSettings.GetValueOrDefault(nameof(ApiKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ApiKey), value);
        }

        public static string Units
        {
            get => AppSettings.GetValueOrDefault(nameof(Units), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Units), value);
        }
    }
}
