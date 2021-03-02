namespace AutomobileClassification.Core.Domain.Entities
{
    public partial class Post
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Url {get; set;}
        public int CategoryId {get; set;}
        public int ModelId {get; set;}
        public int UserId {get; set;}
        public int LikeCount {get; set;}
        public virtual Category CategoryRef {get; set; }
        public virtual Model ModelRef {get; set;}
        public virtual PostImage PostImageRef{get; set;}
    }
}