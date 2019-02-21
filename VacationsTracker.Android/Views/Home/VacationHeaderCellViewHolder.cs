using Android.Views;
using FlexiMvvm.Bindings;
using FlexiMvvm.Collections;
using VacationsTracker.Core.Presentation.ValueConverters;
using VacationsTracker.Core.Presentation.ViewModels.Home;
using VacationsTracker.Droid.Views.ValueConverters;

namespace VacationsTracker.Droid.Views
{
    public partial class VacationHeaderCellViewHolder
        : RecyclerViewBindableHeaderFooterViewHolder<HomeViewModel>
    {
        public VacationHeaderCellViewHolder(View itemView) : base(itemView)
        {
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(LastUpdatedTime)
                .For(v => v.Text)
                .To(vm => vm.RefreshedDateTime)
                .WithConvertion<RefreshTimeValueConverter>();

            bindingSet.Bind(LastUpdatedTime)
                .For(v => v.Visibility)
                .To(vm => vm.Loading)
                .WithConvertion<InvertVisibilityValueConverter>();
        }
    }
}