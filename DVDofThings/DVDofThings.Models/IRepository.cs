using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Models
{
    public interface IRepository
    {
        List<Dvd> GetAllDvds();
        List<Borrower> GetAllBorrower();
        void AddMovie(Dvd newDvd);
        bool DeleteMovie(int id);
        void AddBorrower(Borrower newBorrower);
        bool DeleteBorrower(int id);

    }
}
