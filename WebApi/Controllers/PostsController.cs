using System.IO;
using System;
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using AutomobileClassification.Core.Domain.Entities;
using AutomobileClassification.Core.Application.Services.Posts;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PostsController(IPostService postSerice,
        IWebHostEnvironment hostEnvironment)
        {
            _postService = postSerice;
            _hostEnvironment = hostEnvironment;
        }
        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<int>> CreatePost([FromForm] CreatePostVm entity)
        {
            try
            {
                var a = _hostEnvironment.WebRootPath;
                var file = entity.Image;
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName =  fileName + DateTime.Now.ToString("yymmssff") + extension;
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Uploads",fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await entity.Image.CopyToAsync(fileSteam);
                }
                entity.ImageName = fileName;

                //Create the Directory.
                return await _postService.CreatePost(entity);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

        [Route("/api/posts/like")]
        [HttpPost]
        public async Task<ActionResult<int>> AddPostLike(PostLike entity)
        {
            try
            {
                return await _postService.CreateLike(entity);
            }
            catch(NotFoundException)
            {
                return BadRequest();
            }
        }

        [Route("/api/posts/comments")]
        [HttpPost]
        public async Task<ActionResult<int>> AddPostComments(PostComment entity)
        {
            try
            {
                return await _postService.CreateComment(entity);
            }
            catch(NotFoundException)
            {
                return BadRequest();
            }
        }

        [Route("/api/posts/comments/{postId}")]
        [HttpGet]
        public async Task<ActionResult<List<PostCommentVm>>> GetPostComments(int postId)
        {
            try
            {
                return await _postService.GetCommentsByPostId(postId);
            }catch(NotFoundException)
            {
                return BadRequest();
            }
        }

        [Route("/api/posts/likes/{postId}")]
        [HttpGet]
        public ActionResult<int> GetPostTotalLikes(int postId)
        {
            try
            {
                return  _postService.GetTotalLikes(postId);
            }catch(NotFoundException)
            {
                return BadRequest();
            }
        }


        [Route("/api/posts/list")]
        [HttpGet]
        public async Task<ActionResult<PostListVm>> ListPost()
        {
            try
            {
                 var datas =  await _postService.GetPosts();


                 return datas;
                
            }
            catch(NotFoundException)
            {
                return BadRequest();    
            }
        }

        [Route("/api/posts/details/{url}")]
        [HttpGet]
        public async Task<ActionResult<PostDetailVm>> GetPost(string url)
        {
            try{
                return await _postService.GetPostByUrl(url);
            }
            catch(NotFoundException)
            {
                return BadRequest();
            }
        }

        [Route("/api/posts/category/{url}")]
        [HttpGet]
        public async Task<ActionResult<PostListVm>> ListPostByCategory(string url)
        {
            try
            {
                return await _postService.GetPostsByCategory(url);
            }
            catch(NotFoundException)
            {
                return BadRequest();
            }
        }

        [Route("/api/posts/user/{userId}")]
        [HttpGet]
        public async Task<ActionResult<PostListVm>> ListPostOfUser(int  userId)
        {
            try
            {
                return await _postService.GetPostsByUserId(userId);
            }
            catch(NotFoundException)
            {
                return BadRequest();
            }
        }




        
    }

}