using Microsoft.AspNetCore.Identity;
using WeRun_App.Entities;

namespace WeRun_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User user { get; internal set; }
    }
}
