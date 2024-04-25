using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeRun_App.Client.Models;

namespace WeRun_App.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/signup", user);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to register: {errorMessage}");
            }
        }
    }
}
