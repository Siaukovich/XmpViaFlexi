﻿using FlexiMvvm.Operations;

namespace VacationsTracker.Core.Operations
{
    public class LoadingOperationNotification : OperationNotificationBase
    {
        public LoadingOperationNotification(
            int delay,
            int duration,
            bool isCancellable)
            : base(delay, duration, isCancellable)
        {
        }

        protected override void OnStartOperation(OperationContext context)
        {
            switch (context.Owner)
            {
                case IViewModelWithOperation viewModel:
                    viewModel.Loading = true;
                    break;
            }
        }

        protected override void OnFinishOperation(OperationContext context, OperationStatus status, object result)
        {
            if (context.GetNotificationsCount<LoadingOperationNotification>() == 0)
            {
                switch (context.Owner)
                {
                    case IViewModelWithOperation viewModel:
                        viewModel.Loading = false;
                        break;
                }
            }
        }
    }
}
