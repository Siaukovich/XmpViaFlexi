﻿using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.Home;

namespace VacationsTracker.Droid.Views.Home
{
    [Activity(
        Label = "HomeActivity")]
    public class HomeActivity : FlxBindableAppCompatActivity<HomeViewModel>
    {
        private HomeActivityViewHolder ViewHolder { get; set; }

        private VacationsAdapter VacationsAdapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_home);

            ViewHolder = new HomeActivityViewHolder(this);

            VacationsAdapter = new VacationsAdapter(ViewModel, ViewHolder.RecyclerView)
            {
                Items = ViewModel.Vacations
            };
            ViewHolder.RecyclerView.SetAdapter(VacationsAdapter);
            ViewHolder.RecyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));
        }

    }
}