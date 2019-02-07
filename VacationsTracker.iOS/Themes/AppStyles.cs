﻿using CoreGraphics;
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

            button.SetMainBackgroundColorStyle();

            return button;
        }

        public static UIView SetMainBackgroundColorStyle(this UIView view)
        {
            view.BackgroundColor = AppColors.LightBlueColor;

            return view;
        }

        public static UILabel SetMainBackgroundColorStyle(this UILabel label)
        {
            ((UIView) label).SetMainBackgroundColorStyle();

            return label;
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

        public static UILabel SetTypeLabelStyle(this UILabel label)
        {
            label.SetDefaultFontSize();
            label.TextColor = AppColors.GrayColor;

            return label;
        }

        public static UILabel SetStatusLabelStyle(this UILabel label)
        {
            label.SetDefaultFontSize();
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

        public static UILabel SetTextMainColorStyle(this UILabel label)
        {
            label.TextColor = AppColors.LightBlueColor;

            return label;
        }

        public static UILabel SetsSecondaryColorTextStyle(this UILabel label)
        {
            label.TextColor = AppColors.LightGreenColor;

            return label;
        }

        public static UILabel SetDefaultFontSize(this UILabel label)
        {
            label.SetFontSize(AppDimens.DefaultFontSize);

            return label;
        }

        public static UILabel SetFontSize(this UILabel label, int fontSize)
        {
            label.Font = UIFont.SystemFontOfSize(fontSize);

            return label;
        }

        public static UILabel SetBoldFontSize(this UILabel label, int fontSize)
        {
            label.Font = UIFont.BoldSystemFontOfSize(fontSize);

            return label;
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