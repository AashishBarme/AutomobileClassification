using System;
using System.Data;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Exceptions;
using AutomobileClassification.Core.Application.Common.Interface;
using AutomobileClassification.Core.Application.ViewModels;
using AutomobileClassification.Core.Domain.Entities;
using AutomobileClassification.Core.Infrastructure.Identity;
using AutomobileClassification.Core.Infrastructure.Persistence;

namespace AutomobileClassification.Core.Application.Services.Users
{
    public class UsersService :  IUsersService
    {
        
        private AppDbContext _context;
        private readonly IdentityService _userManager;

        public UsersService(IdentityService userManager, AppDbContext ctx)
        {
            _userManager = userManager;
            _context = ctx;
        }

        public async Task ChangePassword(UserUpdatePassword dto)
        {
            Console.WriteLine(dto);
            var user = await _userManager.GetUserById(dto.Id);
            if (user == null)
            {
                throw new NotFoundException();
            }
            await _userManager.UpdatePasswordAsync(user, dto.Password);
        }

        public async Task<long> Create(CreateUserDto entity)
        {
            try
            {

                var user = new User
                {
                    UserName = entity.UserName,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                };
                var id = await _userManager.CreateUserAsync(user, entity.Password);
                return id;
            }
            catch (DuplicateNameException e)
            {
                throw e;
            }


        }

        public async Task<bool> Delete(long id)
        {
            var user = await _userManager.GetUserById(id);
            if (user.Id != id)
            {
                throw new NotFoundException();
            }
            return await _userManager.DeleteUserAsync(id); ;
        }

        public async Task<User> Get(long id)
        {
            return await _userManager.GetUserById(id);
        }

        // public async Task<GetUsersQueryVm> GetUsers(GetUsersQuery query)
        // {
        //     var users = await _userManager.GetAllUsers();
        //     GetUsersQueryVm vm = new GetUsersQueryVm
        //     {
        //         Users = users
        //     };
        //     return vm;
        // }

        public async Task Update(User entity)
        {
            var user = await _userManager.GetUserById(entity.Id);
            if (user.Id != entity.Id)
            {
                throw new NotFoundException();
            }
            try
            {
                await _userManager.UpdateUserAsync(new User
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    UserName = entity.UserName,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,

                });
            }
            catch (NotFoundException e)
            {
                throw e;
            }

        }
    }
}
