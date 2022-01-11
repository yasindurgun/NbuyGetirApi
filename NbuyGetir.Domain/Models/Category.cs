using NbuyGetir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        /// <summary>
        /// Ekranda ilk açılıştı en üst seviye olan kategorileri listeleyeceğiz. Bu üst seviye altına eklenen alt katagorileri ise ürünler ile bağlayacağız. Ürünler IsTopLevel olarak işaretlenmemiş kategorilerin altına girilecekler.
        /// </summary>
        public bool IsTopLevel { get; private set; } //en üst seviye kategori mi

        private List<Category> _subCategories = new List<Category>();
        public IReadOnlyCollection<Category> SubCategories => _subCategories;

        private List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products;

        public Category(string name, bool isTopLevel)
        {

        }
        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Kategori ismi boş geçilemez.");
            }
        }
        public void AddSubCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("Kategori ismi boş geçilemez.");
            }
            if (category.IsTopLevel)
            {
                throw new Exception("Hata");
            }
            _subCategories.Add(category);
        }

        public void AddProduct(Product product)
        {
            if (!IsTopLevel &&_subCategories.Count() == 0)
            {
                _products.Add(product);
            }
        }
    }
}
