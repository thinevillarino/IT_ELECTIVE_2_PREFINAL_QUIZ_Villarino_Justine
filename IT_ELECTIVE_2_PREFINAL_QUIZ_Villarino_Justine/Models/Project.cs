namespace IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Category { get; set; } = "";

        public string Description { get; set; } = "";

        public string GitHubLink { get; set; } = "";

        public string Image { get; set; } = "";

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}