using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlogToEndAllBlogs.Models
{
    public interface IRepository
    {
        bool DoesExsist(int blogId);
        void Delete(int id);
        void Save(Post post);
        Post GetOne(int id);
        Post GetRecent();
        IEnumerable<Post> Search(int hashTagId);
        IEnumerable<Post> GetFive();
        IEnumerable<Tag> GetAllTags();
        IEnumerable<Post> GetUnpublishedPosts();
        void SaveTag(Tag tag);
    }
}
