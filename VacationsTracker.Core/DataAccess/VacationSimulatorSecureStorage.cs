using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public class VacationSimulatorSecureStorage : ISecureStorage
    {
        private static readonly ConcurrentDictionary<string, string> DictionarySessionStorage;

        static VacationSimulatorSecureStorage()
        {
            DictionarySessionStorage = new ConcurrentDictionary<string, string>();
        }

        public Task<string> GetAsync(string key)
        {
            try
            {
                DictionarySessionStorage.TryGetValue(key, out string value);
                return Task.FromResult(value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public bool Remove(string key)
        {
            try
            {
                return DictionarySessionStorage.TryRemove(key, out _);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public void RemoveAll()
        {
            try
            {
                DictionarySessionStorage.Clear();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public Task SetAsync(string key, string value)
        {
            try
            {
                DictionarySessionStorage.TryAdd(key, value);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}