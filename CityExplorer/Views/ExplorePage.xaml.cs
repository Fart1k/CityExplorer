using CityExplorer.ViewModels;
using System.Timers;

namespace CityExplorer.Views;

public partial class ExplorePage : ContentPage
{
	public ExplorePage()
	{
		InitializeComponent();
		BindingContext = new ExploreViewModel();
	}
}