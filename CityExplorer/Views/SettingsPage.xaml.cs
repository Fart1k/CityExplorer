using CityExplorer.Services;
using CityExplorer.ViewModels;

namespace CityExplorer.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

		BindingContext = new SettingsViewModel();
	}

}