using CityExplorer.Models;
using CityExplorer.Resources.Strings;
using CityExplorer.Services;
using CityExplorer.ViewModels;
using System.Timers;

namespace CityExplorer.Views;

public partial class ExplorePage : ContentPage
{
	private readonly DatabaseService _databaseService;
	private ExploreViewModel vm;
	public ExplorePage()
	{
		vm = new ExploreViewModel();
		InitializeComponent();
		BindingContext = vm;

		_databaseService = new DatabaseService();
	}

	private async void PlaceTapped(object sender, TappedEventArgs e)
	{
		var frame = sender as Frame;

		var place = frame?.BindingContext as Place;

		if (place == null) return;

		bool add = await DisplayAlertAsync(place.Name, place.Description, AppResources.AddToFavorites, AppResources.Close);

		if (add)
		{
			await _databaseService.AddFavoriteAsync(place);

			await DisplayAlertAsync(AppResources.SuccessText, $"{place.Name} {AppResources.AddedToFavorites}", AppResources.Ok );
		}
	}

	private void All_Clicked(object sender, EventArgs e)
	{
		vm.FilterPlace("all");
	}
    private void History_Clicked(object sender, EventArgs e)
    {
        vm.FilterPlace("history");
    }

    private void Park_Clicked(object sender, EventArgs e)
    {
        vm.FilterPlace("park");
    }

    private void Food_Clicked(object sender, EventArgs e)
    {
        vm.FilterPlace("food");
    }
}