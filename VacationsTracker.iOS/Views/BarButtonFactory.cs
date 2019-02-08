using UIKit;

namespace VacationsTracker.iOS.Views
{
    public static class BarButtonFactory
    {
        public static UIBarButtonItem GetSaveButton()
        {
            return new UIBarButtonItem("Save", UIBarButtonItemStyle.Done, null);
        }
    }
}