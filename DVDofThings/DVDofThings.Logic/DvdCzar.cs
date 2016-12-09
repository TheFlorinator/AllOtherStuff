using DVDofThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Logic
{
    public class DvdCzar
    {
        private IRepository _allThingsDvdRepo;

        public DvdCzar()
        {
            _allThingsDvdRepo = DvdCzarFactory.Geneticize();
        }

        public Response<List<Dvd>> GetTheMovies()
        {
            Response<List<Dvd>> response = new Response<List<Dvd>>();
            response.TheDrop = _allThingsDvdRepo.GetAllDvds();
            if (response.TheDrop == null)
            {
                response.Success = false;
                response.Message = "An error has occurred";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public Response<List<Borrower>> GetAllBorrowers()
        {
            Response<List<Borrower>> response = new Response<List<Borrower>>();
            response.TheDrop = _allThingsDvdRepo.GetAllBorrower();
            if (response.TheDrop == null)
            {
                response.Success = false;
                response.Message = "An error has occurred";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public Response<Dvd> AddAMovie(Dvd dvd)
        {
            Response<Dvd> response = new Response<Dvd>();
            if (dvd.Name == null || string.IsNullOrWhiteSpace(dvd.Name))
            {
                response.Success = false;
                response.Message = "A name must be provided";
            }
            else if (dvd.Genre == null || string.IsNullOrWhiteSpace(dvd.Genre))
            {
                response.Success = false;
                response.Message = "A genre must be provided";
            }
            else if (dvd.NumberRating < 0 || dvd.NumberRating > 10)
            {
                response.Success = false;
                response.Message = "A rating must be provided";
            }
            else
            {
                _allThingsDvdRepo.AddMovie(dvd);
                response.Success = true;
            }
            return response;
        }

        public Response<Dvd> DeleteDvd(int id)
        {
            Response<Dvd> response = new Response<Dvd>();
            if (id < 0)
            {
                response.Success = false;
                response.Message = "An error has occurred";
            }
            else if (!_allThingsDvdRepo.DeleteMovie(id))
            {
                response.Success = false;
                response.Message = "An error has occurred";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public Response<Borrower> AddABorrower(Borrower borrower)
        {
            Response<Borrower> response = new Response<Borrower>();
            if (string.IsNullOrWhiteSpace(borrower.Name))
            {
                response.Success = false;
                response.Message = "A name must be provided";
            }
            else
            {
                _allThingsDvdRepo.AddBorrower(borrower);
                response.Success = true;
            }
            return response;
        }
    }
}
