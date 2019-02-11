using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views
{
    public static class BarButtonFactory
    {
        public static UIBarButtonItem GetSaveButton()
        {
            return new UIBarButtonItem(AppStrings.Save, UIBarButtonItemStyle.Done, null);
        }

        public static UIBarButtonItem GetNewButton()
        {
            return new UIBarButtonItem(AppStrings.New, UIBarButtonItemStyle.Done, null);
        }
    }
}