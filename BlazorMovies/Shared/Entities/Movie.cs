using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMovies.Shared.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Reequired] public string  Title { get; set; }
        public string Summary { get; set; }
        public bool InTheaters { get; set; }
        public string Trailer { get; set; }
        [Reequired] public DateTime? ReleaseDate { get; set; }
        public string Poster { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set; } = new List<MoviesGenres>();
        public string TitleBrief
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}
