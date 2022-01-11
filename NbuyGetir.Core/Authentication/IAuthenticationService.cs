using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authentication
{
    public class AuthenticationError
    {
        public string Code { get; set; }
        public string ErroMessage { get; set; }
        public string Key { get; set; }
    }

    public class AuthenticationResult
    {
        public bool IsSucceded { get; private set; } = true;
        public string AccessToken { get; private set; }
        public List<AuthenticationError> Errors { get; private set; }

        public void AddError(AuthenticationError error)
        {
            IsSucceded = false;
            Errors.Add(error);
        }

        public void SetAccessToken(string token)
        {
            if (IsSucceded)
            {
                AccessToken = token;
            }
        }
    }

    
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password, bool rememberMe);
        void Logout(string AccessToken);
    }
}
