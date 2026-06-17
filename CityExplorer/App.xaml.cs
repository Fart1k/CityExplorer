using Microsoft.Extensions.DependencyInjection;
using CityExplorer.Views;
using CityExplorer.Services;

namespace CityExplorer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LocalizationService.SetLanguage("en");
            MainPage = new MainTabbedPage();
        }

    }
}