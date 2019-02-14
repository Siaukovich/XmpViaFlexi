using System;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;

namespace VacationsTracker.Droid.Views
{
    public static class CustomBindings
    {
        public static TargetItemBinding<ImageView, int> SetImageResourceBinding(
            this IItemReference<ImageView> imageViewReference)
        {
            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, resId) =>
                {
                    imageView.SetImageResource(resId);
                },
                () => "SetImageResource");
        }

        public static TargetItemBinding<NavigationView, int> NavigationItemSelectedBinding(
            this IItemReference<NavigationView> imageViewReference)
        {
            return new TargetItemOneWayToSourceCustomBinding<NavigationView, int, NavigationView.NavigationItemSelectedEventArgs>(
                imageViewReference,
                (view, handler) => view.NavigationItemSelected += handler,
                (view, handler) => view.NavigationItemSelected -= handler,
                (view, trackCanExecute) => { },
                (view, args) => args.MenuItem.ItemId,
                () => "NavigationItemSelected");
        }

        public static TargetItemBinding<SwipeRefreshLayout, bool> BeginRefreshingBinding(
            this IItemReference<SwipeRefreshLayout> refreshControlReference)
        {
            if (refreshControlReference == null)
                throw new ArgumentNullException(nameof(refreshControlReference));

            return new TargetItemOneWayCustomBinding<SwipeRefreshLayout, bool>(
                refreshControlReference,
                (refreshControl, refreshing) =>
                {
                    if (refreshing && !refreshControl.NotNull().Refreshing)
                    {
                        refreshControl.Refreshing = true;
                    }
                },
                () => "BeginRefreshing");
        }

        public static TargetItemBinding<SwipeRefreshLayout, bool> EndRefreshingBinding(
            this IItemReference<SwipeRefreshLayout> refreshControlReference)
        {
            if (refreshControlReference == null)
                throw new ArgumentNullException(nameof(refreshControlReference));

            return new TargetItemOneWayCustomBinding<SwipeRefreshLayout, bool>(
                refreshControlReference,
                (refreshControl, refreshing) =>
                {
                    if (!refreshing && refreshControl.NotNull().Refreshing)
                    {
                        refreshControl.Refreshing = false;
                    }
                },
                () => "EndRefreshing");
        }

        public static TargetItemBinding<SwipeRefreshLayout, bool> ValueChangedBinding(
            this IItemReference<SwipeRefreshLayout> switchReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayToSourceCustomBinding<SwipeRefreshLayout, bool>(
                switchReference,
                (refresher, eventHandler) => refresher.NotNull().Refresh += eventHandler,
                (refresher, eventHandler) => refresher.NotNull().Refresh -= eventHandler,
                (refresher, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        refresher.NotNull().Refreshing = canExecuteCommand;
                    }
                },
                refresher => refresher.NotNull().Refreshing,
                () => "ValueChanged");
        }
    }
}