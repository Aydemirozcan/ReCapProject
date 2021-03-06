using Core.Utilities.Ioc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;     //Biz Microsoftun kendi kütüphanesini kullanıyoruz.Bunun içinde IMemoryCache adında bir interface i var.
                                       //Adapter Pattern yapıyoruz yani birşeyi kendi sistemimize uyarlıyoruz.Microsoftun _memoryCache sini kendi metodlarımızla birlikte kullanıyoruz.Ona bağlı kalmıyoruz.
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();  //CorModule da serviceCollection.AddMemoryCache();  yazdığımız için oluşan instance yi bana ver
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));   //set _memoryCache den geliyor.Ama bana key ve value ver diyor.Ve ne zaman expire olacak yani durationu soruyor.//TimeSpan zaman aralığı demektir.//Durationa ne kadar süre veririseniz o kadar cacahe de kalır.
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)    //Bellekte böyle bir cache değeri var mı?
        {
            return _memoryCache.TryGetValue(key, out _);   //Biz sadece bellekte olup olmadığını kontrol etmek istiyoruz ama o bir değerde döndürmek istiyor.Bir şey döndürmesini istemediğimiz için out _ dedik(bunun yöntemi c# da bu)
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)     //RemoveByPattern çalışma anında bellekten silmeye yarıyor.
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);   //Bir şey cache lendiğinde EntriesCollection diye birşeyin içine atılıyor.//Git bellekteki EntriesCollection ı bul
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;   //definitionu memorycacahe olanları bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);  //herbir cache elemanını gez
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
