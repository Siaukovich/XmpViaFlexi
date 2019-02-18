using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationContext
    {
        Task<TResponse> GetAsync<TResponse>(string resource) 
            where TResponse : new();

        Task<TResponse> PostAsync<TRequest, TResponse>(string resource, TRequest requestBody)  
            where TResponse : new();
    }
}