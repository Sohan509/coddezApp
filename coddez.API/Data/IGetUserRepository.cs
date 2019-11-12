using System.Collections.Generic;
using System.Threading.Tasks;
using coddez.API.Models;

namespace coddez.API.Data
{
    public interface IGetUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> saveAll();
        Task<IEnumerable<User>> Getusers();
        Task<User> GetUser(int id);
    }
}