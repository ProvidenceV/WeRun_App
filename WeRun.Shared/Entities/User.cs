using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeRun_App.Models;

namespace WeRun_App.Entities
{
    [Table("Users")]
    public class User
    {
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<Route> Routes { get; set; } = new List<Route>();
        public ICollection<RunHistory> RunHistory { get; set; } = new List<RunHistory>();

        //authentication

        public virtual ApplicationUser user { get; set; }

    }

}