

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System;


namespace KoombioStaff
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : AppCompatActivity
    {
        #region Menu

        private DrawerLayout drawerLayout;
        private NavigationView navigationView;

        #endregion Menu

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Homepage);
           //stat to menu

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout_id);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "     Select Your Option   ";

            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView_id);
            SetupDrawerContent(navigationView);

            View header = navigationView.GetHeaderView(0);
            TextView navheader_username = header.FindViewById<TextView>(Resource.Id.navheader_username);
            navheader_username.Text = "kasunath lakmal";
          

            //ent to Menu
        }

        #region Menu
        //side menu item clicked
        private void SetupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
               
                 if (e.MenuItem.ItemId == Resource.Id.nav_orders)
                {
                    MyOrdersFragment mf = new MyOrdersFragment();
                    ft.Replace(Resource.Id.linear1, mf);
                }

                else if (e.MenuItem.ItemId == Resource.Id.nav_conacts)
                {
                    ContactFragment cf = new ContactFragment();
                   ft.Replace(Resource.Id.linear1, cf);
                }

                else if (e.MenuItem.ItemId == Resource.Id.nav_logout)
                {
                    LogoutFragment lf = new LogoutFragment();
                    ft.Replace(Resource.Id.linear1, lf);
                }

               
                ft.Commit();
                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.menu_main);
            return true;
        }
        //end of menu
        #endregion Menu
    }
}