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

namespace KoombioStaff
{
    [Activity(Label = "RecoverySelectionActivity")]
    public class VerificationPageActivity : Activity
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




            }
    }
}