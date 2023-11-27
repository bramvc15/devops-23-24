using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services.CMS
{
    public class BlogService
    {
        private readonly DatabaseContext _ctx;

        public BlogService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<(IEnumerable<Blog> blogs, int totalPages)> GetContent(int page = 1, int pageSize = 5)
        {
            var totalCount = await _ctx.Blogs.CountAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var blogsPerPage = await _ctx.Blogs
                .OrderByDescending(blog => blog.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (blogsPerPage, totalPages);
            //return _ctx.Blogs.OrderByDescending(blog => blog.Id).ToList();
        }

        public async Task<Blog?> GetBlogById(int id)
        {
            return await _ctx.Blogs.FindAsync(id);
        }
        // public async Task UpdateBlogAsync(int headerId, string newTitle)
        // {
        //     var blogToUpdate = await _ctx.Blogs.FindAsync(Id);

        //     if (blogToUpdate is null)
        //     {
        //         throw new InvalidOperationException("Header does not exist");
        //     }

        //     blogToUpdate.Title = newTitle;
        //     await _ctx.SaveChangesAsync();
        // }

        public async Task AddBlog(string newTitle, string newText, string newImage)
        {
            if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newText) || string.IsNullOrWhiteSpace(newImage))
            {
                throw new ArgumentException("Title, text, and image are required for adding a new blog.");
            }

            var newBlog = new Blog
            {
                Title = newTitle,
                Text = newText,
                Image = newImage
            };

            await _ctx.Blogs.AddAsync(newBlog);
            await _ctx.SaveChangesAsync();
        }

        // public void UpdateBlog(int id, string newTitle, string content)
        // {
        //     var blogToUpdate = _ctx.Blogs.Find(id);


        //     if (blogToUpdate is null)
        //     {
        //         throw new InvalidOperationException("does not exist");
        //     }
        //     if (newTitle != null && content != null)
        //     {
        //         blogToUpdate.Title = newTitle;
        //         blogToUpdate.Text = content;
        //     }

        //     if (newTitle == null && content != null)
        //     {
        //         blogToUpdate.Text = content;
        //     }

        //     if (content == null && newTitle != null)
        //     {
        //         blogToUpdate.Title = newTitle;
        //     }

        //     // headerToUpdate.Title = newTitle;
        //     _ctx.SaveChanges();
        // }
    }
}