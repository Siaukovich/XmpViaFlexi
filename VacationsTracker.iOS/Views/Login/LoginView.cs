﻿using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {
        public UIImageView BackgroundImage { get; private set; }

        public UITextField InvalidCredentialsTextField { get; private set; }

        public UITextField LoginTextField { get; private set; }

        public UITextField PasswordTextField { get; private set; }

        public UIButton LoginButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundImage = new UIImageView().SetDefaultBackgroundImage();

            LoginTextField = new UITextField().SetDefaultTextFieldStyle("Login");

            PasswordTextField = new UITextField().SetDefaultTextFieldStyle("Password");

            LoginButton = new UIButton().SetPrimaryButtonStyle("Login");
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(BackgroundImage)
                .AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(LoginButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                BackgroundImage.WithSameLeft(this),
                BackgroundImage.WithSameTop(this),
                BackgroundImage.WithSameRight(this),
                BackgroundImage.WithSameBottom(this));

            this.AddConstraints(
                LoginTextField.AtLeftOf(this, AppDimens.Inset5X),
                LoginTextField.AtRightOf(this, AppDimens.Inset5X),
                LoginTextField.Height().EqualTo(AppDimens.DefaultTextFieldHeight),
                LoginTextField.Above(PasswordTextField, AppDimens.Inset2X));

            this.AddConstraints(
                PasswordTextField.WithSameLeft(LoginTextField),
                PasswordTextField.WithSameCenterY(this),
                PasswordTextField.WithSameRight(LoginTextField),
                PasswordTextField.Height().EqualTo(AppDimens.DefaultTextFieldHeight));

            this.AddConstraints(
                LoginButton.AtLeftOf(this, AppDimens.Inset8X),
                LoginButton.AtRightOf(this, AppDimens.Inset8X),
                LoginButton.Below(PasswordTextField, AppDimens.Inset2X),
                LoginButton.Height().EqualTo(AppDimens.DefaultButtonHeight));
        }
    }
}