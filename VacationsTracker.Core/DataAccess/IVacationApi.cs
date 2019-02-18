using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VacationsTracker.Core.DTO;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationApi
    {
        Task<IEnumerable<VacationDto>> GetVacationsAsync();

        Task<VacationDto> GetVacationAsync(string id);

        Task<VacationDto> UpsertVacationAsync([NotNull] VacationDto vacation);
    }
}