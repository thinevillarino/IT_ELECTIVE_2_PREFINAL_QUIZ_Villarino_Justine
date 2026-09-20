namespace IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Models
{
    public class Comment
    {
        public int ProjectId { get; set; }

        public string Name { get; set; } = "";

        public string Message { get; set; } = "";

        public DateTime DatePosted { get; set; }
    }
}