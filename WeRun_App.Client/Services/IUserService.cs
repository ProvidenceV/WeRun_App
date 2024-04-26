using System.Threading.Tasks;
using WeRun_App.Client.Models;

namespace WeRun_App.Client.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(SignUpModel user);
    }
}
