using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Xamarin.Essentials;

namespace VacationsTracker.Core.DataAccess
{
    public class XamarinSecureStorage : ISecureStorage
    {
        public Task<string> GetAsync([NotNull] string key) => SecureStorage.GetAsync(key);

        public Task SetAsync([NotNull] string key, [NotNull] string value) => SecureStorage.SetAsync(key, value);

        public bool Remove([NotNull] string key) => SecureStorage.Remove(key);

        public void RemoveAll() => SecureStorage.RemoveAll();
    }
}