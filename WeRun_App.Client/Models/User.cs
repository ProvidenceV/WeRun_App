namespace WeRun_App.Client.Models
{
    public class User
    {
        public string? Username;
        public string? FirstName;
        public string? LastName;
        public string? Password;
        public string? Email;
        public string? Gender;
        public string? DateOfBirth;

        public bool IsValid()
        {
            return true;
        }
    }
    
}
