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
   }
}