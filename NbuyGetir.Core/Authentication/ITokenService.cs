using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authentication
{
    public class TokenClaim
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; }
    }
    /// <summary>
    /// Belirli bir süreliğine Access Token üretmek için servisi kullanacağız.
    /// Tokenda taşınacak bilgiler için TokenClaim adında bir sınıf kullanacağız.
    /// Key value olarak tokenda bilgi saklayacağız.
    /// Token model ise kullanıcının Access Token ve bu token geçerlilik süresi için açtığımız model
    /// </summary>
    public interface ITokenService
    {
        TokenModel CreateAccessToken(List<TokenClaim> claims);
        /// <summary>
        /// Kullanıcıya ait Access Token bilgisininartık kullanılmaması için çalıştıracağımız method. Bu token bilgisi kullanıcıdan giriş alınacaktır.
        /// Login işleminde bu tokenın bir daha bu kullanıcı tarafından kullanılmaması için var.
        /// </summary>
        /// <param name="token"></param>
        void RevokeAccessToken(string token); 
    }
}
