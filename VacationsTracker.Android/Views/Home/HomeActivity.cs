﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
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

            ViewHolder.Refresher.Refresh += OnRefresh;

            ViewHolder.Fab.ClickWeakSubscribe((sender, args) =>
                Toast.MakeText(this, "Button clicked", ToastLength.Short).Show());

            ViewHolder.RecyclerView.AddOnScrollListener(new HideFabOnScrollListener(ViewHolder.Fab));
        }

        protected override async void OnResume()
        {
             base.OnResume();

             await ViewModel.Refresh();
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(VacationsAdapter)
                .For(v => v.ItemClickedBinding())
                .To(vm => vm.VacationSelectedCommand);
        }

        private async void OnRefresh(object sender, EventArgs args)
        {
            await Task.Delay(1000);
            ViewHolder.Refresher.Refreshing = false;
            ViewModel.RefreshedDateTime = DateTime.Now;
        }
    }
}