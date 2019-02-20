using System.Threading;
using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationContext
    {
        Task<TResponse> GetAsync<TResponse>(string resource, CancellationToken token = default) 
            where TResponse : new();

        Task<TResponse> PostAsync<TRequest, TResponse>(string resource, TRequest requestBody, CancellationToken token = default)  
            where TResponse : new();
    }
}