namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class CreatePostVm
    {
        public string Image {get; set;}
        public string Title {get; set;}
        public string Url {get; set;}
        public int CategoryId {get; set;}
        public int ModelId {get; set;}
        public int UserId {get; set;}
    }
}