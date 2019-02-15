using System.Threading.Tasks;
using JetBrains.Annotations;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationApi
    {
        Task<T> GetAsync<T>([NotNull] string url);

        Task<T> PostAsync<T>([NotNull] string url, [NotNull] T obj);

        Task<T> DeleteAsync<T>([NotNull] string url);
    }
}