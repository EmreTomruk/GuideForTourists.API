using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TouristGuide.API.Data.Abstract;
using TouristGuide.API.Models;
using System.Security.Cryptography;

namespace TouristGuide.API.Data.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private TouristGuideContext _touristGuideContext;

        public AuthRepository(TouristGuideContext touristGuideContext)
        {
            _touristGuideContext = touristGuideContext;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _touristGuideContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
                return null;

            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            else return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _touristGuideContext.Users.AddAsync(user);
            await _touristGuideContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _touristGuideContext.Users.AnyAsync(u => u.UserName == userName))
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512()) //SHA512 algogaritmasi kullanilarak bir hash olusturuldu...
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}
