using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Validations
{
    public class ValidationErrorResult
    {
        /// <summary>
        /// // Hangi propertyde alanda hata olduğu bilgisi için
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// // Hata Mesajı için
        /// </summary>
        public string ValidationMessage { get; set; }
    }
    public class ValidationResult
    {
        public bool IsValid { get; private set; } = true;

        /// <summary>
        /// Nesne içerisinde birden fazla hata olma ihtimaline göre eklendi.
        /// </summary>
        public List<ValidationErrorResult> Errors { get; private set; }

        public void AddError(ValidationErrorResult error)
        {
            IsValid = false; // tek bir hata bile varsa bu nesne valid doğrulanamaz.
            Errors.Add(error);
        }
    }
    public interface IValidator<TDto> where TDto:class
    {
        /// <summary>
        /// Valid olup olmadığını görebiliriz.
        /// </summary>
       
        ValidationErrorResult ValidationResult { get; set; }
        /// <summary>
        /// Frontend tarafından gönderilen dto nun validasyon kurallarına uyup uymadığını kontrol ederiz.
        /// </summary>
        /// <param name="dto"></param>
        void Validate(TDto dto);
    }
}
