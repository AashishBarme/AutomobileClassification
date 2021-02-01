using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Helpers;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomobileClassification.Core.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IAppDbContext _context;
        public PostService(IAppDbContext context)
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

        public async Task<int> CreatePost(Post entity)
        {
            entity.Id = 0;
            entity.Url = SlugHelper.Create(true, entity.Title);
            _context.Posts.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
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
            vm.TotalLikes = post.LikeCount;


            var category = _context.Categories.Where(x => x.Id == post.CategoryId)
                                              .AsNoTracking().FirstOrDefault();
            vm.Category = category.Title;

            var model = _context.Models.Where(x => x.Id == post.ModelId).AsNoTracking().FirstOrDefault();
            vm.Model = model.Title;  

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

        public Task<List<PostDetailVm>> GetPosts()
        {
            
            throw new System.NotImplementedException();
        }

        public Task<int> SaveImageInDb()
        {
            throw new System.NotImplementedException();
        }
    }
}