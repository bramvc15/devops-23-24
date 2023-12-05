using Ardalis.GuardClauses;

namespace Domain;

public class Faq : Entity
{
    #region Properties
    private string question;
    private string answer;


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
    #endregion

    #region Constructors
    // Database Constructor
    private Faq() { }

    public Faq(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }
    #endregion

    #region Methods
    public void UpdateFaq(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }
    #endregion
}