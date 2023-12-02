using BlazorApp.Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;

namespace Services.CMS
{
    public class CMSBlogService
    {
        private readonly DatabaseContext _ctx;

        public CMSBlogService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _blogs = ctx.Blogs;
        }

        private readonly DbSet<BlogDTO> _blogs;

        public async Task<(IEnumerable<BlogDTO> blogs, int totalPages)> GetBlogs(int page = 1, int pageSize = 5)
        {
            var totalCount = _blogs.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var blogsPerPage = await _blogs
                .OrderByDescending(blog => blog.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (blogsPerPage, totalPages);
            //return await _blogs.ToListAsync(); // zonder pagination
        }
        public async Task<BlogDTO> GetBlog(int BlogId)
        {
            var blog = await _blogs.FindAsync(BlogId);

            BlogDTO dto = new()
            {
               Id = blog.Id,
               ImageLink = blog.ImageLink,
               Text = blog.Text,
               Title = blog.Title
            };

            return dto;
        }
        public async Task<BlogDTO> CreateBlog(BlogDTO newBlog)
        {
            _blogs.Add(newBlog);
            await _ctx.SaveChangesAsync();

            return newBlog;
        }

        public async Task<BlogDTO> UpdateBlog(BlogDTO updatedBlog)
        {
            _blogs.Update(updatedBlog);
            await _ctx.SaveChangesAsync();

            return updatedBlog;
        }

        public async Task DeleteBlog(BlogDTO blogToDelete)
        {
            _blogs.Remove(blogToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}