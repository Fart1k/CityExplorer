using CityExplorer.Models;
using CityExplorer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CityExplorer.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Place> Favorites { get; set; }

        public FavoritesViewModel( DatabaseService databaseService)
        {
            _databaseService = databaseService;

            Favorites = new ObservableCollection<Place>();
        }

        public async Task LoadFavoritesAsync()
        {
            Favorites.Clear();

            var places = await _databaseService.GetFavoritesAsync();

            foreach (var place in places)
            {
                Favorites.Add(place);
            }
        }

        public async Task DeleteFavoriteAsync(Place place)
        {
            await _databaseService.DeleteFavoriteAsync(place);
            Favorites.Remove(place);
        }
    }
}
