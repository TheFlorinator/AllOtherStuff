using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TheBlogToEndAllBlogs.Logic;
using TheBlogToEndAllBlogs.Models;

namespace TheBlogToEndAllBlogs.Tests
{
    [TestFixture]
    public class MockedTests
    {
        [Test]
        public void CanGetTopFive()
        {
            Rules rules = new Rules();
            var response = rules.GetTopFive();
            Assert.AreEqual(4, response.Post.Count());
        }

        [Test]
        public void CanGetMostRecent()
        {
            Rules rules = new Rules();
            var response = rules.GetMostRecent();
            Assert.AreEqual(5, response.Post.PostId);
        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(25, false)]
        [TestCase(-15, false)]
        public void CanGetOnePost(int id, bool expectedResults)
        {
            Rules rules = new Rules();
            var response = rules.GetOnePost(id);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, true)]
        [TestCase(5, true)]
        [TestCase(10, false)]
        [TestCase(-25, false)]
        public void CanSearchByHashTag(int id, bool expectedResults)
        {
            Rules rules = new Rules();
            var response = rules.SearchByHashTag(id);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, 2)]
        [TestCase(2, 5)]
        [TestCase(3, 4)]
        [TestCase(4, 1)]
        public void CanFindMultiplePostsByHashTag(int id, int numberOfPosts)
        {
            Rules rules = new Rules();
            var response = rules.SearchByHashTag(id);
            Assert.AreEqual(response.Post.Count, numberOfPosts);
        }

        [TestCase("Delicous Food", "Jason Florin", "This is the description", "This is the content", true)]
        [TestCase("", "Jason Florin", "This is the description", "This is the content", false)]
        [TestCase("Delicous Food", "", "This is the description", "This is the content", false)]
        [TestCase("Delicous Food", "Jason Florin", "", "This is the content", false)]
        [TestCase("Delicous Food", "Jason Florin", "This is the description", "", false)]
        public void CanAddPost(string name, string author, string description, string content, bool expectedResults)
        {
            Post post = new Post()
            {
                Title = name,
                Author = author,
                Description = description,
                Content = content
            };
            Rules rules = new Rules();
            var response = rules.AddPost(post);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, "Kudia", "Description", "Jason Florin", "Content", true)]
        [TestCase(2, "Kudia", "Description", "Jason Florin", "", false)]
        [TestCase(3, "Kudia", "", "Jason Florin", "Content", false)]
        [TestCase(-4, "Kudia", "Description", "Jason Florin", "Content", false)]
        public void CanEditPost(int id, string name, string description, string author, string content, bool expectedResults)
        {
            Post post = new Post()
            {
                PostId = id,
                Title = name,
                Description = description,
                Author = author,
                Content = content
            };
            Rules rules = new Rules();
            var response = rules.EditPost(post);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(-59, false)]
        [TestCase(-5563, false)]
        public void CanDeletePost(int id, bool expectedResults)
        {
            Rules rules = new Rules();
            var response = rules.DeletePost(id);
            Assert.AreEqual(response.Success, expectedResults);
        }

        [Test]
        public void CanGetAllTags()
        {
            Rules rules = new Rules();
            var response = rules.GetAllTags();
            Assert.AreEqual(6, response.Count);
        }

        [TestCase(1, "A Tag", true)]
        [TestCase(6, "Another tag", true)]
        [TestCase(1, "", false)]
        [TestCase(-24, "A Tag", false)]
        public void CanEditTag(int id, string name, bool expectedResults)
        {
            Tag tag = new Tag();
            tag.HashTag = name;
            tag.TagId = id;
            Rules rules = new Rules();
            var response = rules.SaveTag(tag);
            Assert.AreEqual(response.Success, expectedResults);
            
        }
    }
}
