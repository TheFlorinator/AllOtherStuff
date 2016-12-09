using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBlogToEndAllBlogs.Models;
using System.Data.SqlClient;

namespace TheBlogToEndAllBlogs.Data
{
    public class WarehouseOfStorage : IRepository
    {
        public void Delete(int id)
        {
            string deleteCommand = "delete from Posts where PostId = @postId";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = cn;
                    comm.CommandText = deleteCommand;
                    comm.Parameters.AddWithValue("@postId", id);
                    cn.Open();
                    comm.ExecuteNonQuery();
                }
            }
        }

        public bool DoesExsist(int blogId)
        {
            throw new NotImplementedException();
        }

        public void SaveTag(Tag tag)
        {
            string saveCommand = "insert into HashTags HashTag values @hashTag";
            string editCommand = "update HashTags set HashTag = @hashTag where HashTagId = @hashTagId";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                if (tag.TagId <= 0)
                {
                    cn.Query<Tag>(saveCommand, new { hashTag = tag.HashTag });
                }
                else
                {
                    cn.Query<Tag>(editCommand, new { hashTag = tag.HashTag, hashTagId = tag.TagId });
                }
            }
        }

        public IEnumerable<Tag> GetAllTags()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Tag>("select HashTagId, HashTag from HashTags");
            }
        }

        public IEnumerable<Post> GetFive()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                //not mapping tags to the list of tags in the post object
                var fivePosts = cn.Query<Post>("select top (5) Posts.PostId, Title, [Image], Author, Content, Published, PostDate, EndDate, [Description], HashTags.HashTag, HashTags.HashTagId from Posts full outer join PostHashTags on PostHashTags.PostId = Posts.PostId full outer join HashTags on HashTags.HashTagId = PostHashTags.HashTagId order by PostDate desc").ToList();
                return fivePosts.Skip(1);
            }
        }

        public Post GetOne(int id)
        {
            string getCommand = "Select PostId, Title, [Image], Author, Content, Published, PostDate, EndDate, [Description] from Posts where PostId = @postId";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                return cn.Query<Post>(getCommand, new { postId = id }).FirstOrDefault();
            }
        }

        public Post GetRecent()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var recentPost = cn.Query<Post>("select top (1) PostId, Title, [Image], Author, Content, Published, PostDate, EndDate, [Description] from Posts order by PostDate desc").ToList();
                return recentPost.FirstOrDefault();
            }
        }

        public void Save(Post post)
        {
            string saveCommand = "insert into Posts Title, [Image], Author, Content, Published, PostDate, EndDate, [Description] values @title, @image, @author, @content, @published, @postDate, @endDate, @description";
            string editCommand = "update Posts set Title = @title, [Image] = @image, Author = @author, Content = @content, Published = @published, PostDate = @postdate, EndDate = @endDate, [Description] = @description where PostId = @postId";
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                if (post.PostId <= 0)
                {
                   cn.Query<Post>(saveCommand, new { title = post.Title, image = post.Image, author = post.Author, content = post.Content, published = post.Published, postDate = post.PostDate, endDate = post.EndDate, description = post.Description });
                }
                else
                {
                    cn.Query<Post>(editCommand, new { title = post.Title, image = post.Image, author = post.Author, content = post.Content, published = post.Published, postDate = post.PostDate, endDate = post.EndDate, description = post.Description, postId = post.PostId });
                }
            }
        }

        public IEnumerable<Post> Search(int hashTagId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetUnpublishedPosts()
        {
            throw new NotImplementedException();
        }
    }
}
