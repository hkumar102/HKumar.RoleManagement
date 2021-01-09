using HKumar.RoleManagement.Interfaces.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HKumar.RoleManagement.Services
{
    public class DefaultCacheProvider : ICacheProvider
    {
        public T GetObject<T>(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public bool RemoveObj(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public void SetObject<T>(string cacheKey, T cacheValue, TimeSpan? ttl = null)
        {
            throw new NotImplementedException();
        }
    }
}
