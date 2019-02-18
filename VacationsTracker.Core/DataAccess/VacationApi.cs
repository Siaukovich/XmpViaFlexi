using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacationsTracker.Core.DTO;

namespace VacationsTracker.Core.DataAccess
{
    internal class VacationApi : IVacationApi
    {
        private readonly IVacationContext _context;

        public VacationApi(IVacationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VacationDto>> GetVacationsAsync()
        {
            var response = await _context.GetAsync<BaseResultOfMultipleVacationRequest>(string.Empty);

            return response.Result;
        }

        public async Task<VacationDto> GetVacationAsync(string id)
        {
            var response = await _context.GetAsync<BaseResultOfSingleVacationRequest>($"/{id}");

            return response.Result;
        }

        public async Task<VacationDto> UpsertVacationAsync(VacationDto vacation)
        {
            if (vacation.Id == Guid.Empty.ToString())
            {
                vacation.Created = DateTime.MinValue;
            }

            var response = await _context.PostAsync<VacationDto, BaseResultOfSingleVacationRequest>(string.Empty, vacation);

            return response.Result;
        }
    }
}