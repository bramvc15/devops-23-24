namespace Domain;

public class CMSChatBotQuestion
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public bool? IsFollowUp { get; set; }
    public List<CMSChatBotQuestion>? FollowUpQuestions { get; set; }
}