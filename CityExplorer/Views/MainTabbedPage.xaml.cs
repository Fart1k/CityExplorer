using CityExplorer.Resources.Strings;
using CityExplorer.Services;

namespace CityExplorer.Views
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            UpdateTitles();
            LocalizationService.LanguageChanged += UpdateTitles;
        }

        private void UpdateTitles()
        {
            Children[0].Title = AppResources.ExloreNav;
            Children[1].Title = AppResources.Favorites;
            Children[2].Title = AppResources.Settings;
        }
    }
}
