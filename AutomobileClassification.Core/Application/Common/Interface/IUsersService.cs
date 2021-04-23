using System.Threading.Tasks;
using AutomobileClassification.Core.Application.Services.Users;
using AutomobileClassification.Core.Application.ViewModels;
using AutomobileClassification.Core.Domain.Entities;

namespace AutomobileClassification.Core.Application.Common.Interface
{
    public interface IUsersService
    {
        Task<long> Create(CreateUserDto entity);
        Task Update(User entity);
        Task<bool> Delete(long id);
        Task<User> Get(long id);
        Task ChangePassword(UserUpdatePassword dto);
    }
}