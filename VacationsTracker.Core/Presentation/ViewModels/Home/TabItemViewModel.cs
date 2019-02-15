using System;
using FlexiMvvm;
using FlexiMvvm.Commands;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.Presentation.ViewModels.Home
{
    public class TabItemViewModel : ViewModelBase
    {
        public string Title { get; }

        public ICommand<NavigationMenuItem> ClickCommand { get; }

        public TabItemViewModel(string title, ICommand<NavigationMenuItem> clickCommand)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            ClickCommand = clickCommand ?? throw new ArgumentNullException(nameof(clickCommand));
        }
    }
}