using PanAmNursery.Entities;

namespace PanAmNursery.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task Add(User user);
        Task SaveChanges();
    }
}
