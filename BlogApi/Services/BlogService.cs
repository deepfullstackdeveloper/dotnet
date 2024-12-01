
using BlogApi.Models;
using Newtonsoft.Json;
using System.IO;

namespace BlogApi.Services
{
    public class BlogService
    {
        private const string DataFilePath = "BlogData/blog.json"; 
        private List<BlogModel> GetBlogsData()
        {
            var fileContent = File.ReadAllText(DataFilePath);
            return JsonConvert.DeserializeObject<List<BlogModel>>(fileContent) ?? new List<BlogModel>();
        }

        private void SaveBlogsData(List<BlogModel> blogs)
        {
            var json = JsonConvert.SerializeObject(blogs, Formatting.Indented);
            File.WriteAllText(DataFilePath, json);
        }

        public List<BlogModel> GetAllBlogs()
        {
            return GetBlogsData();
        }

        public BlogModel GetBlogById(int id)
        {
            var blogs = GetBlogsData();
            return blogs.FirstOrDefault(b => b.Id == id);
        }

        public BlogModel CreateBlog(BlogModel blog)
        {
            var blogs = GetBlogsData();
            blog.Id = blogs.Any() ? blogs.Max(b => b.Id) + 1 : 1; // Generate new ID
            blogs.Add(blog);
            SaveBlogsData(blogs);
            return blog;
        }

        public BlogModel UpdateBlog(int id, BlogModel updatedBlog)
        {
            var blogs = GetBlogsData();
            var existingBlog = blogs.FirstOrDefault(b => b.Id == id);

            if (existingBlog == null)
                return null;

            existingBlog.Username = updatedBlog.Username;
            existingBlog.Text = updatedBlog.Text;
            existingBlog.DateCreated = updatedBlog.DateCreated;

            SaveBlogsData(blogs);
            return existingBlog;
        }

        public bool DeleteBlog(int id)
        {
            var blogs = GetBlogsData();
            var blogToDelete = blogs.FirstOrDefault(b => b.Id == id);

            if (blogToDelete == null)
                return false;

            blogs.Remove(blogToDelete);
            SaveBlogsData(blogs);
            return true;
        }
    }
}
