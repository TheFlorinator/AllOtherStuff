using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBlogToEndAllBlogs.Data;
using TheBlogToEndAllBlogs.Models;

namespace TheBlogToEndAllBlogs.Logic
{
    public class RulesFactory
    {
        public static IRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "InMemory":
                    return new InMemoryRepo();
                case "Database":
                    return new WarehouseOfStorage();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
