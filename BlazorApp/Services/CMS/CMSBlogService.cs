using BlazorApp.Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Reflection.Metadata;

namespace BlazorApp.Services.CMS
{
    public class CMSBlogService
    {
        private readonly DatabaseContext _ctx;

        public CMSBlogService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _blogs = ctx.Blogs;
        }

        private readonly DbSet<CMSBlog> _blogs;

        public async Task<(IEnumerable<CMSBlog> blogs, int totalPages)> GetBlogs(int page = 1, int pageSize = 5)
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
        public async Task<CMSBlog> GetBlog(int BlogId)
        {
            var blog = await _blogs.FindAsync(BlogId);

            CMSBlog dto = new()
            {
               Id = blog.Id,
               ImageLink = blog.ImageLink,
               Text = blog.Text,
               Title = blog.Title
            };

            return dto;
        }
        public async Task<CMSBlog> CreateBlog(CMSBlog newBlog)
        {
            _blogs.Add(newBlog);
            await _ctx.SaveChangesAsync();

            return newBlog;
        }

        public async Task<CMSBlog> UpdateBlog(CMSBlog updatedBlog)
        {
            _blogs.Update(updatedBlog);
            await _ctx.SaveChangesAsync();

            return updatedBlog;
        }

        public async Task DeleteBlog(CMSBlog blogToDelete)
        {
            _blogs.Remove(blogToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}