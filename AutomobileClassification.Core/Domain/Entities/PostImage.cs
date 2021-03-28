namespace AutomobileClassification.Core.Domain.Entities
{
    public partial class PostImage
    {
        public int Id {get; set;}
        public string Image {get; set;}
        public string CategoryLabel {get; set;}
        public int PostId {get; set;}
        public bool IsTrained {get; set;}
    }
}