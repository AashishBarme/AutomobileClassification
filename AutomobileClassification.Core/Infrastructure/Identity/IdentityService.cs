using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Common.Exceptions;
using AutomobileClassification.Core.Domain.Entities;
using AutomobileClassification.Core.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomobileClassification.Core.Infrastructure.Identity
{
    public class IdentityService
    {
        
        private UserManager<ApplicationUser> _userManager;
        private AppDbContext _context;
        public IdentityService(
            UserManager<ApplicationUser> userManager,
            AppDbContext context

        )
        {
            _userManager = userManager;
            _context = context;

        }
        public async Task<long> CreateUserAsync(User entity, string password)
        {
            var user = new ApplicationUser
            {
                UserName = entity.UserName,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,

            };
            if (entity.Id > 0)
            {
                user.Id = entity.Id;
            }
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var item in result.Errors)
                {
                    errors += $"{item.Code}: {item.Description}\n";
                }
                throw new DuplicateNameException(errors);
            }
            return user.Id;



        }

        public async Task<long> CreateUserAsync(User entity, string password, string[] permissions)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = entity.UserName,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,

                };
                if (entity.Id > 0)
                {
                    user.Id = entity.Id;
                }
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var returnUser = _userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();

                    if (permissions.Length > 0)
                    {
                        foreach (var claim in GetClaimsFromArray(permissions))
                        {
                            await _userManager.AddClaimAsync(returnUser, claim);
                        }
                    }
                    if (returnUser == null)
                    {
                        throw new Exception("User Not found");
                    }
                    return returnUser.Id;
                }
                else
                {
                    throw new Exception("Error creating user");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var returnUser = await _userManager.FindByNameAsync(username);


            if (returnUser != null)
            {
                return new User
                {
                    Id = returnUser.Id,
                    Email = returnUser.Email,
                    UserName = returnUser.UserName,
                    FirstName = returnUser.FirstName,
                    LastName = returnUser.LastName,
                };
            }
            throw new NotFoundException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userManager.Users.Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
            }).ToListAsync();
        }
        public async Task<User> GetUserById(long id)
        {
            User entity = new User();
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                entity.UserName = user.UserName;
                entity.Id = user.Id;
                entity.Email = user.Email;
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;

            }
            return await Task.FromResult<User>(entity);
        }
        private List<Claim> GetClaimsFromArray(string[] permissions)
        {
            List<Claim> claims = new List<Claim>();
            if (permissions.Length > 0)
            {
                foreach (var item in permissions)
                {
                    var claim = new Claim(item, item);
                    claims.Add(claim);
                }
            }
            return claims;
        }

        public async Task UpdatePasswordAsync(User entity, string password)
        {
            var user = await _userManager.FindByIdAsync(entity.Id.ToString());
            if (user == null)
            {
                throw new NotFoundException();
            }
            var pass = password.ToString();
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, pass);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToString());
            }
        }

        public async Task UpdateUserAsync(User entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id.ToString());
            if (user == null)
            {
                throw new NotFoundException();
            }
            user.Email = entity.Email;
            user.UserName = entity.UserName;
            user.Email = entity.Email;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToString());
            }
        }
        public async Task<bool> DeleteUserAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

    }
}