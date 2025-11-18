using PanAmNursery.Dtos;
using PanAmNursery.Entities;
using PanAmNursery.Repositories.Interfaces;
using PanAmNursery.Services.Interfaces;

namespace PanAmNursery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto dto)
        {
            User user = new User
            {
                Name = dto.Name,
                CreationDate = DateTime.UtcNow
            };

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                CreationDate = user.CreationDate
            };
        }

        public async Task<UserDto?> GetUserAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                CreationDate = user.CreationDate
            };

        }
    }
}
