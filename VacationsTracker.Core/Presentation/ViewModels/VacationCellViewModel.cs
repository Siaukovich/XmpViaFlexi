﻿using System;
using FlexiMvvm;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels
{
    public class VacationCellViewModel : ObservableObjectBase
    {
        public static VacationCellViewModel GetNew => new VacationCellViewModel
        {
            _start = DateTime.Now,
            _end = DateTime.Now.AddDays(1),
            _type = VacationType.Regular,
            _status = VacationStatus.Approved
        };

        private VacationType _type;
        private VacationStatus _status;
        private DateTime _start;
        private DateTime _end;
        private bool _separatorVisible = true;

        public string Id { get; set; }

        public VacationType Type
        {
            get => _type;
            set => Set(ref _type, value);
        }

        public VacationStatus Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public (DateTime, DateTime) Duration => (_start, _end);

        public DateTime Start
        {
            get => _start;
            set => Set(ref _start, value);
        }

        public DateTime End
        {
            get => _end;
            set => Set(ref _end, value);
        }

        public bool SeparatorVisible
        {
            get => _separatorVisible;
            set => Set(ref _separatorVisible, value);
        }

        public void Deconstruct(out string id, out DateTime start, out DateTime end, out VacationStatus status, out VacationType type)
        {
            id = Id;
            start = Start;
            end = End;
            status = Status;
            type = Type;
        }

        public void Deconstruct(out DateTime start, out DateTime end, out VacationStatus status, out VacationType type)
        {
            start = Start;
            end = End;
            status = Status;
            type = Type;
        }
    }
}
