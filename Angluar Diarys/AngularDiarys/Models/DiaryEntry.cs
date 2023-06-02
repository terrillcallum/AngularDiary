namespace Project1.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }
    }
}
