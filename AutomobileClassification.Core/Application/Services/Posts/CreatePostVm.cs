using System;
using Microsoft.AspNetCore.Http;

namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class CreatePostVm
    {
        public IFormFile Image {get; set;}
        public string Title {get; set;}
        public string Url {get; set;}
        public int CategoryId {get; set;}
        public int UserId {get; set;}
        public string? ImageName {get; set;}
    }
}