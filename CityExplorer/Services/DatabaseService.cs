using CityExplorer.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityExplorer.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection database;

        private async Task InitAsync()
        {
            if (database != null)
                return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "CityExplorer.db3");

            database = new SQLiteAsyncConnection(dbPath);

            await database.CreateTableAsync<Place>();
        }

        public async Task SeedPlacesAsync(List<Place> places)
        {
            await InitAsync();

            var existing = await database.Table<Place>().ToListAsync();

            if (existing.Count == 0)
            {
                await database.InsertAllAsync(places);
            }
        }

        public async Task<List<Place>> GetPlacesAsync()
        {
            await InitAsync();
            return await database.Table<Place>().ToListAsync();
        }


        public async Task<List<Place>> GetFavoritesAsync()
        {
            await InitAsync();

            return await database.Table<Place>()
                .Where(p => p.IsFavorite)
                .ToListAsync();
        }

        public async Task AddFavoriteAsync(Place place)
        {
            await InitAsync();

            place.IsFavorite = true;
            await database.UpdateAsync(place);
        }

        public async Task DeleteFavoriteAsync(Place place)
        {
            await InitAsync();

            place.IsFavorite = false;
            await database.UpdateAsync(place);
        }
    }
}
