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

        public async Task<(IEnumerable<BlogDTO> blogs, int totalPages)> GetBlogs(int page = 1, int pageSize = 5)
        {
            var totalCount = _blogs.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var blogsPerPage = await _blogs
                .OrderByDescending(blog => blog.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<BlogDTO> convertedBlogs = new();

            foreach (var blog in blogsPerPage)
            {
                BlogDTO convertedBlog = new()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Text = blog.Text,
                    ImageLink = blog.ImageLink
                };

                convertedBlogs.Add(convertedBlog);
            }

            return (convertedBlogs, totalPages);
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
            Blog blog = new(newBlog.Title, newBlog.Text, newBlog.ImageLink);
            _blogs.Add(blog);
            await _ctx.SaveChangesAsync();
            newBlog.Id = blog.Id;

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

        public async Task DeleteBlog(int blogId)
        {
            Blog blog = await _blogs.FindAsync(blogId);
            _blogs.Remove(blog);
            await _ctx.SaveChangesAsync();
        }
    }
}