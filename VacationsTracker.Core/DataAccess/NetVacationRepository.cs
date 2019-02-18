using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VacationsTracker.Core.DTO;
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

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            var response = await _vacationApi.GetVacationsAsync();

            return response.Select(v => v.ToVacationCellViewModel());
        }

        public async Task<VacationCellViewModel> GetVacationAsync([NotNull] string id)
        {
            var response = await _vacationApi.GetVacationAsync(id);

            return response.ToVacationCellViewModel();
        }

        public async Task UpsertVacationAsync([NotNull] VacationCellViewModel vacationViewModel)
        {
            var vacationDto = vacationViewModel.ToVacationDto();

            await _vacationApi.UpsertVacationAsync(vacationDto);
        }
    }
}