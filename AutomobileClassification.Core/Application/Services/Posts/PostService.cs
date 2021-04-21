using System.Security.AccessControl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Helpers;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using AutomobileClassification.Core.Infrastructure.Persistence;
using AutomobileClassification.Core.Application.Services.CategoriesModels;

namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;
        private readonly ICategoryModelService _categoryModelService;
        public PostService(AppDbContext context, ICategoryModelService categoryModelService)
        {
            _context = context;
            _categoryModelService = categoryModelService;
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
            var checker = _context.PostLikes
                         .Any(x => x.PostId == entity.PostId && x.UserId == entity.UserId);
            if(!checker)
            {            
                entity.Id = 0;
                _context.PostLikes.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            return 0;
        }

        public async Task<int> CreatePost(CreatePostVm entity)
        {
            Post post = new Post();
            post.Id = 0;
            post.Url = SlugHelper.Create(true, entity.Title);
            post.Title = entity.Title;
            post.CategoryId = entity.CategoryId;
            post.UserId = entity.UserId;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            PostImage postImage = new PostImage();
            postImage.Id = 0;
            postImage.IsTrained = false;
            postImage.PostId = post.Id;
            postImage.Image = entity.ImageName;
            postImage.CategoryLabel = _categoryModelService.GetCategoryById(entity.CategoryId);
            _context.PostImages.Add(postImage);
            await _context.SaveChangesAsync();
            
            return post.Id;
        }

        public async Task<PostDetailVm> GetPostByUrl(string url)
        {
            var vm = new PostDetailVm();
            Post post = _context.Posts.Where(x=> x.Url == url)
                                      .AsNoTracking().FirstOrDefault();
            if(post == null)
            {
               throw null;
            }

            vm.Title = post.Title;
            vm.Url = post.Url;
            vm.Image = _context.PostImages.Where(x => x.PostId == post.Id)
                                          .Select(x => x.Image)
                                        .AsNoTracking().FirstOrDefault();
            

            vm.Category = _context.Categories.Where(x => x.Id == post.CategoryId)
                                              .Select(x => x.Title)
                                              .AsNoTracking().FirstOrDefault(); 


            var comments = await _context.PostComments.AsNoTracking().Where(x => x.PostId == post.Id).ToListAsync();
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
            var data = _context.Posts.AsNoTracking()
                .Include(x=>x.CategoryRef)
                .Include(x => x.PostImageRef)
                .Select( x => new PostListDto{
                Id = x.Id,
                Title = x.Title,
                Slug = x.Url,
                Category = x.CategoryRef.Title,
                Image  = x.PostImageRef.Image,
                PostLikeCount = _context.PostLikes
                                      .Where(y => y.PostId == x.Id)
                                      .Count()   
            }).AsNoTracking();

            vm.Posts = await data.OrderByDescending(x =>x.Id).ToListAsync();
            return vm;  
        }
        
         public async Task<PostListVm> GetPostsByCategory(string url)
        {
                PostListVm vm = new PostListVm();
                var q = _context.Posts.AsNoTracking()
                    .Include(x=>x.CategoryRef)
                    .Include(x => x.PostImageRef)
                    .Where(x => x.CategoryRef.Slug == url)
                    .Select( x => new PostListDto{
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Url,
                    Category = x.CategoryRef.Title,
                    Image  = x.PostImageRef.Image,
                    PostLikeCount = _context.PostLikes
                                      .Where(y => y.PostId == x.Id)
                                      .Count()     
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


    }
}