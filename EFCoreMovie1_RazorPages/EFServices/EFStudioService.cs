using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie1_RazorPages.Interfaces;
using EFCoreMovie1_RazorPages.Models;

namespace EFCoreMovie1_RazorPages.EFServices
{
    public class EFStudioService : IStudioService
    {
        private MovieDBContext MovieDBContext;

        public EFStudioService(MovieDBContext dbc)
        {
            MovieDBContext = dbc;
        }
        public IEnumerable<Studio> GetStudios()
        {
            return MovieDBContext.Studios;
        }

        void IStudioService.AddStudio(Studio studio)
        {
            MovieDBContext.Add(studio);
            MovieDBContext.SaveChanges();
        }

        void IStudioService.DeleteStudio(Studio studio)
        {
            MovieDBContext.Remove(studio);
            MovieDBContext.SaveChanges();
        }

        Studio IStudioService.GetStudioById(int id)
        {
            return MovieDBContext.Studios.Find(id);
        }

        IEnumerable<Studio> IStudioService.GetStudios(string name)
        {
            throw new NotImplementedException();
        }
    }
}
