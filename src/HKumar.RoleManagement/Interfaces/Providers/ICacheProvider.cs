using System;

namespace HKumar.RoleManagement.Interfaces.Providers
{
    public interface ICacheProvider
    {
        void SetObject<T>(string cacheKey, T cacheValue, TimeSpan? ttl = null);
        T GetObject<T>(string cacheKey);
        bool RemoveObj(string cacheKey);
    }
}
