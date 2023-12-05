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
            ChatBotQuestion questionObj = await _ctx.ChatBotQuestions.FindAsync(question.Id);

            List<ChatBotQuestion> list = new();
            if (questionObj.FollowUpQuestions != null)
            {
                foreach (var followUpQuestions in questionObj.FollowUpQuestions)
                {
                    ChatBotQuestion newQuestion = new(followUpQuestions.Question, followUpQuestions.Answer, followUpQuestions.IsFollowUp, followUpQuestions.FollowUpQuestions);
                    list.Add(newQuestion);
                }
            }

            _chat.Add(new ChatBotQuestion(questionObj.Question, questionObj.Answer, questionObj.IsFollowUp, questionObj.FollowUpQuestions));
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
            ChatBotQuestion questionObj = await _ctx.ChatBotQuestions.FindAsync(question.Id);
            _ctx.ChatBotQuestions.Update(questionObj);
            await _ctx.SaveChangesAsync();
        }

        private async Task DeleteQuestion(ChatBotQuestion question)
        {
            await RecursiveDelete(question);
            ChatBotQuestion questionObj = await _ctx.ChatBotQuestions.FindAsync(question.Id);

            _ctx.ChatBotQuestions.Remove(questionObj);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            ChatBotQuestion question = await _ctx.ChatBotQuestions.FindAsync(id);
            await DeleteQuestion(question);
        }

        private async Task RecursiveDelete(ChatBotQuestion question)
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