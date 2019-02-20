using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VacationsTracker.Core.DTO;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationApi
    {
        Task<IEnumerable<VacationDto>> GetVacationsAsync(CancellationToken token = default);

        Task<VacationDto> GetVacationAsync(string id, CancellationToken token = default);

        Task<VacationDto> UpsertVacationAsync([NotNull] VacationDto vacation, CancellationToken token = default);

        Task DeleteVacationAsync(string id, CancellationToken token = default);
    }
}