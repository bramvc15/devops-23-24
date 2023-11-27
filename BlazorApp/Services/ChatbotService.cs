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

        public async Task AddFollowUpQuestion(ChatBotQuestion parentQuestion, ChatBotQuestion question)
        {
            question.IsFollowUp = true;

            if (parentQuestion.FollowUpQuestions == null) parentQuestion.FollowUpQuestions = new List<ChatBotQuestion>();

            parentQuestion.FollowUpQuestions.Add(question);
            await EditQuestion(parentQuestion);
        }

        public async Task EditQuestion(ChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Update(question);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteQuestion(ChatBotQuestion question)
        {
            RecursiveDelete(question);
            _ctx.ChatBotQuestions.Remove(question);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            ChatBotQuestion question = await _ctx.ChatBotQuestions.FindAsync(id);
            await DeleteQuestion(question);
        }

        public async Task RecursiveDelete(ChatBotQuestion question)
        {
            if (question.FollowUpQuestions != null)
            {
                foreach (ChatBotQuestion followUpQuestion in question.FollowUpQuestions)
                {
                    await RecursiveDelete(followUpQuestion);
                    _ctx.ChatBotQuestions.Remove(followUpQuestion);
                }
            }
        }
    }
}