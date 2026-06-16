using CityExplorer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CityExplorer.ViewModels
{
    public class ExploreViewModel : BaseViewModel
    {
        public ObservableCollection<Place> Places { get; set; }

        private Place selectedPlace;
        public Place SelectedPlace
        {
            get => selectedPlace;
            set => SetProperty(ref selectedPlace, value);
        }

        public ExploreViewModel()
        {
            Places = new ObservableCollection<Place>
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
                    Category = "nature"
                },
                new Place
                {
                    Id = 3,
                    Name = "Seaplane Harbour",
                    Description = "Maritime museum with real submarines",
                    Image = "seaplane.jpg",
                    Category = "museum"
                }
            };
        }
    }
}
