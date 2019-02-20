using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VacationsTracker.Core.Mapper;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class NetVacationRepository : IVacationsRepository
    {
        private readonly IVacationApi _vacationApi;

        public NetVacationRepository(IVacationApi vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync(CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var response = await _vacationApi.GetVacationsAsync(token);

            return response.Select(v => v.ToVacationCellViewModel());
        }

        public async Task<VacationCellViewModel> GetVacationAsync([NotNull] string id, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var response = await _vacationApi.GetVacationAsync(id, token);

            return response.ToVacationCellViewModel();
        }

        public async Task UpsertVacationAsync([NotNull] VacationCellViewModel vacationViewModel, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var vacationDto = vacationViewModel.ToVacationDto();

            await _vacationApi.UpsertVacationAsync(vacationDto, token);
        }
    }
}