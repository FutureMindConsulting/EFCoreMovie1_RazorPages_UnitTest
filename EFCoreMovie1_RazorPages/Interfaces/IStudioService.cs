using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMovie1_RazorPages.Models;

namespace EFCoreMovie1_RazorPages.Interfaces
{
    public interface IStudioService
    {
        public IEnumerable<Studio> GetStudios();
        public IEnumerable<Studio> GetStudios(string name);
        public void AddStudio(Studio studio);
        public Studio GetStudioById(int id);
        public void DeleteStudio(Studio studio);
    }
}
