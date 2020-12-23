using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTO;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        // Fields
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;

        // Constructor 
        public MoviesController(ApplicationDbContext context, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<IndexPageDTO>> Get()
        {
            // Fields 
            int limit = 6;
            DateTime todaysDate = DateTime.Today;
            IndexPageDTO response = new IndexPageDTO();

            List<Movie> moviesInTheaters = await context.Movies
                .Where(x => x.InTheaters)
                .Take(limit)
                .OrderByDescending(x => x.ReleaseDate)
                .ToListAsync();

            List<Movie> upcomingReleases = await context.Movies
                .Where(x => x.ReleaseDate > todaysDate)
                .OrderBy(x => x.ReleaseDate)
                .Take(limit)
                .ToListAsync();

            response.InTheaters = moviesInTheaters;
            response.UpcomingReleases = upcomingReleases;

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsMovieDTO>> Get(int id)
        {
            Movie movie = await context.Movies.Where(x => x.Id == id)
                .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MoviesActors).ThenInclude(x => x.Person)
                .FirstOrDefaultAsync();

            // returns a 404
            if(movie == null) { return NotFound(); }

            movie.MoviesActors = movie.MoviesActors.OrderBy(x => x.Order).ToList();

            DetailsMovieDTO model = new DetailsMovieDTO();
            model.Movie = movie;
            model.Genres = movie.MoviesGenres.Select(x => x.Genre).ToList();
            model.Actors = movie.MoviesActors.Select(x => 
                new Person
                {
                    Name = x.Person.Name,
                    Picture = x.Person.Picture,
                    Character = x.Character,
                    Id = x.PersonId
                }
            ).ToList();

            return model;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {

            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var personPicture = Convert.FromBase64String(movie.Poster);
                movie.Poster = await fileStorageService.SaveFile(personPicture, "jpg", "movies");
            }

            if(movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }
    }
}