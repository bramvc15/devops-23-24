using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Shared;

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

        public async Task<IEnumerable<CMSBlog>> GetBlogs()
        {
            return await _blogs.ToListAsync();
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