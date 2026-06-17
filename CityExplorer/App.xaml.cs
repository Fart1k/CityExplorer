using CityExplorer.Models;
using CityExplorer.Services;
using CityExplorer.Views;

namespace CityExplorer;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new MainTabbedPage();
    }

    protected override async void OnStart()
    {
        base.OnStart();

        LocalizationService.SetLanguage("en");

        var db = new DatabaseService();

        await db.SeedPlacesAsync(new List<Place>
        {
            new Place
            {
                Id = 1,
                Image = "oldtown.jpg",
                Category = "history",
                NameKey = "OldTownName",
                DescriptionKey = "OldTownDesc",
                IsFavorite = false
            },
            new Place
            {
                Id = 2,
                Image = "kadriorg.jpg",
                Category = "park",
                NameKey = "KadriorgName",
                DescriptionKey = "KadriorgDesc",
                IsFavorite = false
            },
            new Place
            {
                Id = 3,
                Image = "seaplane.jpg",
                Category = "food",
                NameKey = "SeaplaneName",
                DescriptionKey = "SeaplaneDesc",
                IsFavorite = false
            }
        });
    }
}