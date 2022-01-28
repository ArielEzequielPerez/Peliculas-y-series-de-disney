using System;

namespace PeliculasSeries.Dto
{
    public class UserRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DischargeDate { get; set; }
        
        public bool Active { get; set; }

        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public UserRegisterDto()
        {
            DischargeDate = DateTime.Now;
            Active = true;

        }
    }
}
