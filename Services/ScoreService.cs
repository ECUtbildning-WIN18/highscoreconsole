using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HighscoreConsole.Entities;

namespace HighscoreConsole.Services
{
    public class ScoreService
    {   
        private readonly HttpClient _httpClient;

        public ScoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       public async Task<IEnumerable<Score>> GetHighscoresAsync()
       {
           // /api/scores
           var response = await _httpClient.GetAsync("scores");

            var highscores = Enumerable.Empty<Score>();

            if (response.IsSuccessStatusCode)
            {
                highscores = await response.Content.ReadAsAsync<IEnumerable<Score>>();
            }

           return highscores;
       }

        public async Task<Score> DeleteHighscoreAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"scores/{id}");

            Score score;
            if (response.IsSuccessStatusCode)
            {
                score = await response.Content.ReadAsAsync<Score>();
                return score;
            }

            score = null;
            return score;
        }
   }
}