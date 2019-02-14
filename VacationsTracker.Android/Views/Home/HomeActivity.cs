using System;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V7.Widget;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Droid.Views.ValueConverters;

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

            SetupRecyclerView();

            SetupSupportActionBar();

            ViewHolder.NavigationView.NavigationItemSelected += (s, e) => ViewHolder.DrawerLayout.CloseDrawers();

            SetRoundUserImage();
        }

        private void SetupRecyclerView()
        {
            VacationsAdapter = new VacationsAdapter(ViewModel, ViewHolder.RecyclerView)
            {
                Items = ViewModel.Vacations
            };

            ViewHolder.RecyclerView.SetAdapter(VacationsAdapter);
            ViewHolder.RecyclerView.SetLayoutManager(new LinearLayoutManager(this, 1, false));

            ViewHolder.RecyclerView.AddOnScrollListener(new HideFabOnScrollListener(ViewHolder.Fab));
        }

        private void SetupSupportActionBar()
        {
            SetSupportActionBar(ViewHolder.HomeToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.Title = "All requests";
        }

        private void SetRoundUserImage()
        {
            var dr = CreateRoundDrawable();
            var image = GetUserImageView();
            image.SetImageDrawable(dr);
        }

        private ImageView GetUserImageView()
        {
            return ViewHolder.NavigationView.GetHeaderView(0).FindViewById<ImageView>(Resource.Id.user_image);
        }

        private RoundedBitmapDrawable CreateRoundDrawable()
        {
            var src = BitmapFactory.DecodeResource(Resources, Resource.Drawable.image_unknown_person);
            var dr = RoundedBitmapDrawableFactory.Create(Resources, src);
            dr.Circular = true;
            return dr;
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

            bindingSet.Bind(ViewHolder.Fab)
                .For(v => v.ClickBinding())
                .To(vm => vm.CreateNewVacationCommand);

            bindingSet.Bind(ViewHolder.NavigationView)
                .For(v => v.NavigationItemSelectedBinding())
                .To(vm => vm.FilterVacationsCommand)
                .WithConvertion<NavigationMenuItemValueConverter>();

            bindingSet.Bind(ViewHolder.Refresher)
                .For(v => v.BeginRefreshingBinding())
                .To(vm => vm.IsRefreshing);

            bindingSet.Bind(ViewHolder.Refresher)
                .For(v => v.EndRefreshingBinding())
                .To(vm => vm.IsRefreshing);

            bindingSet.Bind(ViewHolder.Refresher)
                .For(v => v.ValueChangedBinding())
                .To(vm => vm.RefreshCommand);
        }

        private async void OnRefresh(object sender, EventArgs args)
        {
            await Task.Delay(1000);
            ViewHolder.Refresher.Refreshing = false;
            ViewModel.RefreshedDateTime = DateTime.Now;
        }
    }
}