using NbuyGetir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Domain.Models
{
    public class Product : AuditableEntity
    {
        public Product(string name, decimal unitPrice, decimal listPrice, int stock, string description, string pictureBase64, string pictureUrl)
        {
            
        }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ListPrice { get; private set; }
        public decimal DiscountedListPrice { get; private set; }
        public int Stock { get; set; }
        public string Description { get; set; } //10x1, 1lt, 2kg vs
        public string PictureBase64 { get; private set; }
        public string PictureUrl { get; set; }
        public bool IsDiscounted { get
            {
                return DiscountedListPrice < ListPrice ? true : false;
            }
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Ürün ismi boş geçilemez.");
            }
            Name = name.Trim();
        }

        private void SetPrice(decimal unitPrice, decimal listPrice)
        {
            if (unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz.");
            }
            if (unitPrice<=0 || listPrice<=0)
            {
                throw new Exception("Üürn birim fiyatı ya da ürün satış fiyatı negatif ve 0 verilemez.");
            }
            ListPrice = listPrice;
            UnitPrice = unitPrice;
        }
        /// <summary>
        /// Bu bethod ile bir ürünğn satış fiyatona belirli bir oranda indirim yapılır.
        /// İndirim oranı güncellenir ve sadece program tarafında DiscountedListPrice ı tutacağız
        /// Bu indirimli fiyatımız olacaktır.
        /// </summary>
        /// <param name="discountAmount"></param>
        private void DescreasePrice(decimal newPrice)
        {
            if (newPrice > ListPrice)
            {
                throw new Exception("İndirimli fiyat liste fiyatından büyük olamaz.");
            }

            if (newPrice <= UnitPrice)
            {
                throw new Exception("İndirimli fiyat birim fiyatından küçük olamaz.");
            }

            DiscountedListPrice = newPrice;

            //indirim uygula eventi fırlatılacak. Fovoriye ekleyen müşteriler için.
        }

        public void IncreasePrice(decimal newListPrice, decimal newDiscountedNewListPrice)
        {
            if (newListPrice < ListPrice)
            {
                throw new Exception("Yeni fiyat liste fiyatından küçük olamaz.");
            }
            if (newDiscountedNewListPrice > newListPrice)
            {
                throw new Exception("İndirimli fiyat yeni liste fiyatından büyük olamaz.");
            }
            ListPrice = newListPrice;
            DiscountedListPrice = newDiscountedNewListPrice;
        }

    }
}
