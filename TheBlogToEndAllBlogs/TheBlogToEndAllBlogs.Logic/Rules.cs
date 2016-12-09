using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBlogToEndAllBlogs.Models;

namespace TheBlogToEndAllBlogs.Logic
{
    public class Rules
    {
        private IRepository _blogRepo;

        public Rules()
        {
            _blogRepo = RulesFactory.Create();
        }

        public Response<List<Post>> GetTopFive()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            response.Post = _blogRepo.GetFive().ToList();
            return response;
        }

        public Response<Post> GetMostRecent()
        {
            Response<Post> response = new Response<Post>();

            response.Post = _blogRepo.GetRecent();
            return response;
        }

        public Response<Post> GetOnePost(int postId)
        {
            Response<Post> response = new Response<Post>();
            if (postId <= 0)
            {
                response.Success = false;
                response.Message = "An error occurred with the post ID";
            }
            else 
            {
                response.Post = _blogRepo.GetOne(postId);
                if (response.Post == null)
                {
                    response.Success = false;
                    response.Message = "An error has occurred";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }

        public Response<List<Post>> SearchByHashTag(int id)
        {
            Response<List<Post>> response = new Response<List<Post>>();
            if (id <= 0)
            {
                response.Success = false;
                response.Message = "Invalid Id";
            }
            else
            {
                response.Post = _blogRepo.Search(id).ToList();
                if (response.Post.Count == 0)
                {
                    response.Success = false;
                    response.Message = "An error has occurred";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }

        public Response<Post> AddPost(Post post)
        {
            Response<Post> response = new Response<Post>();
            if (string.IsNullOrWhiteSpace(post.Content))
            {
                response.Success = false;
                response.Message = "Content must be provided";
            }
            else if (string.IsNullOrWhiteSpace(post.Author) || string.IsNullOrWhiteSpace(post.Title) || string.IsNullOrWhiteSpace(post.Description))
            {
                response.Success = false;

                response.Message = "An author must be provided";
            }
          
            else
            {
                _blogRepo.Save(post);
                if (_blogRepo.DoesExsist(post.PostId))
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }
            }
            return response;
        }

        public Response<Post> EditPost(Post post)
        {
            Response<Post> response = new Response<Post>();
            if (post.PostId <= 0)
            {
                response.Success = false;
                response.Message = "An Error has occurred";
            }
            else if (string.IsNullOrWhiteSpace(post.Author) || string.IsNullOrWhiteSpace(post.Content) || string.IsNullOrWhiteSpace(post.Description) || string.IsNullOrWhiteSpace(post.Title))
            {
                response.Success = false;

                response.Message = "Content must be provided";
            }
           
            else
            {
                _blogRepo.Save(post);
                response.Success = true;
            }
            return response;
        }

        public Response<Post> DeletePost(int id)
        {
            Response<Post> reponse = new Response<Post>();
            if (id <= 0)
            {
                reponse.Success = false;
                reponse.Message = "Invalid Id";
            }
            else
            {
                _blogRepo.Delete(id);
                if (!_blogRepo.DoesExsist(id))
                {
                    reponse.Success = true;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = "An error has occurred";
                }
            }
            return reponse;
        }


        public Response<List<Post>> GetUnpublishedPosts()
        {
            Response<List<Post>> response = new Response<List<Post>>();
            response.Post = _blogRepo.GetUnpublishedPosts().ToList();
            return response;
        }

        public List<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            tags = _blogRepo.GetAllTags().ToList();
            return tags;
        }

        public Response<Tag> SaveTag(Tag tag)
        {
            Response<Tag> response = new Response<Tag>();
            if (string.IsNullOrWhiteSpace(tag.HashTag) || tag.TagId <= 0)
            {
                response.Success = false;
                response.Message = "An erorr has occurred";
            }
            else
            {
                _blogRepo.SaveTag(tag);
                response.Success = true;
            }
            return response;
        }
    }
}
