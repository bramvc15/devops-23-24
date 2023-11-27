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
        
        public void AddQuestion(ChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Add(question);
            _ctx.SaveChanges();
        }

        public void AddFollowUpQuestion(ChatBotQuestion parentQuestion, ChatBotQuestion question)
        {
            question.IsFollowUp = true;

            if (parentQuestion.FollowUpQuestions == null) parentQuestion.FollowUpQuestions = new List<ChatBotQuestion>();

            parentQuestion.FollowUpQuestions.Add(question);
            EditQuestion(parentQuestion);
        }

        public void EditQuestion(ChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Update(question);
            _ctx.SaveChanges();
        }

        public void DeleteQuestion(ChatBotQuestion question)
        {
            RecursiveDelete(question);
            _ctx.ChatBotQuestions.Remove(question);
            _ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            ChatBotQuestion question = _ctx.ChatBotQuestions.Find(id);
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