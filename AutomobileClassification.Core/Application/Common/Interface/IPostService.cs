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
         Task<PostDetailVm> GetPostByUrl(string url);
         int GetTotalLikes (int postId);
         Task<List<PostCommentVm>> GetCommentsByPostId(int postId);
         Task<PostListVm> GetPosts();
         Task<int> CreateComment(PostComment entity);
         Task<int> CreateLike(PostLike entity);
         Task<PostListVm> GetPostsByCategory(string url);
         Task<int> SaveImageInDb(PostImage entity);
         
    }
}