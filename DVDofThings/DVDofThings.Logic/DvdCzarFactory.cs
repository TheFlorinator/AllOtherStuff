using DVDofThings.Data;
using DVDofThings.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDofThings.Logic
{
    public class DvdCzarFactory
    {
        public static IRepository Geneticize()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "test":
                    return new DVDRepo();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
