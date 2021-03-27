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

namespace KoombioStaff
{
    [Activity(Label = "RecoverySelectionActivity")]
    public class VerificationPageActivity : AppCompatActivity
    {

        ImageView imageViewBackArrow; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VerificationPage);

            imageViewBackArrow = FindViewById<ImageView>(Resource.Id.leftArrow_id);


            imageViewBackArrow.Click += (sender, e) =>
            {

                Intent i = new Intent(this, typeof(ForgotPasswordpageActivity));
                StartActivity(i);

            };


            //add the toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_id_1);
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