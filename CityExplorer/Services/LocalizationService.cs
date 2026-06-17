using System.Globalization;
using CityExplorer.Resources.Strings;
using CityExplorer.ViewModels;

namespace CityExplorer.Services
{
    public static class LocalizationService
    {
        public static event Action LanguageChanged;

        public static void SetLanguage(string lang)
        {
            var culture = new CultureInfo(lang);

            AppResources.Culture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;

            LanguageChanged?.Invoke();
        }
    }
}
