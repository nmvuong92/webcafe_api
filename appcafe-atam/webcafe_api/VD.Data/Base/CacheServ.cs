using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Web;

namespace VD.Data.Base
{

    public class CacheServ
    {
        public static T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item==null)
            {
                item = getItemCallback();
                if (item != null)
                {
                    MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
                }
            }
            return item;
        }
        public static void ClearPrefix(string _prefix)
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys.Where(w => w.StartsWith(_prefix)))
            {
                MemoryCache.Default.Remove(cacheKey);
            }
        }

        public static void ClearByKey(string _key)
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys.Where(w => w == _key))
            {
                MemoryCache.Default.Remove(cacheKey);
            }
        }
        public static void ClearAll()
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                MemoryCache.Default.Remove(cacheKey);
            }
        }
    }


    //var products=cacheService.GetOrSet("catalog.products", ()=>productRepository.GetAll())
}
