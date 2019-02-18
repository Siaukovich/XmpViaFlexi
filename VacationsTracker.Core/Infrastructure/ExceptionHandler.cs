using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FlexiMvvm.Operations;

namespace VacationsTracker.Core.Infrastructure
{
    public class ExceptionHandler: IErrorHandler
    {
        public Task HandleAsync(OperationContext context, OperationError<Exception> error, CancellationToken cancellationToken)
        {
            switch (error.Exception)
            {
            }

            Debug.WriteLine("oops...");

            Debug.WriteLine(error.Exception);

            return  Task.CompletedTask;
        }
    }
}
