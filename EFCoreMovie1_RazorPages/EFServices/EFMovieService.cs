using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie1_RazorPages.Interfaces;
using EFCoreMovie1_RazorPages.Models;

namespace EFCoreMovie1_RazorPages.EFServices
{
    public class EFMovieService : IMovieService
    {
        private MovieDBContext MovieDBContext;

        public EFMovieService(MovieDBContext dbc)
        {
           MovieDBContext = dbc;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MovieDBContext.Movies;
        }

        void IMovieService.AddStudio(Studio studio)
        {
            MovieDBContext.Add(studio);
            MovieDBContext.SaveChanges();
        }

        void IMovieService.DeleteStudio(Studio studio)
        {
            MovieDBContext.Remove(studio);
            MovieDBContext.SaveChanges();
        }

        IEnumerable<Movie> IMovieService.GetMovies(string title)
        {
            throw new NotImplementedException();
        }

        Studio IMovieService.GetStudioById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
