using System.Collections.Generic;
namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class PostListVm
    {
       public IList<PostListDto> Posts {get; set;}
    } 


    public class PostListDto
    {
       public int Id {get; set;}
       public string Title {get; set;}
       public string Slug {get; set;}
       public string Image {get; set;}
       public string Category {get; set;}
       public string Model {get; set;}
       public int PostLikeCount {get; set;}
    }
}