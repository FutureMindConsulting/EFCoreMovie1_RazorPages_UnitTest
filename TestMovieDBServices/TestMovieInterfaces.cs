using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreMovie1_RazorPages.Models;
using EFCoreMovie1_RazorPages.EFServices;
using EFCoreMovie1_RazorPages.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TestMovieDBServices
{
    [TestClass]
    public class TestMovieInterfaces
    {
        static MovieDBContext mdb = new MovieDBContext();
        static IStudioService studioService = new EFStudioService(mdb);
        static IMovieService movieService = new EFMovieService(mdb);


        [TestMethod]
        public void TestCreatingMovieDBContext()
        {
            MovieDBContext mdb = new MovieDBContext();
        }

        [TestMethod]
        public void TestGetMovies()
        {
            IEnumerable<Movie> movies = movieService.GetMovies(); 
        }

        [TestMethod]
        public void TestGetStudios()
        {
            IEnumerable<Studio> studios = studioService.GetStudios();
        }

        [TestMethod]
        public void TestStudioCRUD()
        {
            IEnumerable<Studio> studios = studioService.GetStudios();

            /////////////// 
            //Test creation

            //Arrange
            int nextId = 1;
            if (studios != null)
            {
                nextId = studios.ToList<Studio>().Max<Studio>(s => s.Id) + 1;
            }

            Studio newStudio = new Studio()
                { Id = nextId, 
                  Hqcity = "Some city", 
                  Name = "Some name", 
                  NoOfEmployees = 42 };

            int numberOfStudios = studios.Count<Studio>();
                
            //Act 
            studioService.AddStudio(newStudio);

            //Assert
            Studio newStudioEF = studioService.GetStudioById(newStudio.Id);
            Assert.AreEqual(newStudio, newStudioEF, "Testing AddStudio failed");
            Assert.AreEqual(numberOfStudios + 1, studios.Count<Studio>(), "Testing AddStudio failed regarding number of items");


            ///////////////
            //Test deletion

            //Arrange
            Studio studioToBeDeleted  = studioService.GetStudioById(newStudio.Id);

            //Act
            studioService.DeleteStudio(newStudioEF);

            //Assert
            Studio deletedStudioEF = studioService.GetStudioById(newStudioEF.Id);
            Assert.IsNull(deletedStudioEF, "Testing DeleteStudio failed");
            Assert.AreEqual(numberOfStudios, studios.Count<Studio>(), "Testing DeleteStudio failed regarding number of items");
        }
    }
}
