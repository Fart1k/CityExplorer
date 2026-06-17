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
        public string Title => AppResources.Explore;
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
                    Title = "All",
                    Value = "all"
                },
                new Category
                {
                    Emoji = "🏛️",
                    Title = "History",
                    Value = "history"
                },
                new Category
                {
                    Emoji = "🌳",
                    Title = "Park",
                    Value = "park"
                },
                new Category
                {
                    Emoji = "🍔",
                    Title = "Food",
                    Value = "food"
                },
            };

            allPlaces = new List<Place>
            {
                new Place
                {
                    Id = 1,
                    Name = "Tallinn Old Town",
                    Description = "Historic medieval city center",
                    Image = "oldtown.jpg",
                    Category = "history"
                },
                new Place
                {
                    Id = 2,
                    Name = "Kadriorg Park",
                    Description = "Beautiful green park with palace",
                    Image = "kadriorg.jpg",
                    Category = "park"
                },
                new Place
                {
                    Id = 3,
                    Name = "Seaplane Harbour",
                    Description = "Maritime museum with real submarines",
                    Image = "seaplane.jpg",
                    Category = "food"
                }
            };


            FilterCommand = new Command<string>(FilterPlace);
            Places = new ObservableCollection<Place>(allPlaces);
        }

        public void FilterPlace(string category)
        {
            System.Diagnostics.Debug.WriteLine($"Filter: {category}");

            Places.Clear();

            var filtered = category == "all" ? allPlaces : allPlaces.Where(p => p.Category == category);

            foreach (var place in filtered)
            {
                Places.Add(place);
            }
        }

        private void OnLanguageChanged()
        {
            OnPropertyChanged(nameof(Title));
        }
    }
}
