using System.Net.Http;

namespace Common.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.UserId;
            FirstName = user.Name;
            LastName = user.SurName;
            Username = user.UserName;
            Token = token;
        }
    }
}
