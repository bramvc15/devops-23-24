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
        
        public void AddQuestion(ChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Add(question);
            _ctx.SaveChanges();
        }

        // add follow up question
        public void AddFollowUpQuestion(ChatBotQuestion parentQuestion, ChatBotQuestion question)
        {
            var dbParentQuestion = _ctx.ChatBotQuestions.Find(parentQuestion.Id);
            var followUpID = dbParentQuestion.FollowUpQuestion;
            
            if(followUpID == null)
            {
                followUpID = GetNextFollowUpQuestionID();
                dbParentQuestion.FollowUpQuestion = followUpID;
            }

            question.FollowUpID = followUpID;

            _ctx.ChatBotQuestions.Add(question);
            _ctx.SaveChanges();
        }

        public void EditQuestion(ChatBotQuestion question)
        {
            _ctx.ChatBotQuestions.Update(question);
            _ctx.SaveChanges();
        }

        public int GetNextFollowUpQuestionID()
        {
            int maxFollowUpID = _ctx.ChatBotQuestions.Max(question => question.FollowUpID) ?? 0;
            int nextFollowUpID = maxFollowUpID + 1;
            return nextFollowUpID;
        }
    }

}