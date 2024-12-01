using BlogApi.Models;
using BlogApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/blog
        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var blogs = _blogService.GetAllBlogs();
            return Ok(blogs);
        }

        // GET: api/blog/{id}
        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        // POST: api/blog
        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogModel blog)
        {
            if (blog == null)
                return BadRequest("Invalid blog data.");

            var createdBlog = _blogService.CreateBlog(blog);
            return CreatedAtAction(nameof(GetBlogById), new { id = createdBlog.Id }, createdBlog);
        }

        // PUT: api/blog/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, [FromBody] BlogModel updatedBlog)
        {
            if (updatedBlog == null)
                return BadRequest("Invalid blog data.");

            var existingBlog = _blogService.UpdateBlog(id, updatedBlog);
            if (existingBlog == null)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/blog/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var success = _blogService.DeleteBlog(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
