using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace xsis.Data
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Movie>> SearchMoviesByTitle(string title)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/movies?title={title}");

                if (response.IsSuccessStatusCode)
                {
                    var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();
                    return movies ?? new List<Movie>();
                }
                else
                {
                    return new List<Movie>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Movie>();
            }
        }

        public async Task<MovieDetail> GetMovieDetails(int movieId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/movies/{movieId}");

                if (response.IsSuccessStatusCode)
                {
                    var movieDetail = await response.Content.ReadFromJsonAsync<MovieDetail>();
                    return movieDetail ?? new MovieDetail();
                }
                else
                {
                    return new MovieDetail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new MovieDetail();
            }
        }
    }
}
