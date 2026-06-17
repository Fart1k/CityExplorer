using CityExplorer.Models;
using CityExplorer.Resources.Strings;
using CityExplorer.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CityExplorer.ViewModels
{
    public class ExploreViewModel : BaseViewModel
    {
        public string Explore => AppResources.Explore;
        public string AllCategory => AppResources.All;
        public string HistoryCategory => AppResources.History;
        public string ParkCatefory => AppResources.Park;
        public string FoodCategory => AppResources.Food;

        public ObservableCollection<Category> Categories { get; set; }
        public ICommand FilterCommand { get; }

        public ObservableCollection<Place> Places { get; set; }
        private List<Place> allPlaces;


        private Place selectedPlace;
        public Place SelectedPlace
        {
            get => selectedPlace;
            set => SetProperty(ref selectedPlace, value);
        }

        public ExploreViewModel()
        {
            LocalizationService.LanguageChanged += OnLanguageChanged;

            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Emoji = "🌍",
                    ResourceKey = AllCategory,
                    Value = "all"
                },
                new Category
                {
                    Emoji = "🏛️",
                    ResourceKey = "History",
                    Value = "history"
                },
                new Category
                {
                    Emoji = "🌳",
                    ResourceKey = "Park",
                    Value = "park"
                },
                new Category
                {
                    Emoji = "🍔",
                    ResourceKey = "Food",
                    Value = "food"
                },
            };

            allPlaces = new List<Place>
            {
                new Place
                {
                    Id = 1,
                    Image = "oldtown.jpg",
                    Category = "history",
                    NameKey = "OldTownName",
                    DescriptionKey = "OldTownDesc"
                },
                new Place
                {
                    Id = 2,
                    Image = "kadriorg.jpg",
                    Category = "park",
                    NameKey = "KadriorgName",
                    DescriptionKey = "KadriorgDesc"
                },
                new Place
                {
                    Id = 3,
                    Image = "seaplane.jpg",
                    Category = "food",
                    NameKey = "SeaplaneName",
                    DescriptionKey = "SeaplaneDesc"
                }
            };


            FilterCommand = new Command<string>(FilterPlace);
            Places = new ObservableCollection<Place>(allPlaces);
        }

        public void FilterPlace(string category)
        {

            Places.Clear();

            var filtered = category == "all" ? allPlaces : allPlaces.Where(p => p.Category == category);

            foreach (var place in filtered)
            {
                Places.Add(place);
            }
        }

        private void OnLanguageChanged()
        {
            OnPropertyChanged(nameof(Explore));
            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(Places));
            

            foreach (var category in Categories)
            {
                category.Refresh();
            }

            ReloadPlaces();
            ReloadCategories();
        }
        private void ReloadPlaces()
        {
            var current = Places.ToList();

            Places.Clear();

            foreach (var p in current)
                Places.Add(p);

            OnPropertyChanged(nameof(Places));
        }

        private void ReloadCategories()
        {
            var current = Categories.ToList();

            Categories.Clear();

            foreach (var c in current)
                Categories.Add(c);

            OnPropertyChanged(nameof(Categories));
        }

    }
}
