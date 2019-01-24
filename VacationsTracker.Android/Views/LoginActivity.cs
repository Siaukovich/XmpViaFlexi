using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;

namespace VacationsTracker.Android.Views
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme")]
    public class LoginActivity : FlxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            var loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs args)
        {
            var errorLabel = FindViewById<TextView>(Resource.Id.InvalidCredentialsText);
            errorLabel.Visibility = ViewStates.Visible;
        }

    }
}