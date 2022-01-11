using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Autorization
{
    /// <summary>
    /// Bu servis ile sistemdeki kullanıcının ilgili kaynağa erişimine yetkisi olup olmadığını kontrol edeceğiz. Claim ve rol bazlı kontrolleri içerisinde yapacağız.
    /// </summary>
    public interface IAuthorizationService
    {
        bool HasRole(string roleName);
        bool HasRole(params string[] roleNames);
        bool HasClaim(string claim);
        /// <summary>
        ///claim bilgisi kullanıcıya tanımlanmış olan özellikleri örneğin NbuyGetir çalışanı mı, indrim çeki
        ///tanımlanmış mı, indriim kuponu var mı vs gibi bu kullanıcıya tanımlanan ekstra özelliklere claim
        ///diyeceğiz.
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        bool HasClaims(params string[] claims); 
    }
}
