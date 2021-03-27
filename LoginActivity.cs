using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;







namespace KoombioStaff
{

    [Activity(Label = "LoginActivity")]
    public class LoginActivity : AppCompatActivity

    {
        private EditText editUsername, editPassword;
        private Button btn_forgot, btn_login;

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Loginpage);


            editUsername = FindViewById<EditText>(Resource.Id.user_name);
            editPassword = FindViewById<EditText>(Resource.Id.user_name);
            btn_forgot = FindViewById<Button>(Resource.Id.fpassword_id);
            btn_login = FindViewById<Button>(Resource.Id.btn_login_id);

            btn_login.Click += (sender, e) =>
            {

                Intent i = new Intent(this, typeof(HomeActivity));
                StartActivity(i);

            };

            btn_forgot.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(ForgotPasswordpageActivity));
                StartActivity(i);

            };


            //add the toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_id);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title= "                  Koombio Staff"        ;
            
        }

       
            //add the tool bar
            public override bool OnCreateOptionsMenu(IMenu menu)
            {
                MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
                return base.OnCreateOptionsMenu(menu);
            }

            public override bool OnOptionsItemSelected(IMenuItem item)
            {
                string textToShow;

                if (item.ItemId == Resource.Id.menu_info)
                    textToShow = "Learn more about us on our website :)";
                else
                    textToShow = "Overfloooow";

                Android.Widget.Toast.MakeText(this, item.TitleFormatted + ": " + textToShow,
                    Android.Widget.ToastLength.Long).Show();

                return base.OnOptionsItemSelected(item);
            }
        }
    }