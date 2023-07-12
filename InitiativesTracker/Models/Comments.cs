namespace InitiativesTracker.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int Taskid { get; set; }
        public string Owner { get; set; }
        public string? CommentsDateOnly { get; set; } = DateTime.Now.ToString();

        public string? CommentsTimeOnly { get; set; } = DateTime.Now.ToString();

        
    }
}
