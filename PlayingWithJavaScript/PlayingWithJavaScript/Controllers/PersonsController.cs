using Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayingWithJavaScript.Controllers
{
    public class PersonsController : ApiController
    {
        PersonDataStore store = new PersonDataStore();

        public IEnumerable<Person> Get()
        {           
            return store.All();
        }
       
        public Person Get(int id)
        {           
            return store.All().FirstOrDefault(i => i.Id == id);
        }

        public HttpResponseMessage Post(Person p)
        {
            p = store.Save(p);
            var response = Request.CreateResponse(HttpStatusCode.Created, p);
            return response;
        }
    }
}
