using System;

namespace PeliculasSeries.Dto
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DischargeDate { get; set; }
        public bool Active { get; set; }
    }
    
}
