namespace Shared.DTO.CMS;

public class ChatBotQuestionDTO
{
    public int? Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public bool IsFollowUp { get; set; }
    public List<ChatBotQuestionDTO>? FollowUpQuestions { get; set; }
}