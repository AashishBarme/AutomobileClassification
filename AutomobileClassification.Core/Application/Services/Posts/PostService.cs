using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Helpers;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using AutomobileClassification.Core.Infrastructure.Persistence;

namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;
        public PostService(AppDbContext context)
        {
            _context = context;
        } 
        public async Task<int> CreateComment(PostComment entity)
        {
            entity.Id = 0;
            _context.PostComments.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CreateLike(PostLike entity)
        {
            entity.Id = 0;
            _context.PostLikes.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CreatePost(CreatePostVm entity)
        {
            Post post = new Post();
            post.Id = 0;
            post.Url = SlugHelper.Create(true, entity.Title);
            post.Title = entity.Title;
            post.CategoryId = entity.CategoryId;
            post.ModelId = entity.ModelId;
            post.UserId = entity.UserId;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            PostImage postImage = new PostImage();
            postImage.Id = 0;
            postImage.IsTrained = false;
            postImage.PostId = post.Id;
            postImage.Image = entity.Image;
            _context.PostImages.Add(postImage);
            await _context.SaveChangesAsync();
            
            return post.Id;
        }

        public async Task<PostDetailVm> GetPostById(int id)
        {
            var vm = new PostDetailVm();
            Post post = _context.Posts.Where(x=> x.Id == id).AsNoTracking().FirstOrDefault();
            if(post == null)
            {
               throw null;
            }

            vm.Title = post.Title;
            vm.Image = "testImage.jpg";
            vm.Url = post.Url;


            vm.Category = _context.Categories.Where(x => x.Id == post.CategoryId)
                                              .Select(x => x.Title)
                                              .AsNoTracking().FirstOrDefault(); 

            vm.Model = _context.Models.Where(x => x.Id == post.ModelId)
                                      .Select(x => x.Title)
                                      .AsNoTracking().FirstOrDefault();

            var comments = await _context.PostComments.AsNoTracking().Where(x => x.PostId == id).ToListAsync();
            var postComments = new List<PostCommentVm>();
            if(comments.Count > 0)
            {
                foreach (var item in comments)
                {
                    var postCommentVm = new PostCommentVm();
                    postCommentVm.Comment = item.Comment;
                    //TODO:Change UserName
                    postCommentVm.Username = "Test User";
                    postComments.Add(postCommentVm);
                }
            }

            vm.Comments = postComments;
            return vm;
        }

        public async Task<PostListVm> GetPosts()
        {
            PostListVm vm = new PostListVm();
            var q = _context.Posts.AsNoTracking().Select( x => new PostListDto{
                Id = x.Id,
                Title = x.Title,
                Category = GetCategoryNameById(x.CategoryId),
                Model = GetModelNameById(x.ModelId),
                PostLikeCount = x.LikeCount,
                Image  = GetPostImageFromPostId(x.Id)  
            }).AsNoTracking();

            vm.Posts = await q.OrderByDescending(x =>x.Id).ToListAsync();
            return vm;
            
        }
        
        
        public async Task<int> SaveImageInDb(PostImage entity)
        {
            entity.Id = 0;
            entity.IsTrained = false;
            _context.PostImages.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        private string GetCategoryNameById(int categoryId)
        {
            return _context.Categories.Where(x => x.Id == categoryId)
                                       .Select(x => x.Title).FirstOrDefault();
        }

        private string GetModelNameById(int modelId)
        {
            return _context.Models.Where(x => x.Id == modelId)
                                  .Select(x => x.Title).FirstOrDefault();
        }

        private string GetPostImageFromPostId(int postId)
        {
            return _context.PostImages.Where(x=> x.PostId == postId)
                                      .Select(x => x.Image).FirstOrDefault();
        }
    }
}