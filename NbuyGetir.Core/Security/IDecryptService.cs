using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Security
{
    public interface IDecryptService
    {
        byte[] Decrypt(byte[] chiper);
    }
}
