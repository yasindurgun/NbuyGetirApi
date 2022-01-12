using NbuyGetir.Common.Uri;
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
        public Product(string name, decimal unitPrice, decimal listPrice, int stock, string description, string pictureUrl, decimal discountedListPrice)
        {
            SetName(name);
            SetPrice(unitPrice,listPrice,discountedListPrice);
            SetDescription(description);
            SetStock(stock);
        }
        /// <summary>
        /// Hem kayıt hemde güncelleme işleminde kullanılacağından dolayı public
        /// </summary>
        public void SetPictureUrl(string url)
        {
            if (!UrlHelper.IsUrl(url))
            {
                throw new Exception("Resim yolu url formatında değildir");
            }
            if (string.IsNullOrEmpty(url))
            {
                PictureUrl = "default-product.jpeg";
            }
            else
            {
                PictureUrl = url.Trim();
            }
        }
       
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ListPrice { get; private set; }
        public decimal DiscountedListPrice { get; private set; }
        public int Stock { get; set; }
        public string Description { get; set; } //10x1, 1lt, 2kg vs
        public string PictureUrl { get; set; }
        public bool IsDiscounted { get
            {
                return DiscountedListPrice < ListPrice ? true : false;
            }
        }

        public bool IsStockInCriticalLevel { get {
                return Stock < 10 ? true : false;
            } }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Ürün ismi boş geçilemez.");
            }
            Name = name.Trim();
        }
        private void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new Exception("Stok değeri 0'dan daha küçük olamaz.");
            }
          
            Stock = stock;
        }
        /// <summary>
        /// Stoklama işlemi, ürünün envantere girmesi işlemi
        /// </summary>
        public void StockIn(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("Stoğa girilecek yeni ürün adeti 0 ve daha düşük olamaz.");
            }
            Stock += quantity;
            //Stoğa ürün girildi eventi fırlatalım.
        }

        public void StockOut(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("0 dan küçük değer stokdan düşülemez.");
            }
            if (IsStockInCriticalLevel)
            {
                //kritik sok seviyesindeki bir ürün sipariş edildi diye bir mesaj atalım.
            }
            if (quantity>Stock)
            {
                //hata
                throw new Exception("Stoktan düşülen miktar stoktaki miktardan büyük olamaz.");
            }

            Stock -= quantity;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(Description))
            {
                throw new Exception("Ürün açıklama alanını doldurunuz.");
            }
            if (description.Length > 50)
            {
                throw new Exception("Maksimum 50 karakter girebilirsiniz.");
            }
            Description = description;
        }
        /// <summary>
        /// Ürüne ait fiyatların değişimini bu method ile yapacağız.
        /// </summary>
        /// <param name="unitPrice"></param>
        /// <param name="listPrice"></param>
        /// <param name="discountedListPrice"></param>
        public void SetPrice(decimal unitPrice, decimal listPrice, decimal discountedListPrice)
        {
            if (unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz.");
            }
            if (unitPrice<=0 || listPrice<=0 || discountedListPrice<=0)
            {
                throw new Exception("Üürn birim fiyatı ya da ürün satış fiyatı ya da indirimli satış fiyatı negatif veya 0 verilemez.");
            }
            if (discountedListPrice > listPrice)
            {
                throw new Exception("İndirimli satış fiyatı satış fiyatından büyük olamaz.");
            }
            if (discountedListPrice<unitPrice)
            {
                throw new Exception("İndirimli satış fiyatı birim fiyatından küçük olamaz.");

            }
            ListPrice = listPrice;
            UnitPrice = unitPrice;
            DiscountedListPrice = discountedListPrice;
        }
        /// <summary>
        /// Bu bethod ile bir ürünğn satış fiyatona belirli bir oranda indirim yapılır.
        /// İndirim oranı güncellenir ve sadece program tarafında DiscountedListPrice ı tutacağız
        /// Bu indirimli fiyatımız olacaktır.
        /// </summary>
        /// <param name="discountAmount"></param>
        public void DescreasePrice(decimal newPrice)
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
