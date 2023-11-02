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
            return _ctx.ChatBotQuestions.Where(question => question.FollowUpID == null).ToList();
        }

        public IEnumerable<ChatBotQuestion> GetFollowUpQuestions(int? followUpID)
        {
            return _ctx.ChatBotQuestions.Where(question => question.FollowUpID == followUpID).ToList();
        }
    }

}