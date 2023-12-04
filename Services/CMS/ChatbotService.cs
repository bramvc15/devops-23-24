using Microsoft.EntityFrameworkCore;
using Shared.DTO.CMS;
using Persistence.Data;
using Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Services.CMS
{
    public class ChatbotService
    {
        private readonly DatabaseContext _ctx;

        public ChatbotService(DatabaseContext ctx)
        {
            _ctx = ctx;
            _chat = ctx.ChatBotQuestions;
        }

        private readonly DbSet<ChatBotQuestion> _chat;

        public async Task<IEnumerable<ChatBotQuestionDTO>> GetContent()
        {
            return (IEnumerable<ChatBotQuestionDTO>)await _chat.Include(question => question.FollowUpQuestions).ToListAsync();
        }

        // public IEnumerable<ChatBotQuestion> GetFollowUpQuestions(int? followUpID)
        // {
        //     return _ctx.ChatBotQuestions.Where(question => question.FollowUpID == followUpID).ToList();
        // }

        public async Task<ChatBotQuestionDTO> AddQuestion(ChatBotQuestionDTO question)
        {
            List<ChatBotQuestion> list = new();
            if (question.FollowUpQuestions != null)
            {
                foreach (var followUpQuestions in question.FollowUpQuestions)
                {
                    ChatBotQuestion question = new(followUpQuestions.Question, followUpQuestions.Answer, followUpQuestions.IsFollowUp, followUpQuestions.FollowUpQuestions);
                    list.Add(followUpQuestions);
                }
            }

            _chat.Add(new ChatBotQuestion(question.Question, question.Answer, question.IsFollowUp, question.FollowUpQuestions));
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