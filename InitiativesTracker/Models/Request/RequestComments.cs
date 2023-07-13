namespace InitiativesTracker.Models.Request
{
    public class RequestComments
    {
        public string Comment { get; set; }
        public int UserId { get; set; } = 1;
    }
}
