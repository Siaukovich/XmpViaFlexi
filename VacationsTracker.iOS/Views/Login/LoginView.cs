using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;
using VacationsTracker.iOS.Themes;

namespace VacationsTracker.iOS.Views.Login
{
    public class LoginView : LayoutView
    {
        public UITextField LoginTextField { get; private set; }

        public UITextField PasswordTextField { get; private set; }

        public UIButton LoginButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            LoginTextField = new UITextField().SetDefaultTextFieldStyle();

            PasswordTextField = new UITextField().SetDefaultTextFieldStyle();

            LoginButton = new UIButton().SetPrimaryButtonStyle("Login");
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(LoginTextField)
                .AddLayoutSubview(PasswordTextField)
                .AddLayoutSubview(LoginButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                LoginTextField.AtLeftOf(this, AppDimens.Inset1X),
                LoginTextField.AtRightOf(this, AppDimens.Inset1X),
                LoginTextField.Height().EqualTo(AppDimens.Inset1X),
                LoginTextField.Above(PasswordTextField, 23));

            this.AddConstraints(
                PasswordTextField.AtLeftOf(this),
                PasswordTextField.WithSameCenterY(this),
                PasswordTextField.AtRightOf(this, 33),
                PasswordTextField.Height().EqualTo(56));
        }
    }
}