using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutomobileClassification.Core.Domain.Entities;
using AutomobileClassification.Core.Application.Services.Posts;
using AutomobileClassification.Core.Application.Common.Interface;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postSerice)
        {
            _postService = postSerice;
        }
        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<int>> CreatePost(CreatePostVm entity)
        {
            try
            {
                return await _postService.CreatePost(entity);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }


        
    }
}