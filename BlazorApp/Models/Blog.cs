using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Blog
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
    }
}