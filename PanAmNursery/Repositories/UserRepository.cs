using Microsoft.EntityFrameworkCore;
using PanAmNursery.Data;
using PanAmNursery.Entities;
using PanAmNursery.Repositories.Interfaces;

namespace PanAmNursery.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        }

        public Task AddAsync(User user)
        {
            return _context.Users.AddAsync(user).AsTask();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
