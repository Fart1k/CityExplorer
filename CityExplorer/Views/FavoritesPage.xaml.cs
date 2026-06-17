using CityExplorer.Models;
using CityExplorer.Services;
using CityExplorer.ViewModels;

namespace CityExplorer.Views;

public partial class FavoritesPage : ContentPage
{
	private FavoritesViewModel vm;
	public FavoritesPage()
	{
		InitializeComponent();

		vm = new FavoritesViewModel(new DatabaseService());

		BindingContext = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await vm.LoadFavoritesAsync();
	}

	private async void RemoveButton_Clicked(object sender, EventArgs e)
	{
		Button btn = sender as Button;

		Place place = btn.BindingContext as Place;

		if (place == null) return;

		await vm.DeleteFavoriteAsync(place);
	}
}