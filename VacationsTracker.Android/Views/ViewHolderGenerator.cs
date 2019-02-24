﻿// <auto-generated />
// ReSharper disable All
using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace VacationsTracker.Droid.Views
{
    public partial class HomeActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.Toolbar homeToolbar;
         private Button logoutButton;
         private Android.Support.V4.Widget.DrawerLayout drawerLayout;
         private Android.Support.V4.Widget.SwipeRefreshLayout refresher;
         private Android.Support.V7.Widget.RecyclerView recyclerView;
         private Android.Support.Design.Widget.FloatingActionButton fab;
         private Android.Support.Design.Widget.NavigationView navigationView;

        public HomeActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.Toolbar HomeToolbar =>
            homeToolbar ?? (homeToolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.home_toolbar));

        
        public Button LogoutButton =>
            logoutButton ?? (logoutButton = activity.FindViewById<Button>(Resource.Id.logout_button));

        
        public Android.Support.V4.Widget.DrawerLayout DrawerLayout =>
            drawerLayout ?? (drawerLayout = activity.FindViewById<Android.Support.V4.Widget.DrawerLayout>(Resource.Id.drawer_layout));

        
        public Android.Support.V4.Widget.SwipeRefreshLayout Refresher =>
            refresher ?? (refresher = activity.FindViewById<Android.Support.V4.Widget.SwipeRefreshLayout>(Resource.Id.refresher));

        
        public Android.Support.V7.Widget.RecyclerView RecyclerView =>
            recyclerView ?? (recyclerView = activity.FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.recycler_view));

        
        public Android.Support.Design.Widget.FloatingActionButton Fab =>
            fab ?? (fab = activity.FindViewById<Android.Support.Design.Widget.FloatingActionButton>(Resource.Id.fab));

        
        public Android.Support.Design.Widget.NavigationView NavigationView =>
            navigationView ?? (navigationView = activity.FindViewById<Android.Support.Design.Widget.NavigationView>(Resource.Id.navigation_view));
    }

    public partial class LoginActivityViewHolder
    {
         private readonly Activity activity;

         private ProgressBar indeterminateBar;
         private TextView invalidCredentialsText;
         private EditText loginEntry;
         private EditText passwordEntry;
         private Button loginButton;

        public LoginActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public ProgressBar IndeterminateBar =>
            indeterminateBar ?? (indeterminateBar = activity.FindViewById<ProgressBar>(Resource.Id.indeterminateBar));

        
        public TextView InvalidCredentialsText =>
            invalidCredentialsText ?? (invalidCredentialsText = activity.FindViewById<TextView>(Resource.Id.invalid_credentials_text));

        
        public EditText LoginEntry =>
            loginEntry ?? (loginEntry = activity.FindViewById<EditText>(Resource.Id.login_entry));

        
        public EditText PasswordEntry =>
            passwordEntry ?? (passwordEntry = activity.FindViewById<EditText>(Resource.Id.password_entry));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.login_button));
    }

    public partial class VacationDetailsActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.Toolbar detailsToolbar;
         private Button deleteRequestButton;
         private Button saveRequestButton;
         private ProgressBar indeterminateBar;
         private Android.Support.V4.View.ViewPager vacationTypePager;
         private Android.Support.Design.Widget.TabLayout tabDots;
         private RelativeLayout dateStart;
         private TextView vacationStartDay;
         private TextView vacationStartMonth;
         private TextView vacationStartYear;
         private RelativeLayout dateEnd;
         private TextView vacationEndDay;
         private TextView vacationEndMonth;
         private TextView vacationEndYear;
         private RadioGroup statusRadioGroup;
         private RadioButton approvedRadio;
         private RadioButton closedRadio;

        public VacationDetailsActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.Toolbar DetailsToolbar =>
            detailsToolbar ?? (detailsToolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.details_toolbar));

        
        public Button DeleteRequestButton =>
            deleteRequestButton ?? (deleteRequestButton = activity.FindViewById<Button>(Resource.Id.delete_request_button));

        
        public Button SaveRequestButton =>
            saveRequestButton ?? (saveRequestButton = activity.FindViewById<Button>(Resource.Id.save_request_button));

        
        public ProgressBar IndeterminateBar =>
            indeterminateBar ?? (indeterminateBar = activity.FindViewById<ProgressBar>(Resource.Id.indeterminateBar));

        
        public Android.Support.V4.View.ViewPager VacationTypePager =>
            vacationTypePager ?? (vacationTypePager = activity.FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.vacation_type_pager));

        
        public Android.Support.Design.Widget.TabLayout TabDots =>
            tabDots ?? (tabDots = activity.FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tab_dots));

        
        public RelativeLayout DateStart =>
            dateStart ?? (dateStart = activity.FindViewById<RelativeLayout>(Resource.Id.date_start));

        
        public TextView VacationStartDay =>
            vacationStartDay ?? (vacationStartDay = activity.FindViewById<TextView>(Resource.Id.vacation_start_day));

        
        public TextView VacationStartMonth =>
            vacationStartMonth ?? (vacationStartMonth = activity.FindViewById<TextView>(Resource.Id.vacation_start_month));

        
        public TextView VacationStartYear =>
            vacationStartYear ?? (vacationStartYear = activity.FindViewById<TextView>(Resource.Id.vacation_start_year));

        
        public RelativeLayout DateEnd =>
            dateEnd ?? (dateEnd = activity.FindViewById<RelativeLayout>(Resource.Id.date_end));

        
        public TextView VacationEndDay =>
            vacationEndDay ?? (vacationEndDay = activity.FindViewById<TextView>(Resource.Id.vacation_end_day));

        
        public TextView VacationEndMonth =>
            vacationEndMonth ?? (vacationEndMonth = activity.FindViewById<TextView>(Resource.Id.vacation_end_month));

        
        public TextView VacationEndYear =>
            vacationEndYear ?? (vacationEndYear = activity.FindViewById<TextView>(Resource.Id.vacation_end_year));

        
        public RadioGroup StatusRadioGroup =>
            statusRadioGroup ?? (statusRadioGroup = activity.FindViewById<RadioGroup>(Resource.Id.status_radio_group));

        
        public RadioButton ApprovedRadio =>
            approvedRadio ?? (approvedRadio = activity.FindViewById<RadioButton>(Resource.Id.approved_radio));

        
        public RadioButton ClosedRadio =>
            closedRadio ?? (closedRadio = activity.FindViewById<RadioButton>(Resource.Id.closed_radio));
    }

    public partial class VacationNewActivityViewHolder
    {
         private readonly Activity activity;

         private Android.Support.V7.Widget.Toolbar detailsToolbar;
         private Button saveRequestButton;
         private ProgressBar indeterminateBar;
         private Android.Support.V4.View.ViewPager vacationTypePager;
         private Android.Support.Design.Widget.TabLayout tabDots;
         private RelativeLayout dateStart;
         private TextView vacationStartDay;
         private TextView vacationStartMonth;
         private TextView vacationStartYear;
         private RelativeLayout dateEnd;
         private TextView vacationEndDay;
         private TextView vacationEndMonth;
         private TextView vacationEndYear;
         private RadioGroup statusRadioGroup;
         private RadioButton approvedRadio;
         private RadioButton closedRadio;

        public VacationNewActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public Android.Support.V7.Widget.Toolbar DetailsToolbar =>
            detailsToolbar ?? (detailsToolbar = activity.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.details_toolbar));

        
        public Button SaveRequestButton =>
            saveRequestButton ?? (saveRequestButton = activity.FindViewById<Button>(Resource.Id.save_request_button));

        
        public ProgressBar IndeterminateBar =>
            indeterminateBar ?? (indeterminateBar = activity.FindViewById<ProgressBar>(Resource.Id.indeterminateBar));

        
        public Android.Support.V4.View.ViewPager VacationTypePager =>
            vacationTypePager ?? (vacationTypePager = activity.FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.vacation_type_pager));

        
        public Android.Support.Design.Widget.TabLayout TabDots =>
            tabDots ?? (tabDots = activity.FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tab_dots));

        
        public RelativeLayout DateStart =>
            dateStart ?? (dateStart = activity.FindViewById<RelativeLayout>(Resource.Id.date_start));

        
        public TextView VacationStartDay =>
            vacationStartDay ?? (vacationStartDay = activity.FindViewById<TextView>(Resource.Id.vacation_start_day));

        
        public TextView VacationStartMonth =>
            vacationStartMonth ?? (vacationStartMonth = activity.FindViewById<TextView>(Resource.Id.vacation_start_month));

        
        public TextView VacationStartYear =>
            vacationStartYear ?? (vacationStartYear = activity.FindViewById<TextView>(Resource.Id.vacation_start_year));

        
        public RelativeLayout DateEnd =>
            dateEnd ?? (dateEnd = activity.FindViewById<RelativeLayout>(Resource.Id.date_end));

        
        public TextView VacationEndDay =>
            vacationEndDay ?? (vacationEndDay = activity.FindViewById<TextView>(Resource.Id.vacation_end_day));

        
        public TextView VacationEndMonth =>
            vacationEndMonth ?? (vacationEndMonth = activity.FindViewById<TextView>(Resource.Id.vacation_end_month));

        
        public TextView VacationEndYear =>
            vacationEndYear ?? (vacationEndYear = activity.FindViewById<TextView>(Resource.Id.vacation_end_year));

        
        public RadioGroup StatusRadioGroup =>
            statusRadioGroup ?? (statusRadioGroup = activity.FindViewById<RadioGroup>(Resource.Id.status_radio_group));

        
        public RadioButton ApprovedRadio =>
            approvedRadio ?? (approvedRadio = activity.FindViewById<RadioButton>(Resource.Id.approved_radio));

        
        public RadioButton ClosedRadio =>
            closedRadio ?? (closedRadio = activity.FindViewById<RadioButton>(Resource.Id.closed_radio));
    }

    public partial class VacationCellViewHolder
    {
         private ImageView vacationImage;
         private TextView vacationDuration;
         private TextView vacationType;
         private TextView vacationStatus;
         private View separatorView;



        
        public ImageView VacationImage =>
            vacationImage ?? (vacationImage = ItemView.FindViewById<ImageView>(Resource.Id.vacation_image));

        
        public TextView VacationDuration =>
            vacationDuration ?? (vacationDuration = ItemView.FindViewById<TextView>(Resource.Id.vacation_duration));

        
        public TextView VacationType =>
            vacationType ?? (vacationType = ItemView.FindViewById<TextView>(Resource.Id.vacation_type));

        
        public TextView VacationStatus =>
            vacationStatus ?? (vacationStatus = ItemView.FindViewById<TextView>(Resource.Id.vacation_status));

        
        public View SeparatorView =>
            separatorView ?? (separatorView = ItemView.FindViewById<View>(Resource.Id.separator_view));
    }

    /*
    "cell_vacation_footer" layout file doesn't contain any view with "android:id" attribute specified. There is no sense in view holder generation.
    public partial class VacationFooterCellViewHolder
    {
    }
    */

    public partial class VacationHeaderCellViewHolder
    {
         private TextView lastUpdatedTime;



        
        public TextView LastUpdatedTime =>
            lastUpdatedTime ?? (lastUpdatedTime = ItemView.FindViewById<TextView>(Resource.Id.last_updated_time));
    }

    public partial class VacationTypeFragmentViewHolder
    {
         private readonly View rootView;

         private ImageView imageVacationType;
         private TextView textViewVacationName;

        public VacationTypeFragmentViewHolder( View rootView)
        {
            if (rootView == null) throw new ArgumentNullException(nameof(rootView));

            this.rootView = rootView;
        }

        
        public ImageView ImageVacationType =>
            imageVacationType ?? (imageVacationType = rootView.FindViewById<ImageView>(Resource.Id.image_vacation_type));

        
        public TextView TextViewVacationName =>
            textViewVacationName ?? (textViewVacationName = rootView.FindViewById<TextView>(Resource.Id.text_view_vacation_name));
    }

    /*
    "LayoutDefinitionOptions" are not specified for "navigation_header" layout file therefore view holder can't be generated for it.
    public partial class HeaderNavigationViewHolder
    {
    }
    */

    /*
    "LayoutDefinitionOptions" are not specified for "navigation_menu" layout file therefore view holder can't be generated for it.
    public partial class MenuNavigationViewHolder
    {
    }
    */

}
// ReSharper restore All
