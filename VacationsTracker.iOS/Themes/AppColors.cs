﻿using UIKit;

namespace VacationsTracker.iOS.Themes
{
    internal static class AppColors
    {
        public static readonly UIColor LightBlueColor = GetColorFromHex(0x41C0DA);

        public static readonly UIColor ErrorTextColor = GetColorFromHex(0x800000);

        private static UIColor GetColorFromHex(int hexValue)
        {
            return UIColor.FromRGB(
                ((hexValue & 0xFF0000) >> 16) / 255.0f,
                ((hexValue & 0xFF00) >> 8) / 255.0f,
                (hexValue & 0xFF) / 255.0f
            );
        }
    }
}