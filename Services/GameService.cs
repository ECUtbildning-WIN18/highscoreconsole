using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HighscoreConsole.Entities;

namespace HighscoreConsole.Services
{
    public class GameService
    {
        private readonly HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            var response = await _httpClient.GetAsync("games");

            var games = Enumerable.Empty<Game>();

            if (response.IsSuccessStatusCode)
            {
                games = await response.Content.ReadAsAsync<IEnumerable<Game>>();
            }

            return games;
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"games/{id}");

            Game game = null;

            if (response.IsSuccessStatusCode)
            {
                game = await response.Content.ReadAsAsync<Game>();
            }

            return game;
        }
        public async Task<Game> PostGameAsync(Game game = null)
        {
            
            var response = await _httpClient.PostAsJsonAsync("games", game);

            
            return game;


        }
        public async Task<Game> PutGameAsync(int id,Game game = null)
        {

            var response = await _httpClient.PutAsJsonAsync($"games/{id}/", game);

            return game;


        }
        public async Task<Game> DeleteGameAsync(int id)
        {

            Game game = null;

            var response = await _httpClient.DeleteAsync($"games/{id}");

            if (response.IsSuccessStatusCode)
            {
                return new Game();
            }
            return null;
        }
    }
}