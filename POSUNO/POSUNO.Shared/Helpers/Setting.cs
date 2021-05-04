﻿using Windows.Storage;

namespace POSUNO.Helpers
{
    public class Setting
    {
        private static readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public static string GetApiUrl()
        {
            return (string)_localSettings.Values["ApiUrl"];
        }
    }
}
