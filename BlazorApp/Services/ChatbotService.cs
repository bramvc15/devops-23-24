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

        public async Task<IEnumerable<ChatBotQuestion>> GetContent()
        {
            return await _ctx.ChatBotQuestions.Include(question => question.FollowUpQuestions).ToListAsync();
        }

        // public IEnumerable<ChatBotQuestion> GetFollowUpQuestions(int? followUpID)
        // {
        //     return _ctx.ChatBotQuestions.Where(question => question.FollowUpID == followUpID).ToList();
        // }
        
        public async Task AddQuestion(ChatBotQuestion question)
        {
            await _ctx.ChatBotQuestions.AddAsync(question);
            await _ctx.SaveChangesAsync();
        }

        public void AddFollowUpQuestion(ChatBotQuestion parentQuestion, ChatBotQuestion question)
        {
            question.IsFollowUp = true;

            if (parentQuestion.FollowUpQuestions == null) parentQuestion.FollowUpQuestions = new List<ChatBotQuestion>();

            parentQuestion.FollowUpQuestions.Add(question);
            _ = EditQuestion(parentQuestion);
        }

        public async Task EditQuestion(ChatBotQuestion question)
        {
            await _ctx.ChatBotQuestions.FindAsync(question);
            await _ctx.SaveChangesAsync();
        }

        public void DeleteQuestion(ChatBotQuestion question)
        {
            RecursiveDelete(question);
            _ctx.ChatBotQuestions.Remove(question);
            _ctx.SaveChanges();
        }

        public async Task DeleteById(int id)
        {
            ChatBotQuestion question = await _ctx.ChatBotQuestions.FindAsync(id);
            DeleteQuestion(question);
        }

        public void RecursiveDelete(ChatBotQuestion question)
        {
            if (question.FollowUpQuestions != null)
            {
                foreach (ChatBotQuestion followUpQuestion in question.FollowUpQuestions)
                {
                    RecursiveDelete(followUpQuestion);
                    _ctx.ChatBotQuestions.Remove(followUpQuestion);
                }
            }
        }
    }

}