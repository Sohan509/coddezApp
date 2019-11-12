using System;
using System.Threading.Tasks;
using coddez.API.Models;
using Microsoft.EntityFrameworkCore;

namespace coddez.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string emailAddress, string password)
        {
            var email = await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
            if(email == null)
                return null;
            if(!VerifyPasswordHash(password, email.PasswordHash, email.PasswordSalt))
                return null;
            return email;

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for ( int i = 0; i < computedHash.Length; i++ )
                {
                    if (computedHash[i] != passwordHash[i]) 
                        return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExits(string user)
        {
            if(await _context.Users.AnyAsync(x =>x.EmailAddress == user))
                return true;

            if(await _context.Users.AnyAsync(x =>x.Username == user))
                return true;

            return false;
        }
    }
}