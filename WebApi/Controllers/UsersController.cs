using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutomobileClassification.Core.Domain.Entities;
using AutomobileClassification.Core.Application.Common.Exceptions;
using AutomobileClassification.Core.Infrastructure.Persistence;
using AutomobileClassification.Core.Application.Services.Users;
using AutomobileClassification.Core.Application.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Data;
using AutomobileClassification.Core.Application.Common.Interface;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUsersService _userService;

        public UsersController(AppDbContext context, IUsersService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<long>> PostUser(CreateUserDto entity)
        {
            try
            {
                return await _userService.Create(entity);
            }
            catch (ValidationException)
            {
                return BadRequest("Not Valid");
            }
            catch (DuplicateNameException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateUser(long id, User request)
        {
            if (request.Id != id)
            {
                return BadRequest();
            }
            try
            {
                await _userService.Update(request);
            }
            catch (ValidationException)
            {
                return BadRequest(JsonSerializer.Serialize("Not Valid"));
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();

        }

        [Route("/api/users/password/")]
        [HttpPost]
        public async Task<ActionResult<int>> UpdateUserPassword(UserUpdatePassword dto)
        {
            try
            {
                await _userService.ChangePassword(dto);
                return 204;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            try
            {
                return await _userService.Get(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}