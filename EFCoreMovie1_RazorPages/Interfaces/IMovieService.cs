using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie1_RazorPages.Models;

namespace EFCoreMovie1_RazorPages.Interfaces
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetMovies();
        public IEnumerable<Movie> GetMovies(string title);
        public void AddStudio(Studio studio);
        public Studio GetStudioById(int id);
        public void DeleteStudio(Studio studio);
    }
}
