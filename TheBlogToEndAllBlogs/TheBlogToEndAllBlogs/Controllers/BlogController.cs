using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBlogToEndAllBlogs.Logic;
using TheBlogToEndAllBlogs.Models;

namespace TheBlogToEndAllBlogs.Controllers
{
    public class BlogController : ApiController
    {
        private Rules _rules;

        public BlogController()
        {
            _rules = new Rules();
        }

        [HttpGet]
        public List<Post> All()
        {
            return _rules.GetTopFive().Post;            
        }

        [HttpGet]
        public Post MostRecent()
        {
           return _rules.GetMostRecent().Post;
          

        }

        [HttpGet]
        public List<Post> GetByHash(int id, bool yes)
        {
            return _rules.SearchByHashTag(id).Post;
        }


        public Post Get(int id)
        {
            return _rules.GetOnePost(id).Post;
        }

        public HttpResponseMessage Post(Post post)
        {
            _rules.AddPost(post);

            var response = Request.CreateResponse(HttpStatusCode.Created, post);

            string uri = Url.Link("DefaultApi", new { id = post.PostId });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public HttpResponseMessage Put(Post post)
        {
            _rules.EditPost(post);

            var response = Request.CreateResponse(HttpStatusCode.Created, post);
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
           // _rules.RemovePost(id);

            var response = Request.CreateResponse(HttpStatusCode.Accepted, id);
            return response;
        }

       
    }
}
