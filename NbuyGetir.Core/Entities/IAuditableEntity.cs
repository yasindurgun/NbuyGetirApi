using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entities
{
    /// <summary>
    /// Denetlenebilir entity kimin tarafından updated created yapıldığı bilgisini tutacağız.
    /// </summary>
    public interface IAuditableEntity
    {
        //Bu entity önemli ürün gibi bir nesne ise bu alanları kesinlikle tutarız.
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }

    }
}
