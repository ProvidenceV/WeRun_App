using WeRun_App.Database;
using WeRun_App.Interfaces;
using WeRun_App.Entities;

namespace WeRun_App.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly AppDBContext _context;

        public SignUpService(AppDBContext context)
        {
            _context = context;
        }

        public async Task RegisterUserAsync(User user)
        {
            try
            {
                if (!IsValidUser(user))
                {
                    //user.Password = HashPassword(user.Password);

                    user.JoinDate = DateTime.UtcNow;

                    // Add the new user to the context
                    _context.Users.Add(user);

                    // Save changes to the database
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Invalid Username and Password");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.ToString()); 
            }
        }

       
        private bool IsValidUser(User user)
        {
            return !string.IsNullOrEmpty(user.Username) || !string.IsNullOrEmpty(user.Email) &&
                   !string.IsNullOrEmpty(user.Password);
        }
    }
}
