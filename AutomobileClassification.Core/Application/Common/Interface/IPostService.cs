using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Services.Posts;
using AutomobileClassification.Core.Domain.Entities;

namespace AutomobileClassification.Core.Application.Common.Interface
{
    public interface IPostService
    {
         Task<int> CreatePost(CreatePostVm entity);
         Task<PostDetailVm> GetPostById(int id);
         Task<PostListVm> GetPosts();
         Task<int> CreateComment(PostComment entity);
         Task<int> CreateLike(PostLike entity);
         Task<int> SaveImageInDb(PostImage entity);
         
    }
}