using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views.V7;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views.Login
{
    [Activity(
        Label = "LoginActivity",
        Theme = "@style/AppTheme")]
    public class LoginActivity : FlxBindableAppCompatActivity<LoginViewModel>
    {
        private LoginActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            ViewHolder = new LoginActivityViewHolder(this);
        }

        public override void Bind(BindingSet<LoginViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(ViewHolder.InvalidCredentialsText)
                .For(v => v.Visibility)
                .To(vm => vm.ErrorOccured)
                .WithConvertion<VisibilityValueConverter>();

            bindingSet.Bind(ViewHolder.InvalidCredentialsText)
                .For(v => v.Text)
                .To(vm => vm.ErrorMessage);

            bindingSet.Bind(ViewHolder.LoginEntry)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.UserLogin);

            bindingSet.Bind(ViewHolder.PasswordEntry)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.UserPassword);

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.LoginCommand);

            bindingSet.Bind(ViewHolder.IndeterminateBar)
                .For(v => v.Visibility)
                .To(vm => vm.Loading)
                .WithConvertion<VisibilityValueConverter>();

            bindingSet.Bind(ViewHolder.LoginEntry)
                .For(v => v.Enabled)
                .To(vm => vm.Loading)
                .WithConvertion<InvertValueConverter>();

            bindingSet.Bind(ViewHolder.PasswordEntry)
                .For(v => v.Enabled)
                .To(vm => vm.Loading)
                .WithConvertion<InvertValueConverter>();

            bindingSet.Bind(ViewHolder.LoginButton)
                .For(v => v.Enabled)
                .To(vm => vm.Loading)
                .WithConvertion<InvertValueConverter>();
        }
    }
}