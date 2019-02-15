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

        private const string BaseUrl = "http://localhost:5000/api/vts/workflow";

        public NetVacationRepository([NotNull] IVacationApi vacationApi)
        {
            _vacationApi = vacationApi;
        }

        public async Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync()
        {
            var response = await _vacationApi.GetAsync<BaseResultOfMultipleVacationRequest>(BaseUrl);

            return response.Result.Select(v => v.ToVacationCellViewModel());
        }

        public async Task<VacationCellViewModel> GetVacationAsync([NotNull] string vacationId)
        {
            var response = await _vacationApi.GetAsync<BaseResultOfSingleVacationRequest>($"{BaseUrl}/{vacationId}");

            return response.Result.ToVacationCellViewModel();
        }

        public async Task UpsertVacationAsync([NotNull] VacationCellViewModel vacationViewModel)
        {
            var vacationDto = vacationViewModel.ToVacationDto();

            await _vacationApi.PostAsync($"{BaseUrl}", vacationDto);
        }
    }
}