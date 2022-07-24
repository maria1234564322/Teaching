namespace InterviewWebApp.Models
{
    public class CreateAnswerModel
    {
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
    }
}