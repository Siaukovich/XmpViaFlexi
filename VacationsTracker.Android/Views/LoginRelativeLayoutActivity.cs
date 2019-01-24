using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace VacationsTracker.Android.Views
{
    [Activity(Label = "LoginRelativeLayoutActivity", Theme = "@style/AppTheme")]
    public class LoginRelativeLayoutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_relative_login);

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