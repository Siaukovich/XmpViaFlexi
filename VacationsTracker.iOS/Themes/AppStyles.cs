using UIKit;

namespace VacationsTracker.iOS.Themes
{
    public static class AppStyles
    {
        public static UITextField SetDefaultTextFieldStyle(this UITextField textField)
        {
            return textField;
        }

        public static UIButton SetPrimaryButtonStyle(this UIButton button, string text = null)
        {

            if (text != null)
            {
                button.SetTitle(text, UIControlState.Normal);
            }

            return button;
        }
    }
}