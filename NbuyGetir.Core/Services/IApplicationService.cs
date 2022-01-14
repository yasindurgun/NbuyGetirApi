using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Services
{
    /// <summary>
    /// Frontend tarafından gelen bir isteğin işlenip frontend tarafına bir sonucun döndürülmesi için yaptık. Burada apide inputmodel ve viewmodel yerine artık dto terimini kullanacağız. Buradaki servisi application katmanı için yazıyoruz.
    /// </summary>
    /// <typeparam name="TRequestDto">InputModel</typeparam>
    /// <typeparam name="TResponseDto">ViewModel olarak kullanılacak.</typeparam>
    public interface IApplicationService<TRequestDto,TResponseDto>
    {
        Task<TResponseDto> HandleAsync(TResponseDto dto);
    }
}
