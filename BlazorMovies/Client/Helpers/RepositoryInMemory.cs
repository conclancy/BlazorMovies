using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        /// <summary>
        /// Dummy data for development of class
        /// </summary>
        /// <returns>A list of movies in dummy form</returns>
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){Title="Spider-Man: Far from Home", ReleaseDate = new DateTime(2019, 7, 2)},
                new Movie(){Title="Moana", ReleaseDate = new DateTime(2016, 11, 23)},
                new Movie(){Title="Inception", ReleaseDate = new DateTime(2020, 7, 16)}
            };
        }
    }
}
