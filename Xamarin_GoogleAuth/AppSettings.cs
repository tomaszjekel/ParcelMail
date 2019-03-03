using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Xamarin_GoogleAuth
{
    public static class AppSettings
    {
        //Endpoints
        private const string DefaultPersonEndpoint = "https://uinames.com/api";

        private static ISettings Settings => CrossSettings.Current;

        public static string PersonsEndpoint
        {
            get => Settings.GetValueOrDefault(nameof(PersonsEndpoint), DefaultPersonEndpoint);

            set => Settings.AddOrUpdateValue(nameof(PersonsEndpoint), value);
        }

    }
}
