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
                new Movie(){
                    Title="Spider-Man: Far from Home", 
                    ReleaseDate = new DateTime(2019, 7, 2), 
                    Poster = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
                new Movie(){
                    Title="Moana", 
                    ReleaseDate = new DateTime(2016, 11, 23), 
                    Poster="https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
                new Movie(){
                    Title="Inception", 
                    ReleaseDate = new DateTime(2020, 7, 16),
                    Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                }
            };
        }
    }
}
