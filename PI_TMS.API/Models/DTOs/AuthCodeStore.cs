using Microsoft.Extensions.Caching.Memory;

namespace PI_TMS.API.Models.DTOs
{
    public class AuthCodeStore
    {
        private readonly IMemoryCache _cache;

        public AuthCodeStore(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SaveCode(string email, string code)
        {
            _cache.Set(email, code, TimeSpan.FromMinutes(5));
        }

        public string GetCode(string email)
        {
            _cache.TryGetValue(email, out string code);
            return code;
        }
    }
}
