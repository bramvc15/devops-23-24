using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class BlogService
    {

        private readonly DatabaseContext _ctx;

        public BlogService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public (IEnumerable<Blog> blogs, int totalPages) GetContent(int page = 1, int pageSize = 5)
        {
            var totalCount = _ctx.Blogs.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var blogsPerPage = _ctx.Blogs
                .OrderByDescending(blog => blog.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (blogsPerPage, totalPages);
            //return _ctx.Blogs.OrderByDescending(blog => blog.Id).ToList();
        }

        public Blog? GetBlogById(int id)
        {
            return _ctx.Blogs.Find(id);
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

        public void AddBlog(string newTitle, string newText, string newImage)
        {
            if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newText) || string.IsNullOrWhiteSpace(newImage))
            {
                throw new ArgumentException("Title, text, and image are required for adding a new blog.");
            }

            // Assuming you have a data context named _ctx, you can add a new blog like this:
            var newBlog = new Blog
            {
                Title = newTitle,
                Text = newText,
                Image = newImage
            };

            _ctx.Blogs.Add(newBlog);
            _ctx.SaveChanges();
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