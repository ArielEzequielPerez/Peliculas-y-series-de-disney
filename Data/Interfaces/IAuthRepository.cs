using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasSeries.Data.Interfaces
{
    interface IAuthRepository
    {
        Task<User> Login(string Username, string Password);
        Task<User> Register(User Email, string Password);
        Task<bool> UserExists(string Email);
    }
}
