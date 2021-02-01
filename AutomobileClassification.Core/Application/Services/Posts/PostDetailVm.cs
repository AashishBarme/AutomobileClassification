using System.Collections.Generic;
using AutomobileClassification.Core.Domain.Entities;

namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class PostDetailVm
    {
        public string Title {get; set;}
        public string Url {get; set;}
        public string Image {get; set;}
        public List<PostCommentVm> Comments {get; set;}
        public string Category {get; set;}
        public string Model {get; set;}
        public int TotalLikes {get; set;}

    }

    public class PostCommentVm
    {
        public string Comment{get; set;}
        public string Username {get; set;}

    }
    
}