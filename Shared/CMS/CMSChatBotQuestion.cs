namespace Shared.CMS;

public class CMSChatBotQuestion
{
    public int? Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public bool? IsFollowUp { get; set; }
    public List<CMSChatBotQuestion>? FollowUpQuestions { get; set; }
}