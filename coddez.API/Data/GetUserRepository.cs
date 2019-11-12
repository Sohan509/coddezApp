using System.Collections.Generic;
using System.Threading.Tasks;
using coddez.API.Models;
using Microsoft.EntityFrameworkCore;

namespace coddez.API.Data
{
    public class GetUserRepository : IGetUserRepository
    {
        private readonly DataContext _context;
        public GetUserRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> Getusers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<bool> saveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}