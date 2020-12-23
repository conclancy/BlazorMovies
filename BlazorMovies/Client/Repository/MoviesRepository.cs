using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTO;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class MoviesRepository: IMoviesRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/movies";

        public MoviesRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        /// <summary>
        /// Method for creating a Movie GET request to the server
        /// </summary>
        /// <typeparam name="T">Generic Object</typeparam>
        /// <param name="url">url for movies in the server</param>
        /// <returns>Object type requested</returns>
        private async Task<T> Get<T>(string url)
        {
            var response = await httpService.Get<T>(url);
            if (!response.Sucess)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        /// <summary>
        /// Utilize this class' private GET method to request an IndexPageDTO  
        /// </summary>
        /// <returns>IndexPageDTO</returns>
        public async Task<IndexPageDTO> GetIndexPageDTO()
        {
            return await Get<IndexPageDTO>(url);
        }

        /// <summary>
        /// Utilize this class' private GET method to request a Movies Detail DTO
        /// </summary>
        /// <param name="id">MovieId</param>
        /// <returns>DetailsMovieDTO</returns>
        public async Task<DetailsMovieDTO> GetDetailsMovieDTO(int id)
        {
            return await Get<DetailsMovieDTO>($"{url}/{id}");
        }

        public async Task<int> CreateMovie(Movie movie)
        {
            var response = await httpService.Post<Movie, int>(url, movie);
            if (!response.Sucess)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}
