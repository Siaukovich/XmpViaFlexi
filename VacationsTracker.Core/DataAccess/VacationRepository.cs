﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.DataAccess
{
    public class VacationRepository : IVacationsRepository
    {
        private static readonly List<VacationCellViewModel> _vacations = 
            new List<VacationCellViewModel>
            {
                new VacationCellViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Start = new DateTime(2019, 3, 20),
                    End = new DateTime(2019, 3, 31),
                    Status = VacationStatus.Approved,
                    Type = VacationType.Regular
                },
                new VacationCellViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Start = new DateTime(2018, 12, 26),
                    End = new DateTime(2018, 12, 30),
                    Status = VacationStatus.Approved,
                    Type = VacationType.Regular
                },
                new VacationCellViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Start = new DateTime(2018, 11, 2),
                    End = new DateTime(2018, 11, 4),
                    Status = VacationStatus.Closed,
                    Type = VacationType.Sick
                },
                new VacationCellViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Start = new DateTime(2018, 07, 11),
                    End = new DateTime(2018, 07, 13),
                    Status = VacationStatus.Closed,
                    Type = VacationType.Exceptional
                },
                new VacationCellViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Start = new DateTime(2018, 02, 6),
                    End = new DateTime(2018, 02, 7),
                    Status = VacationStatus.Closed,
                    Type = VacationType.Overtime
                },
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 11, 2),
                //    End = new DateTime(2018, 11, 4),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.LeaveWithoutPay
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 07, 11),
                //    End = new DateTime(2018, 07, 13),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.ExceptionalLeave
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 02, 6),
                //    End = new DateTime(2018, 02, 7),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.Overtime
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 07, 11),
                //    End = new DateTime(2018, 07, 13),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.ExceptionalLeave
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 02, 6),
                //    End = new DateTime(2018, 02, 7),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.Overtime
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 11, 2),
                //    End = new DateTime(2018, 11, 4),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.LeaveWithoutPay
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 07, 11),
                //    End = new DateTime(2018, 07, 13),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.ExceptionalLeave
                //},
                //new VacationCellViewModel
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    Start = new DateTime(2018, 02, 6),
                //    End = new DateTime(2018, 02, 7),
                //    Status = VacationStatus.Closed,
                //    Type = VacationType.Overtime
                //}
            };

        public int Count => _vacations.Count;

        public VacationCellViewModel this[int i] => _vacations[i];

        public Task<IEnumerable<VacationCellViewModel>> GetVacationsAsync(CancellationToken token = default)
        {
            return Task.FromResult<IEnumerable<VacationCellViewModel>>(_vacations);
        }

        public Task<VacationCellViewModel> GetVacationAsync(string id, CancellationToken token = default)
        {
            var vacation = _vacations.SingleOrDefault(v => v.Id == id);

            return Task.FromResult(vacation);
        }

        public async Task UpsertVacationAsync(VacationCellViewModel vacationViewModel, CancellationToken token = default)
        {
            if (vacationViewModel.Id == Guid.Empty.ToString())
            {
                await SaveNewVacationAsync(vacationViewModel);
                return;
            }

            await UpdateVacationAsync(vacationViewModel);
        }

        private static Task UpdateVacationAsync(VacationCellViewModel vacation)
        {
            int index = -1;
            for (var i = 0; i < _vacations.Count; i++)
            {
                if (_vacations[i].Id == vacation.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                _vacations[index] = vacation;
            }

            return Task.CompletedTask;
        }

        private Task SaveNewVacationAsync(VacationCellViewModel vacation)
        {
            vacation.Id = Guid.NewGuid().ToString();

            _vacations.Add(vacation);

            return Task.CompletedTask;
        }
    }
}