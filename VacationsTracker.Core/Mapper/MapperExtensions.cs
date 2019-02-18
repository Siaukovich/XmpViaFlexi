using VacationsTracker.Core.Domain;
using VacationsTracker.Core.DTO;
using VacationsTracker.Core.Presentation.ViewModels;

namespace VacationsTracker.Core.Mapper
{
    internal static class MapperExtensions
    {
        public static Vacation ToVacationModel(this VacationDto vacationDto)
        {
            return AutoMapper.Mapper.Map<VacationDto, Vacation>(vacationDto);
        }

        public static VacationDto ToVacationDto(this Vacation vacationModel)
        {
            return AutoMapper.Mapper.Map<Vacation, VacationDto>(vacationModel);
        }

        public static VacationCellViewModel ToVacationCellViewModel(this VacationDto vacationDto)
        {
            var vacationViewModel = new VacationCellViewModel
            {
                Id = vacationDto.Id,
                Start = vacationDto.Start,
                End = vacationDto.End,
                Status = vacationDto.VacationStatus,
                Type = vacationDto.VacationType
            };

            return vacationViewModel;
        }

        public static VacationDto ToVacationDto(this VacationCellViewModel viewModel)
        {
            var vacationDto = new VacationDto
            {
                Id = viewModel.Id,
                Start = viewModel.Start,
                End = viewModel.End,
                VacationStatus = viewModel.Status,
                CreatedBy = "string",
                VacationType = viewModel.Type
            };

            return vacationDto;
        }
    }
}