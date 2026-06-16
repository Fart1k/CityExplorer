using Microsoft.Extensions.DependencyInjection;
using CityExplorer.Views;

namespace CityExplorer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainTabbedPage();
        }

    }
}