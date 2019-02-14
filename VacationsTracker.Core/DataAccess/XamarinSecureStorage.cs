using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace VacationsTracker.Core.DataAccess
{
    public class XamarinSecureStorage : ISecureStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public async Task<string> GetAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return await SecureStorage.GetAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            await SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return SecureStorage.Remove(key);
        }
    }
}