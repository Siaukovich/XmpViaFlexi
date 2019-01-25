﻿// <auto-generated />
// ReSharper disable All
using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace VacationsTracker.Android.Views
{
    public partial class HomeActivityViewHolder
    {
         private readonly Activity activity;

         private RecyclerView recyclerView;

        public HomeActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public RecyclerView RecyclerView =>
            recyclerView ?? (recyclerView = activity.FindViewById<RecyclerView>(Resource.Id.recyclerView));
    }

    public partial class LoginActivityViewHolder
    {
         private readonly Activity activity;

         private TextView invalidCredentialsText;
         private EditText loginEntry;
         private EditText passwordEntry;
         private Button loginButton;

        public LoginActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextView InvalidCredentialsText =>
            invalidCredentialsText ?? (invalidCredentialsText = activity.FindViewById<TextView>(Resource.Id.invalidCredentialsText));

        
        public EditText LoginEntry =>
            loginEntry ?? (loginEntry = activity.FindViewById<EditText>(Resource.Id.loginEntry));

        
        public EditText PasswordEntry =>
            passwordEntry ?? (passwordEntry = activity.FindViewById<EditText>(Resource.Id.passwordEntry));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.loginButton));
    }

    public partial class LoginRelativeActivityViewHolder
    {
         private readonly Activity activity;

         private TextView invalidCredentialsText;
         private EditText loginEntry;
         private EditText passwordEntry;
         private Button loginButton;

        public LoginRelativeActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextView InvalidCredentialsText =>
            invalidCredentialsText ?? (invalidCredentialsText = activity.FindViewById<TextView>(Resource.Id.invalidCredentialsText));

        
        public EditText LoginEntry =>
            loginEntry ?? (loginEntry = activity.FindViewById<EditText>(Resource.Id.loginEntry));

        
        public EditText PasswordEntry =>
            passwordEntry ?? (passwordEntry = activity.FindViewById<EditText>(Resource.Id.passwordEntry));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.loginButton));
    }

}
// ReSharper restore All
