using WeRun_App.Entities;

namespace WeRun_App.Interfaces
    {
        public interface ISignUpService
        {
            //void RegisterUser(User user);
            Task RegisterUserAsync(User user);
        }
    }

