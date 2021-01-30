namespace AutomobileClassification.Core.Domain.Entities
{
    public partial class PostComment
    {
        public int Id {get; set;}
        public int PostId {get; set;}
        public string Comment {get; set;}
        public int UserId {get; set;}
    }
}