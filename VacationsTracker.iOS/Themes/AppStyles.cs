using CoreGraphics;
using UIKit;

namespace VacationsTracker.iOS.Themes
{
    public static class AppStyles
    {
        public static UIButton SetPrimaryButtonStyle(this UIButton button, string text = null)
        {
            if (text != null)
            {
                button.SetTitle(text, UIControlState.Normal);
            }

            button.BackgroundColor = AppColors.LightBlueColor;

            return button;
        }

        public static UILabel SetErrorLabelStyle(this UILabel label, string text)
        {
            label.Text = text;

            label.BackgroundColor = AppColors.WhiteColor;
            label.TextColor = AppColors.ErrorTextColor;
            label.TextAlignment = UITextAlignment.Center;

            label.WrapText();

            label.SetCornerRadiusTo(5);

            return label;
        }

        public static UITextField SetDefaultTextFieldStyle(this UITextField textField, string placeholder = null)
        {
            if (placeholder != null)
            {
                textField.Placeholder = placeholder;
            }

            textField.BackgroundColor = AppColors.WhiteColor;
            textField.SetLeftPaddingTo(5);

            return textField;
        }

        public static UIImageView SetDefaultBackgroundImage(this UIImageView imageView)
        {
            imageView.Image = UIImage.FromBundle("LoginBackground");

            return imageView;
        }

        public static UILabel SetDurationLabelStyle(this UILabel label)
        {
            label.TextColor = AppColors.LightBlueColor;
            label.Font = UIFont.BoldSystemFontOfSize(AppDimens.DefaultDurationFontSize);

            return label;
        }

        public static UILabel SetTypeLabelStyle(this UILabel label)
        {
            label.Font = UIFont.SystemFontOfSize(12);
            label.TextColor = AppColors.GrayColor;

            return label;
        }

        public static UILabel SetStatusLabelStyle(this UILabel label)
        {
            label.Font = UIFont.SystemFontOfSize(12);
            label.TextColor = AppColors.GrayColor;

            return label;
        }

        public static UIView SetSeparatorStyle(this UIView separator, UIColor color = null)
        {
            if (color == null)
            {
                color = AppColors.GrayColor;
            }

            separator.BackgroundColor = color;

            return separator;
        }

        private static void SetLeftPaddingTo(this UITextField textField, int paddingWidth)
        {
            var paddingView = new UIView(new CGRect(0, 0, paddingWidth, AppDimens.DefaultTextFieldHeight));
            textField.LeftView = paddingView;
            textField.LeftViewMode = UITextFieldViewMode.Always;
        }

        private static void WrapText(this UILabel label)
        {
            label.Lines = 0;
        }

        private static void SetCornerRadiusTo(this UIView label, int cornerRadius)
        {
            label.Layer.MasksToBounds = true;
            label.Layer.CornerRadius = cornerRadius;
        }
    }
}