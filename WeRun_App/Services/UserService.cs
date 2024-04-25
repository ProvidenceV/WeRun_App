using System.Threading.Tasks;
using WeRun_App.Entities;

namespace WeRun_App.Services
{
    public class UserService
    {
        // Example: Add a method to register a user
        public async Task<bool> RegisterUser(User user)
        {
            if (!IsValidUser(user))
            {
                return false;
            }

            // Here, add logic to save the user to a database or send it to a server API
            // For demonstration, let's assume registration always succeeds
            return true;
        }

        private bool IsValidUser(User user)
        {
            return !string.IsNullOrEmpty(user.Username) || !string.IsNullOrEmpty(user.Email) &&
                   !string.IsNullOrEmpty(user.Password);
        }
        
    }
}

