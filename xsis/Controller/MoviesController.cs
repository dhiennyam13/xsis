using Microsoft.AspNetCore.Mvc;
using xsis.Data;

namespace xsis.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly List<Movie> _movies = new List<Movie>();

        //get all
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _movies;
        }

        //get id
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        //post
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _movies.Add(movie);
            return Ok(movie);
        }

        //patch
        [HttpPatch("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;

            return Ok(existingMovie);
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _movies.Remove(movie);
            return NoContent();
        }
    }

}
