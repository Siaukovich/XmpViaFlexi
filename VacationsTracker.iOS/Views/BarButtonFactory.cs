using UIKit;
using VacationsTracker.Core.Resources;

namespace VacationsTracker.iOS.Views
{
    public static class BarButtonFactory
    {
        public static UIBarButtonItem GetSaveButton()
        {
            return new UIBarButtonItem(Strings.SaveNavigationButton_Text, UIBarButtonItemStyle.Done, null);
        }

        public static UIBarButtonItem GetNewButton()
        {
            return new UIBarButtonItem(Strings.CreateNewVacationButton_Text, UIBarButtonItemStyle.Done, null);
        }
    }
}