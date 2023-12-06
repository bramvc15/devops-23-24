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

        #region Public Methods
        public async Task<IEnumerable<ChatBotQuestionDTO>> GetContent()
        {
            IEnumerable<ChatBotQuestion> chatbotQuestions = await _chat.Include(question => question.FollowUpQuestions).ToListAsync();
            List<ChatBotQuestionDTO> chatbotQuestionsDTO = new List<ChatBotQuestionDTO>();

            foreach (var question in chatbotQuestions)
            {
                ChatBotQuestionDTO questionDTO = MapToDTO(question);
                chatbotQuestionsDTO.Add(questionDTO);
            }

            return chatbotQuestionsDTO;
        }

        public async Task<ChatBotQuestionDTO> AddQuestion(ChatBotQuestionDTO question)
        {
            ChatBotQuestion newQuestion = new(question.Question, question.Answer, question.IsFollowUp, null);

            _chat.Add(newQuestion);
            await _ctx.SaveChangesAsync();

            return question;
        } 

        public async Task AddFollowUpQuestion(ChatBotQuestionDTO parentQuestion, ChatBotQuestionDTO question)
        {
            question.IsFollowUp = true;
            ChatBotQuestion questionObj = await _ctx.ChatBotQuestions.FindAsync(parentQuestion.Id);

            questionObj.AddFollowUpQuestion(new ChatBotQuestion(question.Question, question.Answer, question.IsFollowUp, null));
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteById(int? id)
        {
            ChatBotQuestion question = await _ctx.ChatBotQuestions.FindAsync(id);
            await DeleteQuestion(question);
        }
        #endregion

        #region Private Methods
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

        private ChatBotQuestionDTO MapToDTO(ChatBotQuestion question)
        {
            ChatBotQuestionDTO questionDTO = new ChatBotQuestionDTO
            {
                Id = question.Id,
                Question = question.Question,
                Answer = question.Answer,
                IsFollowUp = question.IsFollowUp,
                FollowUpQuestions = question.FollowUpQuestions.Select(q => MapToDTO(q)).ToList()
            };

            return questionDTO;
        }

        private async Task DeleteQuestion(ChatBotQuestion question)
        {
            await RecursiveDelete(question);
            ChatBotQuestion questionObj = await _ctx.ChatBotQuestions.FindAsync(question.Id);

            _ctx.ChatBotQuestions.Remove(questionObj);
            await _ctx.SaveChangesAsync();
        }
        #endregion
    }
}