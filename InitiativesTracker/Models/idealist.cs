namespace InitiativesTracker.Models
{
    public class idealist
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Short_Description { get; set; }
        public string? Long_Description { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
        public string Contributor { get; set; }
        public string? Approved_by { get; set; }
        public int? Age { get; set; }



    }
}
