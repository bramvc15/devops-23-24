using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class ChatBotQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool? IsFollowUp { get; set; }
        public List<ChatBotQuestion>? FollowUpQuestions { get; set; }
    }
}