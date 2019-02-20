using System;
using System.Collections.Generic;
using System.Threading;
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

        public async Task<IEnumerable<VacationDto>> GetVacationsAsync(CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var response = await _context.GetAsync<BaseResultOfMultipleVacationRequest>(string.Empty, token);

            return response.Result;
        }

        public async Task<VacationDto> GetVacationAsync(string id, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            var response = await _context.GetAsync<BaseResultOfSingleVacationRequest>($"/{id}", token);

            return response.Result;
        }

        public async Task<VacationDto> UpsertVacationAsync(VacationDto vacation, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            if (vacation.Id == Guid.Empty.ToString())
            {
                vacation.Created = DateTime.MinValue;
            }

            var response = await _context.PostAsync<VacationDto, BaseResultOfSingleVacationRequest>(string.Empty, vacation, token);

            return response.Result;
        }
    }
}