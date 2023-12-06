using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;

namespace Services.CMS
{
    public class BlogService
    {

        private readonly DatabaseContext _ctx;

        public BlogService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _blogs = ctx.Blogs;
        }

        private readonly DbSet<Blog> _blogs;

        public async Task<IEnumerable<BlogDTO>> GetBlogs()
        {
            List<Blog> blogs = await _blogs.ToListAsync();
            List<BlogDTO> convertedBlogs = new();

            foreach (var blog in blogs)
            {
                BlogDTO b = new()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Text = blog.Text,
                    ImageLink = blog.ImageLink,
                };
                convertedBlogs.Add(b);
            }

            return convertedBlogs;
        }

        public async Task<BlogDTO> CreateBlog(BlogDTO newBlog)
        {
            _blogs.Add(new Blog(newBlog.Title, newBlog.Text, newBlog.ImageLink));
            await _ctx.SaveChangesAsync();

            return newBlog;
        }

        public async Task<BlogDTO> UpdateBlog(BlogDTO updatedBlog)
        {
            Blog blog = await _blogs.FindAsync(updatedBlog.Id);
            blog.UpdateBlog(updatedBlog.Title, updatedBlog.Text, updatedBlog.ImageLink);
            _blogs.Update(blog);
            await _ctx.SaveChangesAsync();

            return updatedBlog;
        }

        public async Task DeleteBlog(BlogDTO blogd)
        {
            Blog blog = await _blogs.FindAsync(blogd.Id);
            _blogs.Remove(blog);
            await _ctx.SaveChangesAsync();
        }
    }
}