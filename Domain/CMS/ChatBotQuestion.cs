using Ardalis.GuardClauses;
using Shared.DTO.CMS;
using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Domain;

public class ChatBotQuestion : Entity
{
    #region Properties
    private string question;
    private string answer;
    private bool isFollowUp;
    private List<ChatBotQuestion> followUpQuestions;

    public string Question
    {
        get => question;
        private set => question = Guard.Against.NullOrWhiteSpace(value, nameof(Question));
    }
    public string Answer
    {
        get => answer;
        private set => answer = Guard.Against.NullOrWhiteSpace(value, nameof(Answer));
    }
    public bool IsFollowUp
    {
        get => isFollowUp;
        private set => isFollowUp = Guard.Against.Null(value, nameof(IsFollowUp));
    }
    public List<ChatBotQuestion> FollowUpQuestions
    {
        get => followUpQuestions;
        private set => followUpQuestions = value;
    }
    #endregion

    #region Constructors
    // Database Constructor
    private ChatBotQuestion() { }

    public ChatBotQuestion(string question, string answer, bool isFollowUp, List<ChatBotQuestion>? list = default)
    {
        Question = question;
        Answer = answer;
        IsFollowUp = isFollowUp;
        FollowUpQuestions = list;
    }
    #endregion

    #region Methods
    public void UpdateChatBotQuestion(string question, string answer, bool isFollowUp, List<ChatBotQuestion> list)
    {
        Question = question;
        Answer = answer;
        IsFollowUp = isFollowUp;
        FollowUpQuestions = list;
    }

    public void AddFollowUpQuestion(ChatBotQuestion question)
    {
        if(FollowUpQuestions == null)
            FollowUpQuestions = new List<ChatBotQuestion>();
            
        FollowUpQuestions.Add(question);
    }
    #endregion
}