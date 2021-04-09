using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;


namespace KoombioStaff
{
    [Activity(Label = "PickedActivity")]
    public class PickedActivity : AppCompatActivity
    {
        #region Menu

        private DrawerLayout drawerLayout;
        private NavigationView navigationView;

        #endregion Menu

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Pickedlayout);
            //stat to menu

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout_id);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "     Select Your Option   ";

            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            //drawerLayout.SetDrawerListener(drawerToggle);
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
                //e.MenuItem.SetChecked(true);
                //FragmentTransaction ft = this.FragmentManager.BeginTransaction();

                if (e.MenuItem.ItemId == Resource.Id.nav_picked)
                {
                    Intent i = new Intent(this, typeof(PickedActivity));
                    StartActivity(i);
                }

                if (e.MenuItem.ItemId == Resource.Id.nav_home)
                {
                    Intent i = new Intent(this, typeof(HomeActivity));
                    StartActivity(i);
                }

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