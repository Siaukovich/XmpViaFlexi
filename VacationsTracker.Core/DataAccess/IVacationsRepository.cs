using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public interface IVacationsRepository
    {
        Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync(CancellationToken token = default);

        Task<VacationCellViewModel> GetVacationAsync(string id, CancellationToken token = default);

        Task UpsertVacationAsync(VacationCellViewModel vacationViewModel, CancellationToken token = default);
    }
}
