using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace KoombioStaff
{
    [Activity(Label = "ForgotPasswordpageActivity")]
    public class ForgotPasswordpageActivity : AppCompatActivity
    {
        TextView txt_back, txt_submit;
        EditText editTextMobile;

     

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPasswordpage);

            txt_back = FindViewById<TextView>(Resource.Id.txtback_id);
            txt_submit = FindViewById<TextView>(Resource.Id.txtsubmit_id);

       

            txt_back.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

            txt_submit.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

            txt_submit.Click += (sender, e) =>
            {
                Intent i = new Intent(this, typeof(VerificationPageActivity));
                StartActivity(i);

            };

            //add the toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "                  Koombio Staff";

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
