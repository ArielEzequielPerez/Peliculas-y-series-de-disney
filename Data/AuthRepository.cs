using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using peliculasDisney.Data;
using PeliculasSeries.Data.Interfaces;

namespace PeliculasSeries.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(AUser => AUser.Name == username);                
        }

        public async Task<User> Login(string Email, string Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(AUser => AUser.Email == Email);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string Password, byte [] PasswordHash, byte [] PasswordSalt)
        {
            using (var Hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var ComputeHash = Hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                for (int i = 0; i < ComputeHash.Length; i++)
                {
                    if (ComputeHash[i] != PasswordHash[i])
                        return false;
                }
                return true;
            }

        }

        public async Task<User> Register(User Email, string Password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(Password, out passwordHash, out passwordSalt);

            Email.PasswordHash = passwordHash;
            Email.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(Email);
            await _context.SaveChangesAsync();

            return Email;
        }


    }
}
