using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Caching
{
    public class CacheData<T>
    {
        public string Key { get; set; } //cacahelenecek veri için bir key değeri tutuyoruz. Bu key değeri üzerinden bu datamıza ulaşacağız.
        public T Data { get; set; } // json olarak buraya data set edeceğiz.
    }
    /// <summary>
    /// Getir uygulamasındaki kategorileri ve bu kategorilere ait alt kategori bilgisini cacheden yani
    /// ram üzerinden alacağız. Böylece her seferinde dbden çekmediğimiz için daha hızlı bir sonuç döndüreceğiz. Bu gibi çok fazla crud operasyonunun yapılmadığı sınıflarımızı ramden okuyabiliriz
    /// Aynı zamanda sepet gibi işlemler içinde tanımlanabilir.
    /// </summary>
    interface ICacheService<TResult> where TResult : class
    {
        void SetCache(string key, TResult cacheData);
        TResult GetFromCache(string key);
    }
}
