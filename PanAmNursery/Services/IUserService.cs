using PanAmNursery.Dtos;

namespace PanAmNursery.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto dto);
        Task<UserDto?> GetUserAsync(int id);
    }
}
