using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Services.CMS
{
    public class CMSChatbotService
    {
        private readonly DatabaseContext _ctx;

        public CMSChatbotService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<CMSChatBotQuestion>> GetContent()
        {
            return await _ctx.ChatBotQuestions.Include(question => question.FollowUpQuestions).ToListAsync();
        }

        // public IEnumerable<ChatBotQuestion> GetFollowUpQuestions(int? followUpID)
        // {
        //     return _ctx.ChatBotQuestions.Where(question => question.FollowUpID == followUpID).ToList();
        // }

        public async Task<CMSChatBotQuestion> AddQuestion(CMSChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Add(question);
            await _ctx.SaveChangesAsync();

            return question;
        }

        public async Task AddFollowUpQuestion(CMSChatBotQuestion parentQuestion, CMSChatBotQuestion question)
        {
            question.IsFollowUp = true;

            if (parentQuestion.FollowUpQuestions == null) parentQuestion.FollowUpQuestions = new List<CMSChatBotQuestion>();

            parentQuestion.FollowUpQuestions.Add(question);
            await EditQuestion(parentQuestion);
        }

        public async Task EditQuestion(CMSChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Update(question);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteQuestion(CMSChatBotQuestion question)
        {
            await RecursiveDelete(question);
            _ctx.ChatBotQuestions.Remove(question);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            CMSChatBotQuestion question = await _ctx.ChatBotQuestions.FindAsync(id);
            await DeleteQuestion(question);
        }

        public async Task RecursiveDelete(CMSChatBotQuestion question)
        {
            if (question.FollowUpQuestions != null)
            {
                foreach (CMSChatBotQuestion followUpQuestion in question.FollowUpQuestions)
                {
                    await RecursiveDelete(followUpQuestion);
                    _ctx.ChatBotQuestions.Remove(followUpQuestion);
                }
            }
        }
    }
}