using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class ChatbotService
    {

        private readonly DatabaseContext _ctx;

        public ChatbotService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ChatBotQuestion> GetContent()
        {
            return _ctx.ChatBotQuestions.ToList();
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

        // public void AddBlog(string newTitle, string newText, string newImage)
        // {
        //     if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newText) || string.IsNullOrWhiteSpace(newImage))
        //     {
        //         throw new ArgumentException("Title, text, and image are required for adding a new blog.");
        //     }

        //     // Assuming you have a data context named _ctx, you can add a new blog like this:
        //     var newBlog = new Blog
        //     {
        //         Title = newTitle,
        //         Text = newText,
        //         Image = newImage
        //     };

        //     _ctx.Blogs.Add(newBlog);
        //     _ctx.SaveChanges();
        // }


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