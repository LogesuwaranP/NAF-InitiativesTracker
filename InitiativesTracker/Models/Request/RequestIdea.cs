namespace InitiativesTracker.Models.Request
{
    public class RequestIdea
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Short_Description { get; set; }
        public string? Long_Description { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
        public string Contributor { get; set; }

    }
}
