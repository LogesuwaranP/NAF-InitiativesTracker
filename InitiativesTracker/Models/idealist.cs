namespace InitiativesTracker.Models
{
    public class IdeaList
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
        public string? Start_Date { get; set; }
        public string? End_Date { get; set; }
        public string? SignOff { get; set; }
        public string? Like { get; set;}
        public int? IsDelete { get; set; } = 0;


    }
}
