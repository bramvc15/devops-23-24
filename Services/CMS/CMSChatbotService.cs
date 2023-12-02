using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;

namespace Services.CMS
{
    public class CMSChatbotService
    {
        private readonly DatabaseContext _ctx;

        public CMSChatbotService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ChatBotQuestionDTO>> GetContent()
        {
            return await _ctx.ChatBotQuestions.Include(question => question.FollowUpQuestions).ToListAsync();
        }

        // public IEnumerable<ChatBotQuestion> GetFollowUpQuestions(int? followUpID)
        // {
        //     return _ctx.ChatBotQuestions.Where(question => question.FollowUpID == followUpID).ToList();
        // }

        public async Task<ChatBotQuestionDTO> AddQuestion(ChatBotQuestionDTO question)
        {
            _ctx.ChatBotQuestions.Add(question);
            await _ctx.SaveChangesAsync();

            return question;
        }

        public async Task AddFollowUpQuestion(ChatBotQuestionDTO parentQuestion, ChatBotQuestionDTO question)
        {
            question.IsFollowUp = true;

            if (parentQuestion.FollowUpQuestions == null) parentQuestion.FollowUpQuestions = new List<ChatBotQuestionDTO>();

            parentQuestion.FollowUpQuestions.Add(question);
            await EditQuestion(parentQuestion);
        }

        public async Task EditQuestion(ChatBotQuestionDTO question)
        {
            _ctx.ChatBotQuestions.Update(question);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteQuestion(ChatBotQuestionDTO question)
        {
            await RecursiveDelete(question);
            _ctx.ChatBotQuestions.Remove(question);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            ChatBotQuestionDTO question = await _ctx.ChatBotQuestions.FindAsync(id);
            await DeleteQuestion(question);
        }

        public async Task RecursiveDelete(ChatBotQuestionDTO question)
        {
            if (question.FollowUpQuestions != null)
            {
                foreach (ChatBotQuestionDTO followUpQuestion in question.FollowUpQuestions)
                {
                    await RecursiveDelete(followUpQuestion);
                    _ctx.ChatBotQuestions.Remove(followUpQuestion);
                }
            }
        }
    }
}