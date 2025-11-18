using PanAmNursery.Dtos;

namespace PanAmNursery.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserCreateDto dto);
        Task<UserDto?> GetUser(int id);
    }
}
