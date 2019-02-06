using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using FlexiMvvm;

namespace VacationsTracker.Droid.Views.Home
{
    public class HideFabOnScrollListener : RecyclerView.OnScrollListener
    {
        private readonly FloatingActionButton _fab;

        public HideFabOnScrollListener(FloatingActionButton fab)
        {
            _fab = fab.NotNull();
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            if (dy != 0 && _fab.IsShown)
            {
                _fab.Hide();
            }
        }

        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            if (newState == RecyclerView.ScrollStateIdle)
            {
                _fab.Show();
            }

            base.OnScrollStateChanged(recyclerView, newState);
        }
    }
}