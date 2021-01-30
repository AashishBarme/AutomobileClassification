namespace AutomobileClassification.Core.Domain.Entities
{
    public partial class PostLike
    {
        public int Id {get; set;}
        public int PostId {get; set;}
        public int UserId {get; set;}
    }
}